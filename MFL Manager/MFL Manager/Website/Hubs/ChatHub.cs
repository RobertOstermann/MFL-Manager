using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using Website.Models;

namespace Website.Hubs
{
    public class ChatHub : Hub
    {
        private static bool _isServerSetUp;

        private static readonly ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();

        private static readonly HashSet<string> OptOutIds = new HashSet<string>();

        private static readonly HashSet<Team> Teams = new HashSet<Team>();

        private static readonly LinkedList<Player> Players = new LinkedList<Player>();

        private static LinkedListNode<Player> _node;

        private static readonly Queue<Message> Messages = new Queue<Message>();

        private static bool _freeAgencyInProgress;

        private static bool _bidInProgress;

        private static bool _matchInProgress;

        private static double _leadBid;

        private static string _leadBidder = "None";

        private static int _contractYears;

        public void SetUpServer()
        {
            if (!_isServerSetUp)
            {
                _isServerSetUp = true;
                CreatePlayers();
                CreateTeams();
            }
        }

        public async void GetCookie()
        {
            string teamId = Context.Features.Get<IHttpContextFeature>().HttpContext.Request.Cookies["TeamCookie"];
            if (!string.IsNullOrWhiteSpace(teamId))
            {
                string team = teamId.Replace('-', ' ');
                if (Connections.TryAdd(team, Context.ConnectionId))
                {
                    await Clients.Others.SendAsync("UpdateTeams");
                }
                else
                {
                    await Clients.Caller.SendAsync("RemoveCookie");
                }
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string team = GetUserTeam();
            if (team != null)
            {
                Connections.TryRemove(team, out _);
            }
            return base.OnDisconnectedAsync(exception);
        }

        // TEAMS

        public async Task GetTeams()
        {
            string userTeam = GetUserTeam();
            foreach (string team in Connections.Keys)
            {
                if (userTeam != null && userTeam.Equals(team))
                {
                    await Clients.Caller.SendAsync("ServerSelectTeam", team.Replace(' ', '-'));
                }
                else
                {
                    await Clients.Caller.SendAsync("ReceiveSetTeam", team.Replace(' ', '-'));
                }
            }
        }

        public async Task SetTeam(string teamId)
        {
            string team = teamId.Replace('-', ' ');
            if (GetUserTeam() == null)
            {
                if (Connections.TryAdd(team, Context.ConnectionId))
                {
                    await Clients.Others.SendAsync("ReceiveSetTeam", teamId);
                    await Clients.Caller.SendAsync("SelectTeam", teamId);
                    await Clients.Caller.SendAsync("SetCookie", teamId);
                }
            }
        }

        public async Task RemoveTeam(string teamId)
        {
            string team = teamId.Replace('-', ' ');
            if (Connections.TryRemove(team, out _))
            {
                await Clients.All.SendAsync("ReceiveRemoveTeam", teamId);
                await Clients.Caller.SendAsync("RemoveCookie");
            }
        }

        // PLAYERS        

        public async Task GetPlayers()
        {
            await Clients.Caller.SendAsync("SetPlayers", Players.ToArray());
        }

        private static void AddPlayerToLinkedList(Player player)
        {
            if (_node == null)
            {
                _node = new LinkedListNode<Player>(player);
                Players.AddFirst(_node);
            }
            else
            {
                Players.AddLast(player);
            }
        }

        // FREE AGENCY

        public async Task StartFreeAgency()
        {
            OptOutIds.Clear();
            _freeAgencyInProgress = true;
            _bidInProgress = true;
            await Clients.Caller.SendAsync("StartFreeAgency");
            Player player = _node?.Value;
            if (player != null)
            {
                _leadBid = player.Salary;
                _leadBidder = player.MflTeam;
                await Clients.All.SendAsync("SetPlayer", player);
                await Clients.All.SendAsync("ReceiveBid", _leadBidder, _leadBid);
            }
        }

        public async Task CheckPermissions()
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                await Clients.Caller.SendAsync("GrantMessagePermissions");
                Player player = _node?.Value;
                if (_bidInProgress)
                {
                    if (player != null && player.Signed)
                    {
                        if (team.Equals(_leadBidder))
                        {
                            await Clients.Caller.SendAsync("GrantFinalBidPermissions");
                        }
                        else if (!string.IsNullOrWhiteSpace(player.OriginalRights) && team.Equals(player.OriginalRights))
                        {
                            await Clients.Caller.SendAsync("RevokeMatchPermissions", _contractYears);
                        }
                        else
                        {
                            await Clients.Caller.SendAsync("RevokeBidPermissions");
                        }
                    }
                    else if (player != null && !string.IsNullOrWhiteSpace(player.OriginalRights) && team.Equals(player.OriginalRights))
                    {
                        await Clients.Caller.SendAsync("RevokeMatchPermissions", _contractYears);
                    }
                    else
                    {
                        await Clients.Caller.SendAsync("GrantBidPermissions");
                        if (OptOutIds.Contains(team))
                        {
                            await Clients.Caller.SendAsync("OptOut");
                        }
                    }
                }
                else
                {
                    if (_matchInProgress && player != null && !string.IsNullOrWhiteSpace(player.OriginalRights) && team.Equals(player.OriginalRights))
                    {
                        await Clients.Caller.SendAsync("GrantMatchPermissions", _contractYears);
                    }
                    else
                    {
                        await Clients.Caller.SendAsync("RevokeBidPermissions");
                    }
                }
            }
            else
            {
                await Clients.Caller.SendAsync("RevokeMessagePermissions");
                await Clients.Caller.SendAsync("RevokeBidPermissions");
            }
        }

        public async Task CheckCommissionerPermissions()
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                if (team.Equals("Storm Dynasty"))
                {
                    await Clients.Caller.SendAsync("CommissionerPermissions", _freeAgencyInProgress);
                }
            }
        }

        public async Task GetPreviousPlayer()
        {
            OptOutIds.Clear();
            await Clients.All.SendAsync("OptIn");
            await Clients.All.SendAsync("UpdateOptOut", OptOutIds.ToArray());
            Player player = _node?.Previous?.Value;
            if (player != null)
            {
                _bidInProgress = !player.Signed;
                _matchInProgress = false;
                _contractYears = player.ContractYears;
                _node = _node.Previous;
                _leadBid = player.Salary;
                _leadBidder = player.MflTeam;
                await Clients.All.SendAsync("SetPlayer", player);
            }
        }

        public async Task GetPlayer()
        {
            if (_freeAgencyInProgress)
            {
                Player player = _node?.Value;
                if (player != null)
                {
                    _bidInProgress = !player.Signed;
                    await Clients.Caller.SendAsync("SetPlayer", player);
                }
            }
        }

        public async Task GetNextPlayer()
        {
            OptOutIds.Clear();
            await Clients.All.SendAsync("OptIn");
            await Clients.All.SendAsync("UpdateOptOut", OptOutIds.ToArray());
            Player player = _node?.Next?.Value;
            if (player != null)
            {
                _bidInProgress = !player.Signed;
                _matchInProgress = false;
                _contractYears = player.ContractYears;
                _node = _node.Next;
                _leadBid = player.Salary;
                _leadBidder = player.MflTeam;
                await Clients.All.SendAsync("SetPlayer", player);
            }
        }

        public async Task PlayerReset()
        {
            OptOutIds.Clear();
            await Clients.All.SendAsync("OptIn");
            await Clients.All.SendAsync("UpdateOptOut", OptOutIds.ToArray());
            Player player = _node?.Value;
            if (player != null)
            {
                _bidInProgress = true;
                _matchInProgress = false;
                player.Salary = player.OriginalSalary;
                player.MflTeam = player.OriginalRights;
                player.ContractYears = 0;
                player.Signed = false;
                _leadBid = player.OriginalSalary;
                _leadBidder = player.OriginalRights;
                _contractYears = player.ContractYears;
                RemovePlayerFromTeam(player);
                await Clients.All.SendAsync("SetPlayer", player);
                await Clients.All.SendAsync("UpdatePlayers", player);
                await Clients.All.SendAsync("UpdateTeamRoster");
            }
        }

        public async Task PlayerSold()
        {
            Player player = _node?.Value;
            if (player != null)
            {
                if (!player.Signed)
                {
                    if (player.OriginalRights.Equals(_leadBidder))
                    {
                        _bidInProgress = false;
                        _matchInProgress = true;
                        player.Salary = _leadBid;
                        player.MflTeam = "None";
                        player.ContractYears = _contractYears;
                        string information = $"No bid was placed. {player.OriginalRights} has the option to sign the player.";
                        string footer = "Player Update: " + player.Name;
                        await Clients.All.SendAsync("ReceiveMessageInformation", information, footer);
                        await Clients.All.SendAsync("SetPlayer", player);
                        await Clients.All.SendAsync("UpdatePlayers", player);
                    }
                    else
                    {
                        player.Signed = true;
                        string information = $"{_leadBidder} placing final bid and deciding contract years now.";
                        string footer = "Player Update: " + player.Name;
                        await Clients.All.SendAsync("ReceiveMessageInformation", information, footer);
                        await Clients.All.SendAsync("SetPlayer", player);
                    }
                }
            }
        }

        public async Task SendMessage(string recipient, string text)
        {
            string team = GetUserTeam();
            var message = new Message(team, text, recipient);
            if (!string.IsNullOrWhiteSpace(team) && !string.IsNullOrWhiteSpace(recipient) && !string.IsNullOrWhiteSpace(text) && !team.Equals(recipient))
            {
                Messages.Enqueue(message);
                if (recipient.Equals("Everyone"))
                {
                    await Clients.Others.SendAsync("ReceiveMessage", team, text);
                    await Clients.Caller.SendAsync("SendMessage", team, text);
                }
                else
                {
                    if (Connections.TryGetValue(recipient, out string client))
                    {
                        await Clients.Client(client).SendAsync("ReceiveMessageDirect", team, text);
                    }
                    await Clients.Caller.SendAsync("SendMessageDirect", team + " to " + recipient, text);
                }
                
            }
        }

        public async Task GetMessages()
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                foreach (Message message in Messages)
                {
                    if (message.Recipient.Equals("Everyone"))
                    {
                        if (message.Team.Equals(team)) await Clients.Caller.SendAsync("SendMessage", message.Team, message.Text);
                        else await Clients.Caller.SendAsync("ReceiveMessage", message.Team, message.Text);
                    }
                    else
                    {
                        if (message.Team.Equals(team)) await Clients.Caller.SendAsync("SendMessageDirect", message.Team + " to " + message.Recipient, message.Text);
                        else if (message.Recipient.Equals(team)) await Clients.Caller.SendAsync("ReceiveMessageDirect", message.Team, message.Text);
                    }
                }
            }
        }

        public async Task OptIn()
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                if (OptOutIds.Remove(team.Replace(' ', '-')))
                {
                    await Clients.Caller.SendAsync("OptIn");
                    await Clients.All.SendAsync("UpdateOptOut", OptOutIds.ToArray());
                }
            }
        }

        public async Task OptOut()
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                if (OptOutIds.Add(team.Replace(' ', '-')))
                {
                    await Clients.Caller.SendAsync("OptOut");
                    await Clients.All.SendAsync("UpdateOptOut", OptOutIds.ToArray());
                }
            }
        }

        public async Task GetBid()
        {
            if (_contractYears == 0)
            {
                Player player = _node?.Value;
                if (player != null && player.Signed)
                {
                    await Clients.Caller.SendAsync("ReceiveBid", _leadBidder, _leadBid, true);
                }
                else
                {
                    await Clients.Caller.SendAsync("ReceiveBid", _leadBidder, _leadBid);
                }
            }
            else
            {
                await Clients.All.SendAsync("ReceiveFinalBid", _leadBidder, _leadBid, _contractYears);
            }
        }

        public async Task SendBid(double bid)
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                if (bid > _leadBid)
                {
                    _leadBid = bid;
                    _leadBidder = team;
                    await Clients.All.SendAsync("ReceiveBid", _leadBidder, _leadBid);
                }
            }
        }

        public async Task SendFinalBid(double bid, int years)
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                if (bid >= _leadBid)
                {
                    _leadBid = bid;
                    _leadBidder = team;
                    _contractYears = years;
                    Player player = _node?.Value;
                    if (player != null)
                    {
                        _bidInProgress = false;
                        _matchInProgress = true;
                        player.Salary = _leadBid;
                        player.MflTeam = _leadBidder;
                        player.ContractYears = _contractYears;
                        player.Signed = true;
                        AddPlayerToTeam(player);
                        string information = $"{_leadBidder} places a final bid of ${_leadBid:F} for {_contractYears} years. {player.OriginalRights} now " +
                                             "has the option to match.";
                        string footer = "Player Update: " + player.Name;
                        await Clients.All.SendAsync("ReceiveMessageInformation", information, footer);
                        await Clients.All.SendAsync("SetPlayer", player);
                        await Clients.All.SendAsync("UpdatePlayers", player);
                        await Clients.All.SendAsync("UpdateTeamRoster");
                    }
                }
            }
        }

        public async Task MatchBid(bool match, int years)
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                Player player = _node?.Value;
                if (player != null)
                {
                    _matchInProgress = false;
                    string information;
                    if (match)
                    {
                        _leadBidder = team;
                        _contractYears = years;
                        information =
                            $"{player.OriginalRights} match. The final deal is {_leadBid:F} for {_contractYears} years.";
                    }
                    else
                    {
                        if (player.Signed)
                        {
                            information =
                                $"{player.OriginalRights} does not match. {_leadBidder} secures the free agent. The final deal is {_leadBid:F} for {_contractYears} years.";
                        }
                        else
                        {
                            _leadBidder = "None";
                            information =
                                $"{player.OriginalRights} does not sign {player.Name}. He will return to the MFL draft";
                        }
                    }

                    player.Salary = _leadBid;
                    player.MflTeam = _leadBidder;
                    player.ContractYears = _contractYears;
                    player.Signed = true;
                    AddPlayerToTeam(player);
                    string footer = "Player Update: " + player.Name;
                    await Clients.All.SendAsync("ReceiveMessageInformation", information, footer);
                }
                await Clients.All.SendAsync("SetPlayer", player);
                await Clients.All.SendAsync("UpdatePlayers", player);
                await Clients.All.SendAsync("UpdateTeamRoster");
            }
        }

        // Team Rosters

        public async Task GetOptOuts()
        {
            string userTeam = GetUserTeam();
            Team selectedTeam = Teams.FirstOrDefault(team => team.Name.Equals(userTeam));
            await Clients.Caller.SendAsync("SetOptOuts", OptOutIds.ToArray(), selectedTeam);
        }

        public async Task GetTeamRoster(string team)
        {
            await Clients.Caller.SendAsync("SetTeamRoster", GetSelectedTeamRoster(team));
        }

        private Team GetSelectedTeamRoster(string selectedTeam)
        {
            return Teams.FirstOrDefault(team => team.Name.Equals(selectedTeam));
        }

        // ALL

        private string GetUserTeam()
        {
            string key = Connections.FirstOrDefault(k => k.Value == Context.ConnectionId).Key;
            return key;
        }

        private void AddPlayerToTeam(Player player)
        {
            foreach (var team in Teams)
            {
                team.Players.Remove(player);
                if (team.Name.Equals(player.MflTeam) || team.Id.Equals(player.MflTeam))
                {
                    team.Players.Add(player);
                }
            }
        }

        private void RemovePlayerFromTeam(Player player)
        {
            foreach (var team in Teams)
            {
                team.Players.Remove(player);
            }
        }

        // Server Initialization

        private static void CreatePlayers()
        {
            var players = new List<Player>();
            if (Players.Count == 0)
            {
                players.Add(new Player("Aaron Jones", "/images/players/Aaron Jones.jpg", "Tornados", "Packers", 7.91, 2, 18.39, 25));
                players.Add(new Player("Chris Godwin", "/images/players/Chris Godwin.jpg", "Penguins", "Buccaneers", 8.16, 2, 16.65, 24));
                players.Add(new Player("Ezekiel Elliot", "/images/players/Ezekiel Elliot.jpg", "Pigeon Boys", "Cowboys", 13.41, 4, 18.04, 25));
                players.Add(new Player("Tyreek Hill", "/images/players/Tyreek Hill.jpg", "Dactyls", "Chiefs", 7.00, 31, 13.28, 26));
                players.Add(new Player("Julio Jones", "/images/players/Julio Jones.png", "ODBs", "Falcons", 24.00, 3, 14.97, 31));
                players.Add(new Player("Josh Jacobs", "/images/players/Josh Jacobs.jpeg", "Storm Dynasty", "Raiders", 7.25, 18, 14.12, 22));
                players.Add(new Player("Miles Sanders", "/images/players/Miles Sanders.jpeg", "Storm Dynasty", "Eagles", 7.00, 15, 12.23, 23));
                players.Add(new Player("Derrick Henry", "/images/players/Derrick Henry.jpg", "Gorillas", "Titans", 7.31, 3, 19.44, 26));
                players.Add(new Player("Lamar Jackson", "/images/players/Lamar Jackson.jpg", "Power", "Ravens", 12.91, 1, 36.40, 23));
                players.Add(new Player("Austin Ekeler", "/images/players/Austin Ekeler.jpg", "Power", "Chargers", 7.00, 6, 16.69, 25));
                foreach (Player player in players)
                {
                    AddPlayerToLinkedList(player);
                }
            }
        }

        private static void CreateTeams()
        {
            CreateTornados();
            CreatePenguins();
            CreatePigeonBoys();
            CreateDactyls();
            CreateOdbs();
            CreateStormDynasty();
            CreateNikeStorm();
            CreateGorillas();
            CreatePower();
            CreateRam();
        }

        #region Create Teams

        private static void CreateTornados()
        {
            var players = new List<Player>
            {
                new Player("Kenyan Drake", 7.50, 2),
                new Player("Sony Michel", 7.00, 2)
            };
            var team = new Team("Tornados", 0, players);
            Teams.Add(team);
        }

        private static void CreatePenguins()
        {
            var players = new List<Player>
            {
                new Player("Deshaun Watson", 10.00, 2),
                new Player("Nick Chubb", 22.00, 2),
                new Player("Dalvin Cook", 7.31, 1),
                new Player("Alvin Kamara", 26.00, 1)
            };
            var team = new Team("Penguins", 0, players);
            Teams.Add(team);
        }

        private static void CreatePigeonBoys()
        {
            var players = new List<Player>
            {
                new Player("Leonard Fournette", 9.13, 1),
                new Player("Amari Cooper", 9.00, 1)
            };
            var team = new Team("Pigeon Boys", 0, players);
            Teams.Add(team);
        }

        private static void CreateDactyls()
        {
            var players = new List<Player>
            {
                new Player("James Connor", 28.00, 1),
                new Player("Christian McCaffrey", 7.64, 1),
                new Player("Zach Ertz", 13.00, 2)
            };
            var team = new Team("Dactyls", 0, players);
            Teams.Add(team);
        }

        private static void CreateOdbs()
        {
            var players = new List<Player>
            {
                new Player("Kerryon Johnson", 13.00, 2),
                new Player("Joe Mixon", 18.00, 1),
                new Player("DeAndre Hopkins", 24.00, 1)
            };
            var team = new Team("ODBs", 0, players);
            Teams.Add(team);
        }

        private static void CreateStormDynasty()
        {
            var players = new List<Player>
            {
                new Player("Patrick Mahomes", 27.00, 2),
                new Player("Keenan Allen", 14.00, 1),
                new Player("Odell Beckham", 25.00, 1),
                new Player("Travis Kelce", 14.00, 1)
            };
            var team = new Team("Storm Dynasty", 2.45, players);
            Teams.Add(team);
        }

        private static void CreateNikeStorm()
        {
            var players = new List<Player>
            {
                new Player("Chris Carson", 9.50, 2),
                new Player("David Johnson", 29.00, 1),
                new Player("Stefon Diggs", 11.00, 2)
            };
            var team = new Team("Nike Storm", 0, players);
            Teams.Add(team);
        }

        private static void CreateGorillas()
        {
            var players = new List<Player>
            {
                new Player("Aaron Rodgers", 23.00, 1),
                new Player("Devonta Freeman", 14.00, 1),
                new Player("JuJu Smith-Schuster", 21.99, 1),
                new Player("Michael Thomas", 21.00, 1)
            };
            var team = new Team("Gorillas", 3.68, players);
            Teams.Add(team);
        }

        private static void CreatePower()
        {
            var players = new List<Player>
            {
                new Player("Saquon Barkley", 11.02, 2),
                new Player("David Montgomery", 7.00, 3),
                new Player("Davante Adams", 21.00, 1),
                new Player("Adam Thielen", 17.00, 1)
            };
            var team = new Team("Power", 2.45, players);
            Teams.Add(team);
        }

        private static void CreateRam()
        {
            var players = new List<Player>
            {
                new Player("Todd Gurley", 8.79, 1),
                new Player("Mike Evans", 17.00, 1)
            };
            var team = new Team("Ram", 0, players);
            Teams.Add(team);
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Hubs
{
    public class ChatHub : Hub
    {
        private static bool _isServerSetUp = false;

        private static ConcurrentDictionary<string, string> _connections = new ConcurrentDictionary<string, string>();

        private static HashSet<string> _optOutIds = new HashSet<string>();

        private static LinkedList<Player> _players = new LinkedList<Player>();

        private static LinkedListNode<Player> _node;

        private static readonly Queue<Message> _messages = new Queue<Message>();

        private static bool _freeAgencyInProgress = false;

        private static bool _bidInProgress = false;

        private static bool _matchInProgress = false;

        private static double _leadBid = 0.00;

        private static string _leadBidder = "None";

        private static int _contractYears = 0;

        public void SetUpServer()
        {
            if (!_isServerSetUp)
            {
                _isServerSetUp = true;
                CreatePlayers();
            }
        }

        public async void GetCookie()
        {
            string teamId = Context.Features.Get<IHttpContextFeature>().HttpContext.Request.Cookies["TeamCookie"];
            if (!string.IsNullOrWhiteSpace(teamId))
            {
                string team = teamId.Replace('-', ' ');
                if (_connections.TryAdd(team, Context.ConnectionId))
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
                _connections.TryRemove(team, out string connection);
            }
            return base.OnDisconnectedAsync(exception);
        }

        // TEAMS

        public async Task GetTeams()
        {
            string userTeam = GetUserTeam();
            foreach (string team in _connections.Keys)
            {
                if (userTeam != null && userTeam.Equals(team))
                {
                    await Clients.Caller.SendAsync("SelectTeam", team.Replace(' ', '-'));
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
                if (_connections.TryAdd(team, Context.ConnectionId))
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
            if (_connections.TryRemove(team, out string connection))
            {
                await Clients.All.SendAsync("ReceiveRemoveTeam", teamId);
                await Clients.Caller.SendAsync("RemoveCookie");
            }
        }

        // PLAYERS        

        public async Task GetPlayers()
        {
            await Clients.Caller.SendAsync("SetPlayers", _players.ToArray());
        }

        private void CreatePlayers()
        {
            if (_players.Count == 0)
            {
                List<Player> players = new List<Player>();
                players.Add(new Player("Aaron Jones", "/images/players/Aaron Jones.jpg", "Tornados", "Packers", 7.91, 2, 18.39, 25));
                players.Add(new Player("Chris Godwin", "/images/players/Chris Godwin.jpg", "Penguins", "Buccaneers", 8.16, 2, 16.65, 24));
                players.Add(new Player("Ezekiel Elliot", "/images/players/Ezekiel Elliot.jpg", "Bombers", "Cowboys", 13.41, 4, 18.04, 25));
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

        private void AddPlayerToLinkedList(Player player)
        {
            if (_node == null)
            {
                _node = new LinkedListNode<Player>(player);
                _players.AddFirst(_node);
            }
            else
            {
                _players.AddLast(player);
            }
        }

        // FREE AGENCY

        public async Task StartFreeAgency()
        {
            _optOutIds.Clear();
            _freeAgencyInProgress = true;
            _bidInProgress = true;
            await Clients.Caller.SendAsync("StartFreeAgency");
            Player player = _node?.Value;
            if (player != null)
            {
                _leadBid = player.Salary;
                _leadBidder = player.MFLTeam;
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
                // Check if team is owner of player.
                if (_bidInProgress)
                {
                    if (player != null && player.Signed)
                    {
                        if (team.Equals(_leadBidder))
                        {
                            await Clients.Caller.SendAsync("GrantFinalBidPermissions");
                        }
                    }
                    else if (player != null && !string.IsNullOrWhiteSpace(player.OriginalRights) && team.Equals(player.OriginalRights))
                    {
                        await Clients.Caller.SendAsync("RevokeMatchPermissions", _contractYears);
                    }
                    else
                    {
                        await Clients.Caller.SendAsync("GrantBidPermissions");
                        if (_optOutIds.Contains(team))
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
                if (team.Equals("Storm Dynasty") || team.Equals("Power"))
                {
                    await Clients.Caller.SendAsync("CommissionerPermissions", _freeAgencyInProgress);
                }
            }
        }

        public async Task GetPreviousPlayer()
        {
            _optOutIds.Clear();
            await Clients.All.SendAsync("OptIn");
            await Clients.All.SendAsync("UpdateOptOut", _optOutIds.ToArray());
            Player player = _node?.Previous?.Value;
            if (player != null)
            {
                if (player.Signed) _bidInProgress = false;
                else _bidInProgress = true;
                _matchInProgress = false;
                _contractYears = player.ContractYears;
                _node = _node.Previous;
                _leadBid = player.Salary;
                _leadBidder = player.MFLTeam;
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
                    if (player.Signed) _bidInProgress = false;
                    else _bidInProgress = true;
                    await Clients.Caller.SendAsync("SetPlayer", player);
                }
            }
        }

        public async Task GetNextPlayer()
        {
            _optOutIds.Clear();
            await Clients.All.SendAsync("OptIn");
            await Clients.All.SendAsync("UpdateOptOut", _optOutIds.ToArray());
            Player player = _node?.Next?.Value;
            if (player != null)
            {
                if (player.Signed) _bidInProgress = false;
                else _bidInProgress = true;
                _matchInProgress = false;
                _contractYears = player.ContractYears;
                _node = _node.Next;
                _leadBid = player.Salary;
                _leadBidder = player.MFLTeam;
                await Clients.All.SendAsync("SetPlayer", player);
            }
        }

        public async Task PlayerReset()
        {
            _optOutIds.Clear();
            await Clients.All.SendAsync("OptIn");
            await Clients.All.SendAsync("UpdateOptOut", _optOutIds.ToArray());
            Player player = _node?.Value;
            if (player != null)
            {
                _bidInProgress = true;
                _matchInProgress = false;
                player.Salary = player.OriginalSalary;
                player.MFLTeam = player.OriginalRights;
                player.ContractYears = 0;
                player.Signed = false;
                _leadBid = player.OriginalSalary;
                _leadBidder = player.OriginalRights;
                _contractYears = player.ContractYears;
                await Clients.All.SendAsync("SetPlayer", player);
                await Clients.All.SendAsync("UpdatePlayers", player);           
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
                        player.MFLTeam = "None";
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
                        await Clients.All.SendAsync("UpdatePlayers", player);
                    }
                }
            }
        }

        public async Task SendMessage(string recipient, string text)
        {
            string team = GetUserTeam();
            Message message = new Message(team, text, recipient);
            if (!string.IsNullOrWhiteSpace(team) && !string.IsNullOrWhiteSpace(recipient) && !string.IsNullOrWhiteSpace(text) && !team.Equals(recipient))
            {
                _messages.Enqueue(message);
                if (recipient.Equals("Everyone"))
                {
                    await Clients.Others.SendAsync("ReceiveMessage", team, text);
                    await Clients.Caller.SendAsync("SendMessage", team, text);
                }
                else
                {
                    if (_connections.TryGetValue(recipient, out string client))
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
                foreach (Message message in _messages)
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
                if (_optOutIds.Remove(team.Replace(' ', '-')))
                {
                    await Clients.Caller.SendAsync("OptIn");
                    await Clients.All.SendAsync("UpdateOptOut", _optOutIds.ToArray());
                }
            }
        }

        public async Task OptOut()
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                if (_optOutIds.Add(team.Replace(' ', '-')))
                {
                    await Clients.Caller.SendAsync("OptOut");
                    await Clients.All.SendAsync("UpdateOptOut", _optOutIds.ToArray());
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
                else
                {
                    //Clients.Client.SendAsync("InvalidBid");
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
                        player.MFLTeam = _leadBidder;
                        player.ContractYears = _contractYears;
                        player.Signed = true;
                        string information = $"{_leadBidder} places a final bid of ${_leadBid:F} for {_contractYears} years." +
                            $"{player.OriginalRights} now has the option to match.";
                        string footer = "Player Update: " + player.Name;
                        await Clients.All.SendAsync("ReceiveMessageInformation", information, footer);
                        await Clients.All.SendAsync("SetPlayer", player);
                        await Clients.All.SendAsync("UpdatePlayers", player);
                    }
                }
                else
                {
                    //Clients.Client.SendAsync("InvalidBid");
                }
            }
        }

        public async Task MatchBid(bool match, int years)
        {
            string team = GetUserTeam();
            string information = string.Empty;
            if (!string.IsNullOrWhiteSpace(team))
            {
                Player player = _node?.Value;
                if (player != null)
                {
                    _matchInProgress = false;
                    if (match)
                    {
                        _leadBidder = team;
                        _contractYears = years;   
                        information = $"{player.OriginalRights} match. The final deal is {_leadBid:F} for {_contractYears} years.";
                    }
                    else
                    {
                        if (player.Signed)
                        {
                            information = $"{player.OriginalRights} does not match. {_leadBidder} secures the free agent. The final deal is {_leadBid:F} for {_contractYears} years.";
                        }
                        else
                        {
                            _leadBidder = "None";
                            information = $"{player.OriginalRights} does not sign {player.Name}. He will return to the MFL draft";
                        }
                    }
                    player.Salary = _leadBid;
                    player.MFLTeam = _leadBidder;
                    player.ContractYears = _contractYears;
                    player.Signed = true;
                }
                string footer = "Player Update: " + player.Name;
                await Clients.All.SendAsync("ReceiveMessageInformation", information, footer);
                await Clients.All.SendAsync("SetPlayer", player);
                await Clients.All.SendAsync("UpdatePlayers", player);
            }
        }

        // ALL

        private string GetUserTeam()
        {
            string key = _connections.FirstOrDefault(k => k.Value == Context.ConnectionId).Key;
            return key;
        }
    }
}

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

        private static double _leadBid = 0.00;

        private static string _leadBidder = "None";

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
                if (_bidInProgress)
                {
                    await Clients.Caller.SendAsync("GrantBidPermissions");
                    if (_optOutIds.Contains(team))
                    {
                        await Clients.Caller.SendAsync("OptOut");
                    }
                }
                else
                {
                    await Clients.Caller.SendAsync("RevokeBidPermissions");
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
            _optOutIds.Clear();
            await Clients.All.SendAsync("OptIn");
            await Clients.All.SendAsync("UpdateOptOut", _optOutIds.ToArray());
            Player player = _node?.Previous?.Value;
            if (player != null)
            {
                if (player.Signed) _bidInProgress = false;
                else _bidInProgress = true;
                _node = _node.Previous;
                _leadBid = player.Salary;
                _leadBidder = player.MFLTeam;
                await Clients.All.SendAsync("SetPlayer", player);
                await Clients.All.SendAsync("ReceiveBid", _leadBidder, _leadBid);
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
                    await Clients.All.SendAsync("SetPlayer", player);
                    await Clients.All.SendAsync("ReceiveBid", _leadBidder, _leadBid);
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
                _node = _node.Next;
                _leadBid = player.Salary;
                _leadBidder = player.MFLTeam;
                await Clients.All.SendAsync("SetPlayer", player);
                await Clients.All.SendAsync("ReceiveBid", _leadBidder, _leadBid);
            }
        }

        public async Task PlayerReset()
        {
            Player player = _node?.Value;
            if (player != null)
            {
                _bidInProgress = true;
                player.Salary = player.OriginalSalary;
                player.MFLTeam = player.OriginalRights;
                player.Signed = false;
                _leadBid = player.OriginalSalary;
                _leadBidder = player.OriginalRights;
                await Clients.All.SendAsync("UpdatePlayers", player);
                await Clients.All.SendAsync("SetPlayer", player);
                await Clients.All.SendAsync("ReceiveBid", _leadBidder, _leadBid);
            }
        }

        public async Task PlayerSold()
        {
            Player player = _node?.Value;
            if (player != null)
            {
                _bidInProgress = false;
                player.Salary = _leadBid;
                player.MFLTeam = _leadBidder;
                player.Signed = true;
                await Clients.All.SendAsync("UpdatePlayers", player);
                await Clients.All.SendAsync("SetPlayer", player);
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
                if (bid == 0)
                {
                    _leadBid = 0;
                    await Clients.All.SendAsync("ReceiveBid", "Reset", _leadBid);
                }
            }
        }

        public async Task GetBid()
        {
            await Clients.Caller.SendAsync("ReceiveBid", _leadBidder, _leadBid);
        }

        // ALL

        private string GetUserTeam()
        {
            string key = _connections.FirstOrDefault(k => k.Value == Context.ConnectionId).Key;
            return key;
        }
    }
}

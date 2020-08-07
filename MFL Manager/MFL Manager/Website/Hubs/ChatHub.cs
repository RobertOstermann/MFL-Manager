using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        private static readonly Queue<Message> Messages = new Queue<Message>();

        private static double LeadBid = 0.00;

        private static string LeadBidder = "None";

        private string Team = string.Empty;

        public async Task SetTeam(string team)
        {
            Team = team;
            // Change connection ID to persist across page changes.
            _connections.Add(team, Context.ConnectionId);
            await Clients.All.SendAsync("ReceiveSetTeam", team);
            await Clients.Caller.SendAsync("SelectTeam", team);
        }

        public async Task GetTeams()
        {
            foreach (var team in _connections.GetTeams())
            {
                await Clients.Caller.SendAsync("ReceiveSetTeam", team.ToString());
            }
        }

        public async Task SendMessage(string team, string text)
        {
            // CHANGE
            // Replace everyone if it is a direct message
            Message message = new Message(Team, text, team);
            if (!string.IsNullOrWhiteSpace(team) && !string.IsNullOrWhiteSpace(text))
            {
                Messages.Enqueue(message);
                await Clients.Others.SendAsync("ReceiveMessage", team, text);
                await Clients.Caller.SendAsync("SendMessage", team, text);
            }
        }

        public async Task GetMessages()
        {
            string cookie = Context.Features.Get<IHttpContextFeature>().HttpContext.Request.Cookies["TeamCookie"];
            await Clients.Caller.SendAsync("SendMessage", cookie, "Cookie");

            foreach (Message message in Messages)
            {
                if (message.Team.Equals(Team)) await Clients.Caller.SendAsync("SendMessage", message.Team, message.Text);
                else await Clients.Caller.SendAsync("ReceiveMessage", message.Team, message.Text);
            }
        }

        public async Task SendBid(double bid)
        {
            if (bid > LeadBid)
            {
                LeadBid = bid;
                LeadBidder = Team;
                await Clients.All.SendAsync("ReceiveBid", Team, LeadBid);
            }
            else
            {
                //Send alert that bid was below current bid.
            }
            if (bid == 0)
            {
                LeadBid = 0;
                await Clients.All.SendAsync("ReceiveBid", LeadBid);
            }
        }

        public async Task GetBid()
        {
            await Clients.Caller.SendAsync("ReceiveBid", LeadBidder, LeadBid);
        }
    }
}

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
        private static Queue<Message> Messages = new Queue<Message>();

        private static double LeadBid = 0.00;

        private static string LeadBidder = "None";

        private string Team = "Power";

        public async Task SendMessage(string team, string text)
        {
            // CHANGE
            // Replace everyone if it is a direct message
            Message message = new Message(team, text, "Everyone");

            Messages.Enqueue(message);
            await Clients.Others.SendAsync("ReceiveMessage", team, text);
            await Clients.Caller.SendAsync("SendMessage", team, text);
        }

        public async Task GetMessages()
        {
            foreach (Message message in Messages)
            {
                if (message.Team.Equals(Team)) await Clients.Caller.SendAsync("SendMessage", message.Team, message.Text);
                else await Clients.Caller.SendAsync("ReceiveMessage", message.Team, message.Text);
            }
        }

        public async Task GetBid()
        {
            await Clients.Caller.SendAsync("ReceiveBid", LeadBidder, LeadBid);
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
    }
}

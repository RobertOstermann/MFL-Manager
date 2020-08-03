using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Hubs
{
    public class ChatHub : Hub
    {
        private static Queue<string> messages = new Queue<string>();

        private static double leadBid = 0.00;

        private string team = "Power";

        public async Task SendMessage(string user, string message)
        {
            string msg = user + ": " + message;
            messages.Enqueue(msg);
            await Clients.Others.SendAsync("ReceiveMessage", team, msg);
            // Could do this on method call in javascript.
            await Clients.Caller.SendAsync("SendMessage", team, msg);
        }

        public async Task GetMessages()
        {
            foreach (string message in messages)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", message);
            }
        }

        public async Task GetBid()
        {
            await Clients.Caller.SendAsync("ReceiveBid", leadBid, 0.00);
        }

        public async Task SendBid(double bid)
        {
            if (bid > leadBid)
            {
                leadBid = bid;
                await Clients.All.SendAsync("ReceiveBid", team, leadBid);
            }
            else
            {
                //Send alert that bid was below current bid.
            }
            if (bid == 0)
            {
                leadBid = 0;
                await Clients.All.SendAsync("ReceiveBid", leadBid);
            }
        }
    }
}

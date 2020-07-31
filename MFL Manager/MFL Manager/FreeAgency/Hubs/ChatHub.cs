using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeAgency.Hubs
{
    public class ChatHub : Hub
    {
        //private static Queue<string> messages = new Queue<string>();

        private static double currentBid = 0.00;

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task GetBid()
        {
            await Clients.Caller.SendAsync("ReceiveBid", currentBid, 0.00);
        }
        public async Task SendBid(double amount)
        {
            await Clients.All.SendAsync("ReceiveBid", currentBid, amount);
            currentBid += amount;
        }
    }
}

﻿using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Hubs
{
    public class ChatHub : Hub
    {
        private static ConcurrentDictionary<string, string> _connections = new ConcurrentDictionary<string, string>();

        private static readonly Queue<Message> Messages = new Queue<Message>();

        private static double LeadBid = 0.00;

        private static string LeadBidder = "None";

        public void GetCookie()
        {
            string teamId = Context.Features.Get<IHttpContextFeature>().HttpContext.Request.Cookies["TeamCookie"];
            string team = teamId.Replace('-', ' ');
            _connections.AddOrUpdate(team, Context.ConnectionId, (key, oldValue) => Context.ConnectionId);
        }

        public async Task SetTeam(string teamId)
        {
            string team = teamId.Replace('-', ' ');
            _connections.AddOrUpdate(team, Context.ConnectionId, (key, oldValue) => Context.ConnectionId);
            await Clients.All.SendAsync("ReceiveSetTeam", teamId);
            await Clients.Caller.SendAsync("SelectTeam", teamId);
        }

        public async Task GetTeams()
        {
            foreach (string team in _connections.Keys)
            {
                await Clients.Caller.SendAsync("ReceiveSetTeam", team.Replace(' ', '-'));
            }
        }

        public async Task SendMessage(string recipient, string text)
        {
            // CHANGE
            // Replace everyone if it is a direct message
            string team = GetUserTeam();
            Message message = new Message(team, text, recipient);
            if (!string.IsNullOrWhiteSpace(team) && !string.IsNullOrWhiteSpace(recipient) && !string.IsNullOrWhiteSpace(text))
            {
                Messages.Enqueue(message);
                if (recipient.Equals("Everyone")) await Clients.Others.SendAsync("ReceiveMessage", team, text);
                else 
                {
                    if (_connections.TryGetValue(recipient, out string client))
                    {
                        // Change ReceiveMessage to ReceiveMessageDirect.
                        await Clients.Client(client).SendAsync("ReceiveMessage", team, text);
                    }
                }
                await Clients.Caller.SendAsync("SendMessage", team, text);
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
                    // Change ReceiveMessage to ReceiveMessageDirect.
                    else if (message.Recipient.Equals(team)) await Clients.Caller.SendAsync("ReceiveMessage", message.Team, message.Text);
                }
            }
        }

        public async Task SendBid(double bid)
        {
            string team = GetUserTeam();
            if (!string.IsNullOrWhiteSpace(team))
            {
                if (bid > LeadBid)
                {
                    LeadBid = bid;
                    LeadBidder = team;
                    await Clients.All.SendAsync("ReceiveBid", team, LeadBid);
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

        public async Task GetBid()
        {
            await Clients.Caller.SendAsync("ReceiveBid", LeadBidder, LeadBid);
        }

        private string GetUserTeam()
        {
            string key = _connections.FirstOrDefault(k => k.Value == Context.ConnectionId).Key;
            return key;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Message
    {
        public string Team { get; set; }

        public string Text { get; set; }

        public string Recipient { get; set; }

        public Message(string team, string text, string recipient)
        {
            Team = team;
            Text = text;
            Recipient = recipient;
        }
    }
}

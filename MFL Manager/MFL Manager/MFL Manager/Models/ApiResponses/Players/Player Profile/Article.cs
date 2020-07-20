using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Players.Player_Profile
{
    public class Article
    {
        [JsonProperty("published")]
        public string Published { get; set; }

        [JsonProperty("id")]
        public string ArticleId { get; set; }

        [JsonProperty("headline")]
        public string Headline { get; set; }
    }
}

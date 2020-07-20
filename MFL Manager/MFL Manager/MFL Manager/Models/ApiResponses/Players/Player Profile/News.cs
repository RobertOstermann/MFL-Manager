using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Players.Player_Profile
{
    public class News
    {
        [JsonProperty("article")]
        public List<Article> Articles { get; set; }
    }
}

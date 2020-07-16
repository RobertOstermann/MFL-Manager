using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Players
{
    public class PlayerInformation
    {
        [JsonProperty("player")]
        public List<Player> Players { get; set; }
    }
}

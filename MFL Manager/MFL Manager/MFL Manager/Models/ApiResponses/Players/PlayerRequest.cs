using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Players
{
    public class PlayerRequest
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("players")]
        public PlayerInformation PlayerInformation { get; set; }
    }
}

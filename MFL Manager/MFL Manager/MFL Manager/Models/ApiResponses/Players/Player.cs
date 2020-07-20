using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Players
{
    public class Player
    {
        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("name")]
        public string PlayerName { get; set; }

        [JsonProperty("id")]
        public string PlayerId { get; set; }

        [JsonProperty("team")]
        public string NFLTeam { get; set; }
    }
}

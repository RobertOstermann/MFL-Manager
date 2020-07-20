using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Players.Player_Profile
{
    public class PlayerProfile
    {
        [JsonProperty("name")]
        public string PlayerName { get; set; }

        //[JsonProperty("news")]
        //public News News { get; set; }

        [JsonProperty("player")]
        public PlayerProfilePlayer Player { get; set; }

        [JsonProperty("id")]
        public string PlayerId { get; set; }
    }
}

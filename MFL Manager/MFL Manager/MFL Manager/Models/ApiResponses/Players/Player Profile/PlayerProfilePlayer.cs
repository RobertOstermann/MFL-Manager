using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Players.Player_Profile
{
    public class PlayerProfilePlayer
    {
        [JsonProperty("dob")]
        public string DateOfBirth { get; set; }

        [JsonProperty("adp")]
        public string ADP { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("id")]
        public string PlayerId { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }
    }
}

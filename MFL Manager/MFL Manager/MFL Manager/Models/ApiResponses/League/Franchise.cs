using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.League
{
    public class Franchise
    {
        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("name")]
        public string TeamName { get; set; }

        [JsonProperty("id")]
        public string TeamId { get; set; }
    }
}

using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.League
{
    public class Division
    {
        [JsonProperty("name")]
        public string DivisionName { get; set; }

        [JsonProperty("id")]
        public string DivisionId { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.League
{
    public class FranchiseInformation
    {
        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("franchise")]
        public List<Franchise> Teams { get; set; }
    }
}

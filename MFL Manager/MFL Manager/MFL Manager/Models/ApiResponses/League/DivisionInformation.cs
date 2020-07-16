using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.League
{
    public class DivisionInformation
    {
        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("division")]
        public List<Division> Division { get; set; }
    }
}

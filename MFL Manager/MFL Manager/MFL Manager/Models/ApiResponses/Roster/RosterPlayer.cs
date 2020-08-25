using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Roster
{
    public class RosterPlayer
    {
        [JsonProperty("id")]
        public string PlayerId { get; set; }

        [JsonProperty("contractYear")]
        public string ContractYear { get; set; }
    }
}

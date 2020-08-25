using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Roster
{
    public class RosterFranchise
    {
        [JsonProperty("id")]
        public string TeamId { get; set; }

        [JsonProperty("player")]
        public List<RosterPlayer> Players { get; set; }
    }
}

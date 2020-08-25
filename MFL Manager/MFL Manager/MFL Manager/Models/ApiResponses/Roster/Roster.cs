using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Roster
{
    public class Roster
    {
        [JsonProperty("franchise")]
        public List<RosterFranchise> Franchise { get; set; }
    }
}

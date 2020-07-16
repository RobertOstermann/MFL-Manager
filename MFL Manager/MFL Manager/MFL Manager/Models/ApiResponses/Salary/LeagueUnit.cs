using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Salary
{
    public class LeagueUnit
    {
        [JsonProperty("leagueUnit")]
        public SalaryInformation SalaryInformation { get; set; }
    }
}

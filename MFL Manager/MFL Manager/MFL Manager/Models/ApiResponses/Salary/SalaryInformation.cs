using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Salary
{
    public class SalaryInformation
    {
        [JsonProperty("player")]
        public List<Salary> PlayerSalaries { get; set; }
    }
}

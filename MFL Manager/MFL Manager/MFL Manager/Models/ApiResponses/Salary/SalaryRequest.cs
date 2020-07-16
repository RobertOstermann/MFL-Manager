using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Salary
{
    public class SalaryRequest
    {
        [JsonProperty("salaries")]
        public LeagueUnit League { get; set; }
    }
}

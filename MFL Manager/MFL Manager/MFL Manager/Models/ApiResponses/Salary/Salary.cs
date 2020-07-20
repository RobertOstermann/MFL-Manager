using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Salary
{
    public class Salary
    {
        [JsonProperty("salary")]
        public string PlayerSalary { get; set; }

        [JsonProperty("id")]
        public string PlayerId { get; set; }

        [JsonProperty("contractYear")]
        public string ContractYear { get; set; }
    }
}

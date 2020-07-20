using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Players.Player_Profile
{
    public class PlayerProfileObject
    {
        [JsonProperty("playerProfile")]
        public List<PlayerProfile> PlayerProfiles { get; set; }
    }
}

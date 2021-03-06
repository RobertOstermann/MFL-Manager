﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.Players.Player_Profile
{
    public class PlayerProfileRequest
    {
        [JsonProperty("playerProfiles")]
        public PlayerProfileObject PlayerProfileObject { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TagsDto
    {
        public int Typing { get; set; } = 0;
        public int Management { get; set; } = 0;
        public int Casual { get; set; } = 0;
        public int Difficult { get; set; } = 0;
        public int Arcade { get; set; } = 0;
        public int Strategy { get; set; } = 0;

        [JsonProperty("2D")]
        public int _2D { get; set; } = 0;
        public int Funny { get; set; } = 0;
        public int Simulation { get; set; } = 0;
        public int Comedy { get; set; } = 0;
        public int Action { get; set; } = 0;

        [JsonProperty("Co-op")]
        public int Coop { get; set; } = 0;

        [JsonProperty("Family Friendly")]
        public int FamilyFriendly { get; set; } = 0;

        [JsonProperty("Local Co-Op")]
        public int LocalCoOp { get; set; } = 0;

        [JsonProperty("Local Multiplayer")]
        public int LocalMultiplayer { get; set; } = 0;
        public int Multiplayer { get; set; } = 0;
        public int Singleplayer { get; set; } = 0;

        [JsonProperty("Co-op Campaign")]
        public int CoopCampaign { get; set; } = 0;

        [JsonProperty("Fast-Paced")]
        public int FastPaced { get; set; } = 0;
        public int Cooking { get; set; } = 0;
    }
}

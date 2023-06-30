using Newtonsoft.Json;

namespace Domain.Models
{ 
    public class Tags
    {
        public int Typing { get; set; }
        public int Management { get; set; }
        public int Casual { get; set; }
        public int Difficult { get; set; }
        public int Arcade { get; set; }
        public int Strategy { get; set; }

        [JsonProperty("2D")]
        public int _2D { get; set; }
        public int Funny { get; set; }
        public int Simulation { get; set; }
        public int Comedy { get; set; }
        public int Action { get; set; }

        [JsonProperty("Co-op")]
        public int Coop { get; set; }

        [JsonProperty("Family Friendly")]
        public int FamilyFriendly { get; set; }

        [JsonProperty("Local Co-Op")]
        public int LocalCoOp { get; set; }

        [JsonProperty("Local Multiplayer")]
        public int LocalMultiplayer { get; set; }
        public int Multiplayer { get; set; }
        public int Singleplayer { get; set; }

        [JsonProperty("Co-op Campaign")]
        public int CoopCampaign { get; set; }

        [JsonProperty("Fast-Paced")]
        public int FastPaced { get; set; }
        public int Cooking { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Game
    {
        public int Appid { get; set; }
        public string Name { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public Tags Tags { get; set; }
        public string Type { get; set; }
        public List<string> Categories { get; set; }
        public string Owners { get; set; }
        public int Positive { get; set; }
        public int Negative { get; set; }
        public string Price { get; set; }

        public string InitialPrice { get; set; }
        public string Discount { get; set; }
        public int Ccu { get; set; }
        public string Languages { get; set; }
        public Platforms Platforms { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("required_age")]
        public string RequiredAge { get; set; }
        public string Website { get; set; }

        [JsonProperty("header_image")]
        public string Header_Image { get; set; }
    }

    


}

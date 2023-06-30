using Newtonsoft.Json;

namespace Application.DTOs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    

    public class GameDto
    {
        public int Appid { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public TagsDto Tags { get; set; }   
        public string Type { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public string Owners { get; set; } = string.Empty;
        public int Positive { get; set; } = 0;
        public int Negative { get; set; } = 0;
        public string Price { get; set; } = string.Empty;

        public string InitialPrice { get; set; } = string.Empty;
        public string Discount { get; set; } = string.Empty;
        public int Ccu { get; set; } = 0;
        public string Languages { get; set; } = string.Empty;
        public PlatformsDto Platforms { get; set; } = new PlatformsDto();

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; } = DateTime.MinValue;

        [JsonProperty("required_age")]
        public string RequiredAge { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;

        [JsonProperty("header_image")]
        public string Header_Image { get; set; } = string.Empty;
    }

    


}

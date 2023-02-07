using Newtonsoft.Json;

namespace Epam.TAF.API.Models.SharedModels
{
    public class PhoneData
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("capacity")]
        public string Capacity { get; set; }

        [JsonProperty("capacity GB")]
        public int СapacityGb { get; set; }

        [JsonProperty("price")]
        public object Price { get; set; }

        [JsonProperty("generation")]
        public string Generation { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        public string CPUmodel { get; set; }
        public string Harddisksize { get; set; }
        public string StrapColour { get; set; }

        [JsonProperty("Case Size")]
        public string CaseSize { get; set; }
        public string Description { get; set; }
        public float Screensize { get; set; }
    }
}

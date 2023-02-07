using Epam.TAF.API.Models.SharedModels;
using Newtonsoft.Json;

namespace Epam.TAF.API.Models.ResponseModels
{
    public class AllPhonesModel
    {
       
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data")]
        public PhoneData? Data { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
        
    }
}

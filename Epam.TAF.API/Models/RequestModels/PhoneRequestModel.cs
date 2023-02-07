using Epam.TAF.API.Models.SharedModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Epam.TAF.API.Models.RequestModels
{
    public class PhoneRequestModel
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("data")]
        public PhoneData? Data { get; set; }

    }
}

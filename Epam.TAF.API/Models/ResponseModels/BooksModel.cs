using Newtonsoft.Json;

namespace Epam.TAF.API.Models.ResponseModels
{
    public class BooksModel
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }
    }  

    public class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("bibleId")]
        public string BibleId { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameLong")]
        public string NameLong { get; set; }
    }
}


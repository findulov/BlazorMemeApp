using System.Text.Json.Serialization;

namespace MemeApp.Domain.Models
{
    public class MemesApiResponseModel
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("memes")]
        public List<MemeApiResponseModel> Memes { get; set; } = new List<MemeApiResponseModel>();
    }
}

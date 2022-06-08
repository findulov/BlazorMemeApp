using System.Text.Json.Serialization;

namespace MemeApp.Shared.Models
{
    public class MemePreviewLinkModel
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}

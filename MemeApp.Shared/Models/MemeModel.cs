using System.Text.Json.Serialization;

namespace MemeApp.Shared.Models
{
    public class MemeModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("postLink")]
        public string PostLink { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("redditPostLikes")]
        public int RedditPostLikes { get; set; }

        [JsonPropertyName("isNotSafeForWork")]
        public bool IsNotSafeForWork { get; set; }

        [JsonPropertyName("isSpoiler")]
        public bool IsSpoiler { get; set; }

        [JsonPropertyName("previewLinks")]
        public ICollection<MemePreviewLinkModel> PreviewLinks { get; set; } = new List<MemePreviewLinkModel>();
    }
}

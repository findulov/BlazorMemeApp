using MemeApp.Domain.Entities;
using System.Text.Json.Serialization;

namespace MemeApp.Domain.Models
{
    public class MemeApiResponseModel
    {
        [JsonPropertyName("postLink")]
        public string PostLink { get; set; }

        [JsonPropertyName("subreddit")]
        public string Subreddit { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("nsfw")]
        public bool Nsfw { get; set; }

        [JsonPropertyName("spoiler")]
        public bool Spoiler { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("ups")]
        public int Ups { get; set; }

        [JsonPropertyName("preview")]
        public List<string> Preview { get; set; }

        public Meme ToEntity() => new(
            Title,
            PostLink,
            Url,
            Author,
            Ups,
            Nsfw,
            Spoiler,
            Preview?.Select(previewUrl => new MemePreviewLink(previewUrl)).ToList());
    }
}

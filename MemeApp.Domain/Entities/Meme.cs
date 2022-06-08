namespace MemeApp.Domain.Entities
{
    public class Meme
    {
        private Meme()
        {

        }

        public Meme(string title, string postLink, string url, string author, int redditPostLikes, bool isNotSafeForWork, bool isSpoiler, ICollection<MemePreviewLink> previewLinks)
        {
            Title = title;
            PostLink = postLink;
            Url = url;
            Author = author;
            RedditPostLikes = redditPostLikes;
            IsNotSafeForWork = isNotSafeForWork;
            IsSpoiler = isSpoiler;
            PreviewLinks = previewLinks;
            CreatedTimestamp = DateTime.UtcNow;
        }

        public Meme(string title, string postLink, string url, string author, bool isNotSafeForWork, ICollection<MemePreviewLink> previewLinks)
        {
            Title = title;
            PostLink = postLink;
            Url = url;
            Author = author;
            IsNotSafeForWork = isNotSafeForWork;
            PreviewLinks = previewLinks;
            CreatedTimestamp = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string PostLink { get; set; }

        public string Url { get; set; }

        public string Author { get; set; }

        public int RedditPostLikes { get; set; }

        public bool IsNotSafeForWork { get; set; }

        public bool IsSpoiler { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public ICollection<MemePreviewLink> PreviewLinks { get; set; } = new List<MemePreviewLink>();
    }
}

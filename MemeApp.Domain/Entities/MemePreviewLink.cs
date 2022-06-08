namespace MemeApp.Domain.Entities
{
    public class MemePreviewLink
    {
        private MemePreviewLink()
        {
        }

        public MemePreviewLink(string url)
        {
            Url = url;
        }

        public int Id { get; set; }

        public string Url { get; set; }

        public int MemeId { get; set; }

        public Meme Meme { get; set; }
    }
}

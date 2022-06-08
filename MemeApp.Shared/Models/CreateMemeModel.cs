using System.ComponentModel.DataAnnotations;

namespace MemeApp.Shared.Models
{
    public class CreateMemeModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        public string Author { get; set; }


        public bool IsNotSafeForWork { get; set; }
    }
}

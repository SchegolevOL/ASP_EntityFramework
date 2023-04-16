using System.ComponentModel.DataAnnotations;

namespace ASP_EntityFramework.Models
{
    public class Post
    {

        public int Id { get; set; }
        [Required, MaxLength(100), MinLength(1)]
        public string Title { get; set; }
        [Required, MaxLength(300), MinLength(1)]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Date { get; set; }
    }
}
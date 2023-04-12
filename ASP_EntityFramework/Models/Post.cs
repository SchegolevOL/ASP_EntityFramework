using System.ComponentModel.DataAnnotations;

namespace ASP_EntityFramework.Models
{
    public class Post
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Error Title"), MaxLength(100), MinLength(1)]
        //[DataType(DataType.Password)]
        public string Title { get; set; }
        [Required, MaxLength(300), MinLength(1)]
        public string Content { get; set; }
        [Required, MaxLength(250)]
        [Display(Name = "Image: ")]
        public string ImageUrl { get; set; }

        public DateTime Date { get; set; }
    }
}

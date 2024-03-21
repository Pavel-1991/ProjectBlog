using System.ComponentModel.DataAnnotations;

namespace ProjectBlog.API.Data.Models.Request.Tag
{
    public class TagRequest
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}

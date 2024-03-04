using Microsoft.Identity.Client;
using ProjectBlog.DAL.Models.Request.Tag;
using System.ComponentModel.DataAnnotations;

namespace ProjectBlog.DAL.Models.Request.Post
{
    public class PostEditRequest
    {
        public Guid id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string? Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string? Body { get; set; }

        [Display(Name = "Теги", Prompt = "Теги")]
        public List<TagRequest>? Tags { get; set; }
    }
}

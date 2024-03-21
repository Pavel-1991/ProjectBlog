using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ProjectBlog.API.Data.Models.Request.Tag
{
    public class TagEditRequest
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }
    }
}

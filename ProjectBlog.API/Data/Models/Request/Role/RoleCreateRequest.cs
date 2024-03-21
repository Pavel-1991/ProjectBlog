using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ProjectBlog.API.Data.Models.Request.Role
{
    public class RoleCreateRequest
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Уровень доступа", Prompt = "Уровень")]
        public int SecurityLvl { get; set; }
    }
}

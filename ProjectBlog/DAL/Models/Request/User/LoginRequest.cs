using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ProjectBlog.DAL.Models.Request.User
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "Введите email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль", Prompt = "Введите пароль")]
        public string Password { get; set; }

    }
}

using Microsoft.Identity.Client;
using ProjectBlog.API.Data.Models.Request.Role;
using System.ComponentModel.DataAnnotations;

namespace ProjectBlog.API.Data.Models.Request.User
{
    public class UserEditRequest
    {
        [DataType(DataType.Text)]
        [Display(Name = "Имя", Prompt = "Имя")]
        public string? FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Фамилия", Prompt = "Фамилия")]
        public string? LastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Ник", Prompt = "Ник")]
        public string? UserName { get; set; }

        [EmailAddress]
        [Display(Name = "Почта")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string? NewPassword { get; set; }

        [Display(Name = "Роли")]
        public List<RoleRequest> Roles { get; set; }

        public Guid Id { get; set; }

    }
}

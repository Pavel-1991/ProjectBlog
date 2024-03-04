using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectBlog.DAL.Models.Request.User;
using ProjectBlog.DAL.Models.Response;
using ProjectBlog.DAL.Repositories;

namespace ProjectBlog.BLL.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterRequest model);
        Task<SignInResult> Login(LoginRequest model);
        Task<IdentityResult> EditAccount(UserEditRequest model);
        Task<UserEditRequest> EditAccount(Guid id);
        Task RemoveAccount(Guid id);
        Task<List<User>> GetAccounts();
        Task LogoutAccount();
    }
}

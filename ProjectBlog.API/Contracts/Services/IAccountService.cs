using Microsoft.AspNetCore.Identity;
using ProjectBlog.API.Data.Models.Request.User;
using ProjectBlog.API.Data.Models.Response;

namespace ProjectBlog.API.Contracts.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterRequest model);
        Task<IdentityResult> EditAccount(UserEditRequest model);
        Task<SignInResult> Login(LoginRequest model);
        Task<UserEditRequest> EditAccount(Guid id);
        Task RemoveAccount(Guid id);
        Task<List<User>> GetAccounts();
    }
}

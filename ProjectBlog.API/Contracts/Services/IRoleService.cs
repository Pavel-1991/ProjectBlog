using ProjectBlog.API.Data.Models.Request.Role;
using ProjectBlog.API.Data.Models.Response;

namespace ProjectBlog.API.Contracts.Services
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateRequest model);
        Task EditRole(RoleEditRequest model);
        Task RemoveRole(Guid id);
        Task<List<Role>> GetRoles();
    }
}

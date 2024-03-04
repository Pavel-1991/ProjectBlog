using ProjectBlog.DAL.Models.Request.Role;
using ProjectBlog.DAL.Models.Response;

namespace ProjectBlog.BLL.Services
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateRequest model);
        Task EditRole(RoleEditRequest model);
        Task RemoveRole(Guid id);
        Task<List<Role>> GetRoles();
    }
}

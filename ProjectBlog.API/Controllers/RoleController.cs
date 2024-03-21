using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjectBlog.API.Contracts.Services;
using ProjectBlog.API.Data.Models.Request.Role;
using ProjectBlog.API.Data.Models.Response;

namespace ProjectBlog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всех ролей
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpGet]
        [Route("GetRoles")]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _roleService.GetRoles();
            return roles;
        }

        /// <summary>
        /// Добавление роли
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(RoleCreateRequest request)
        {
            var result = await _roleService.CreateRole(request);
            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование роли
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpPatch]
        [Route("EditRole")]
        public async Task<IActionResult> EditRole(RoleEditRequest request)
        {
            await _roleService.EditRole(request);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpDelete]
        [Route("RemoveRole")]
        public async Task<IActionResult> RemoveRole(Guid id)
        {
            await _roleService.RemoveRole(id);

            return StatusCode(201);
        }
    }
}

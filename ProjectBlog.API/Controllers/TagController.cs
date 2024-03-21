using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjectBlog.API.Contracts.Services;
using ProjectBlog.API.Data.Models.Request.Tag;
using ProjectBlog.API.Data.Models.Response;

namespace ProjectBlog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagSerive;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagSerive = tagService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всех тегов
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpGet]
        [Route("GetTags")]
        public async Task<IEnumerable<Tag>> GetTags()
        {
            var tags = await _tagSerive.GetTags();
            return tags;
        }

        /// <summary>
        /// Добавление тега
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpPost]
        [Route("AddTag")]
        public async Task<IActionResult> AddTag(TagCreateRequest request)
        {
            var result = await _tagSerive.CreateTag(request);
            return StatusCode(201);
        }

        /// <summary>
        /// Редактирование тега
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpPatch]
        [Route("EditTag")]
        public async Task<IActionResult> EditTag(TagEditRequest request)
        {
            await _tagSerive.EditTag(request);

            return StatusCode(201);
        }

        /// <summary>
        /// Удаление тега
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpDelete]
        [Route("RemoveTag")]
        public async Task<IActionResult> RemoveTag(Guid id)
        {
            await _tagSerive.RemoveTag(id);

            return StatusCode(201);
        }
    }
}

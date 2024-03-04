using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBlog.BLL.Services;
using ProjectBlog.DAL.Models.Request.Tag;
using ProjectBlog.DAL.Repositories;

namespace ProjectBlog.BLL.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _repo;
        private readonly ITagService _tagService;
        private readonly ILogger<TagController> _logger;
        private IMapper _mapper;
        public TagController(ITagRepository repo, IMapper mapper, ITagService tagService, ILogger<TagController> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _tagService = tagService;
            _logger = logger;
        }

        /// <summary>
        /// [Get] Метод, создания тега
        /// </summary>
        [Route("Tag/Create")]
        [Authorize(Roles = "Админ, Модератор")]
        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, создания тега
        /// </summary>
        [Route("Tag/Create")]
        [Authorize(Roles = "Админ, Модератор")]
        [HttpPost]
        public async Task<IActionResult> CreateTag(TagCreateRequest model)
        {
            if (ModelState.IsValid)
            {
                var tagId = _tagService.CreateTag(model);
                _logger.LogInformation($"Создан тег - {model.Name}");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, редактирования тега
        /// </summary>
        [Route("Tag/Edit")]
        [Authorize(Roles = "Админ, Модератор")]
        [HttpGet]
        public IActionResult EditTag(Guid id)
        {
            var view = new TagEditRequest { Id = id };
            return View(view);
        }

        /// <summary>
        /// [Post] Метод, редактирования тега
        /// </summary>
        [Route("Tag/Edit")]
        [Authorize(Roles = "Админ, Модератор")]
        [HttpPost]
        public async Task<IActionResult> EditTag(TagEditRequest model)
        {
            if (ModelState.IsValid)
            {
                await _tagService.EditTag(model);
                _logger.LogDebug($"Изменен тег - {model.Name}");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, удаления тега
        /// </summary>
        [Route("Tag/Remove")]
        [Authorize(Roles = "Админ, Модератор")]
        [HttpGet]
        public async Task<IActionResult> RemoveTag(Guid id, bool isConfirm = true)
        {
            if (isConfirm)
                await RemoveTag(id);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// [Post] Метод, удаления тега
        /// </summary>
        [Route("Tag/Remove")]
        [Authorize(Roles = "Админ, Модератор")]
        [HttpPost]
        public async Task<IActionResult> RemoveTag(Guid id)
        {
            await _tagService.RemoveTag(id);
            _logger.LogDebug($"Удаленн тег - {id}");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// [Get] Метод, получения всех тегов
        /// </summary>
        [Route("Tag/Get")]
        [Authorize(Roles = "Админ, Модератор")]
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagService.GetTags();
            return View(tags);
        }
    }
}

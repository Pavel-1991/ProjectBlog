﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;
using ProjectBlog.API.Contracts.Services;
using ProjectBlog.API.Data.Models.Request.User;
using ProjectBlog.API.Data.Models.Response;

namespace ProjectBlog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AccountController(IAccountService accountService, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Авторизация Аккаунта
        /// </summary>
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                throw new ArgumentNullException("Запрос не корректен");

            var result = await _accountService.Login(request);

            if (!result.Succeeded)
                throw new AuthenticationException("Введенный пароль не корректен или не найден аккаунт");

            var user = await _userManager.FindByEmailAsync(request.Email);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            if (roles.Contains("Админ"))
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, "Админ"));
            }
            else
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.First()));
            }

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return StatusCode(200);
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<UserShowRequest>> GetUsers()
        {
            var users = _accountService.GetAccounts().Result;
            var userResponse = users.Select(u => new UserShowRequest { Id = u.Id, Email = u.Email, UserName = u.UserName, Posts = u.Posts.Select(_ => _.Id) }).ToList();
            return userResponse;
        }

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(RegisterRequest request)
        {
            var result = await _accountService.Register(request);
            if (result.Succeeded)
                return StatusCode(201);
            else
                return StatusCode(204);
        }

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpPatch]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(UserEditRequest request)
        {
            var result = await _accountService.EditAccount(request);

            if (result.Succeeded)
                return StatusCode(201);
            else
                return StatusCode(204);
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [Authorize(Roles = "Админ")]
        [HttpDelete]
        [Route("RemoveUser")]
        public async Task<IActionResult> RemoveUser(Guid id)
        {
            await _accountService.RemoveAccount(id);

            return StatusCode(201);
        }
    }
}

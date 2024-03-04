using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectBlog.DAL.Models.Request.User;
using ProjectBlog.DAL.Models.Response;

namespace ProjectBlog.BLL.Services
{
    public class HomeService : IHomeService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public IMapper _mapper;

        public HomeService(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task GenerateData()
        {
            var testUser = new RegisterRequest { UserName = "user", Email = "user@mail.ru", Password = "111111", FirstName = "user", LastName = "111111" };
            var testUser2 = new RegisterRequest { UserName = "moder", Email = "moder@mail.ru", Password = "222222", FirstName = "moder", LastName = "222222" };
            var testUser3 = new RegisterRequest { UserName = "admin", Email = "admin@mail.ru", Password = "333333", FirstName = "admin", LastName = "333333" };

            var user = _mapper.Map<User>(testUser);
            var user1 = _mapper.Map<User>(testUser2);
            var user2 = _mapper.Map<User>(testUser3);

            var userRole = new Role() { Name = "Пользователь", SecurityLvl = 0 };
            var moderRole = new Role() { Name = "Модератор", SecurityLvl = 1 };
            var adminRole = new Role() { Name = "Админ", SecurityLvl = 3 };

            await _userManager.CreateAsync(user, testUser.Password);
            await _userManager.CreateAsync(user1, testUser2.Password);
            await _userManager.CreateAsync(user2, testUser3.Password);

            await _roleManager.CreateAsync(userRole);
            await _roleManager.CreateAsync(moderRole);
            await _roleManager.CreateAsync(adminRole);

            await _userManager.AddToRoleAsync(user, userRole.Name);
            await _userManager.AddToRoleAsync(user1, moderRole.Name);
            await _userManager.AddToRoleAsync(user2, adminRole.Name);
        }
    }
}

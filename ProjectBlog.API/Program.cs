
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectBlog.API.Contracts;
using ProjectBlog.API.Contracts.Services;
using ProjectBlog.API.Data;
using ProjectBlog.API.Data.Models.Response;
using ProjectBlog.API.Data.Repositories;
using ProjectBlog.DAL.Repositories;

namespace ProjectBlog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Connect AutoMapper
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            // Connect DataBase
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection))
                .AddIdentity<User, Role>(opts =>
                {
                    opts.Password.RequiredLength = 5;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<BlogDbContext>();

            // Services AddSingletons/Transient
            builder.Services
                .AddSingleton(mapper)
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ITagRepository, TagRepository>()
                .AddTransient<IPostRepository, PostRepository>()
                .AddTransient<IAccountService, AccountService>()
                .AddTransient<ICommentService, CommentService>()
                .AddTransient<IPostService, PostService>()
                .AddTransient<ITagService, TagService>()
                .AddTransient<IRoleService, RoleService>();

            builder.Services.AddAuthentication(optionts => optionts.DefaultScheme = "Cookies")
                .AddCookie("Cookies", options =>
                {
                    options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = redirectContext =>
                        {
                            redirectContext.HttpContext.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
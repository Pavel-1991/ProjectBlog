using AutoMapper;
using ProjectBlog.DAL.Models.Request.Comment;
using ProjectBlog.DAL.Models.Request.Post;
using ProjectBlog.DAL.Models.Request.Tag;
using ProjectBlog.DAL.Models.Request.User;
using ProjectBlog.DAL.Models.Response;

namespace ProjectBlog.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));

            CreateMap<CommentCreateRequest, Comment>();
            CreateMap<CommentEditRequest, Comment>();
            CreateMap<PostCreateRequest, Post>();
            CreateMap<PostEditRequest, Post>();
            CreateMap<TagCreateRequest, Tag>();
            CreateMap<TagEditRequest, Tag>();
            CreateMap<UserEditRequest, User>();
        }
    }
}

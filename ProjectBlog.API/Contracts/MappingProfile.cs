using AutoMapper;
using ProjectBlog.API.Data.Models.Request.Comment;
using ProjectBlog.API.Data.Models.Request.Post;
using ProjectBlog.API.Data.Models.Request.Tag;
using ProjectBlog.API.Data.Models.Request.User;
using ProjectBlog.API.Data.Models.Response;

namespace ProjectBlog.API.Contracts
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

﻿using ProjectBlog.API.Data.Models.Request.Post;
using ProjectBlog.API.Data.Models.Response;

namespace ProjectBlog.API.Contracts.Services
{
    public interface IPostService
    {
        Task<PostCreateRequest> CreatePost();
        Task<Guid> CreatePost(PostCreateRequest model);
        Task<PostEditRequest> EditPost(Guid Id);
        Task EditPost(PostEditRequest model, Guid Id);
        Task RemovePost(Guid id);
        Task<List<Post>> GetPosts();
        Task<Post> ShowPost(Guid id);
    }
}

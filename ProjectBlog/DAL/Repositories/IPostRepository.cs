using ProjectBlog.DAL.Models.Response;

namespace ProjectBlog.DAL.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();
        Post GetPost(Guid id);
        Task AddPost(Post post);
        Task UpdatePost(Post post);
        Task RemovePost(Guid id);
        Task<bool> SaveChangesAsync();
    }
}

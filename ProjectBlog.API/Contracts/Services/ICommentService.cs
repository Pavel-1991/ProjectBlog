using ProjectBlog.API.Data.Models.Request.Comment;
using ProjectBlog.API.Data.Models.Response;

namespace ProjectBlog.API.Contracts.Services
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateRequest model);
        Task<int> EditComment(CommentEditRequest model);
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
    }
}

using ProjectBlog.DAL.Models.Request.Comment;
using ProjectBlog.DAL.Models.Response;

namespace ProjectBlog.BLL.Services
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateRequest model, Guid UserId);
        Task EditComment(CommentEditRequest model);
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
    }
}

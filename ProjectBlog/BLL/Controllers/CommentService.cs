using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectBlog.BLL.Services;
using ProjectBlog.DAL.Models.Request.Comment;
using ProjectBlog.DAL.Models.Response;
using ProjectBlog.DAL.Repositories;

namespace ProjectBlog.BLL.Controllers
{
    public class CommentService : ICommentService
    {
        public IMapper _mapper;
        private ICommentRepository _commentRepo;
        private UserManager<User> _userManager;

        public CommentService(IMapper mapper, ICommentRepository commentRepo, UserManager<User> userManager)
        {
            _mapper = mapper;
            _commentRepo = commentRepo;
            _userManager = userManager;
        }

        public async Task<Guid> CreateComment(CommentCreateRequest model, Guid UserId)
        {
            Comment comment = new Comment
            {
                Title = model.Title,
                Body = model.Description,
                Author = model.Author,
                PostId = model.PostId,
                AuthorId = UserId,
                RealAuthorName = _userManager.FindByIdAsync(UserId.ToString()).Result.UserName,
            };

            await _commentRepo.AddComment(comment);
            return comment.Id;
        }

        public async Task EditComment(CommentEditRequest model)
        {
            var comment = _commentRepo.GetComment(model.Id);

            comment.Title = model.Title;
            comment.Body = model.Description;
            comment.Author = model.Author;

            await _commentRepo.UpdateComment(comment);
        }

        public async Task RemoveComment(Guid id)
        {
            await _commentRepo.RemoveComment(id);
        }

        public async Task<List<Comment>> GetComments()
        {
            return _commentRepo.GetAllComments().ToList();
        }
    }
}

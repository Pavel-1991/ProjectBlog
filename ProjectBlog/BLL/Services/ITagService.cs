using ProjectBlog.DAL.Models.Request.Tag;
using ProjectBlog.DAL.Models.Response;

namespace ProjectBlog.BLL.Services
{
    public interface ITagService
    {
        Task<Guid> CreateTag(TagCreateRequest model);
        Task EditTag(TagEditRequest model);
        Task RemoveTag(Guid id);
        Task<List<Tag>> GetTags();
    }
}

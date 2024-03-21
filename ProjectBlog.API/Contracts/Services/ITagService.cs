using ProjectBlog.API.Data.Models.Request.Tag;
using ProjectBlog.API.Data.Models.Response;

namespace ProjectBlog.API.Contracts.Services
{
    public interface ITagService
    {
        Task<Guid> CreateTag(TagCreateRequest model);
        Task EditTag(TagEditRequest model);
        Task RemoveTag(Guid id);
        Task<List<Tag>> GetTags();
    }
}

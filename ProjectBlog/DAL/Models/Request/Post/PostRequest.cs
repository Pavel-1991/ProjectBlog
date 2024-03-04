using ProjectBlog.DAL.Models.Request.Tag;

namespace ProjectBlog.DAL.Models.Request.Post
{
    public class PostRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string AuthorId { get; set; }
        public List<TagRequest> Tags { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
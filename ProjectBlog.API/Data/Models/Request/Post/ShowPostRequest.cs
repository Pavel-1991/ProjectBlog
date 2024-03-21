using ProjectBlog.API.Data.Models.Request.Tag;

namespace ProjectBlog.API.Data.Models.Request.Post
{
    public class ShowPostRequest
    {
        public Guid Id { get; set; }

        public string AuthorId { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
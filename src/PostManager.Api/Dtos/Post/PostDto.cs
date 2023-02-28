using PostManager.Api.Dtos.Audit;
using PostManager.Api.Dtos.User;

namespace PostManager.Api.Dtos.Post
{
    public class PostDto:AuditDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }
        public AuthorDto Author { get; set; }
    }
}

namespace PostManager.Api.Dtos.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }
    }
}

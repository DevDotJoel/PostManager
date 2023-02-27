using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostManager.Api.Data;
using PostManager.Api.Dtos.Post;
using PostManager.Api.Entities;

namespace PostManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PostManagerContext _dbContext;
        public UserController(PostManagerContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostDto createPost)
        {
            var addPost = new Post();
            addPost.Text = createPost.Text;
            await _dbContext.Posts.AddAsync(addPost);
            await _dbContext.SaveChangesAsync();
            return Ok(new { Data = addPost, Result = "success" });
        }
        [HttpGet("post/{username}/{postId:int}")]
        public async Task<IActionResult> FindPostByUserAndId(string username , int postId)
        {
            var user = await _dbContext.Users.Where(u => u.UserName== username).AsNoTracking().FirstOrDefaultAsync();
            if (user != null)
            {
                var post= await _dbContext.Posts.Where(p=>p.Id== postId && p.UserId== user.Id).AsNoTracking().FirstOrDefaultAsync();

                return Ok(new { Data = post, Result = "success" });

            }
            return NotFound();
        }
    }
}

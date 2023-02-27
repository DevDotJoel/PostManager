using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostManager.Api.Data;
using PostManager.Api.Dtos.Post;
using PostManager.Api.Entities;

namespace PostManager.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostManagerContext _dbContext; 
        public PostController(PostManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
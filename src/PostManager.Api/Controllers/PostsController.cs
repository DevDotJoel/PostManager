﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostManager.Application.Posts.Commands.CreatePost;
using PostManager.Application.Posts.Queries.ListPosts;
using PostManager.Contracts.Requests.Post;

namespace PostManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class PostsController(ISender _mediator) : ApiController
    {

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostRequest createPost)
        {
            var command = new CreatePostCommand(createPost.Title, createPost.Content);
            var result = await _mediator.Send(command);
            return result.Match(post => Ok(post), Problem);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var command = new ListPostQuery();
            var result = await _mediator.Send(command);
            return result.Match(Ok, Problem);
        }
    }
}

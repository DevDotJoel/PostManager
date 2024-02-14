using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostManager.Application.Users.Queries;

namespace PostManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ISender _mediator) : ApiController
    {

        [HttpGet("CurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var query = new GetCurrentUserQuery();
            var result= await _mediator.Send(query);
            return result.Match(Ok, Problem);
        }
    }
}

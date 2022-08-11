using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AskTrevor.Models.Post;
using AskTrevor.Service.Post;

namespace AskTrevor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreatePost([FromBody] PostCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createResult = await _service.CreatePostAsync(model);
            if (createResult)
            {
                return Ok("Post successfully created");
            }
            return BadRequest("Post not created");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AskTrevor.Service.Comment;
using AskTrevor.Models.Comment;

namespace AskTrevor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService) {
            {
                _commentService = commentService;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateComment([FromBody] CommentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentResult = await _commentService.CreateCommentAsync(model);
            if (commentResult)
            {
                return Ok("Comment was successfully created");
            }
            return BadRequest("Something went wrong. Comment could not be created.");
        }

        [HttpGet("{commentId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int commentId)
        {
            var commentDetail = await _commentService.GetCommentByIdAsync(commentId);

            if (commentDetail is null)
            {
                return NotFound();
            }
            return Ok(commentDetail);
        }
    }
}

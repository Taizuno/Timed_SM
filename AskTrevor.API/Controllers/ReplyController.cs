using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AskTrevor.Service.Reply;

namespace AskTrevor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _service;
        public ReplyController(IReplyService service)
        {
            _service = service;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateReply([FromBody] ReplyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createResult = await _service.CreateReplyAsync(model);
            if (createResult)
            {
                return OK("Reply was created");
            }
            return BadRequest("Reply could not be created");
        }
    }
}

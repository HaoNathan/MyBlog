using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO;
using MyBlog.IBLL;

namespace MyBlog.Controllers
{
    [Route("api/ReplyMessage")]
    [ApiController]
    public class ReplyMessageController : ControllerBase
    {
        private readonly IReplyMessageManager _manager;

        public ReplyMessageController(IReplyMessageManager manager)
        {
            _manager = manager;
        }
        [HttpPost(Name = nameof(CreateReplyMessage))]
        public async Task<IActionResult> CreateReplyMessage(ReplyMessageDto model)
        {
            await _manager.CreateReplyMessage(model);

            return Created(nameof(CreateReplyMessage),new{msg="success"});
        }

       
    }
}

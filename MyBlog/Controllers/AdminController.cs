using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IBLL;
using MyBlogDTO;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController:ControllerBase
    {
        private readonly IAdminManager _manager;

        public AdminController(IAdminManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AdminDto model)
        {

            if (!await _manager.Login(model) )
            {
                return NotFound(new { msg = "登陆失败" });
            }

            return Ok(new {msg = "登陆成功"});

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ArticleController:ControllerBase
    {
        public async Task<IActionResult> CreateArticle()
        {


            return Ok();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO.AddViewDto;
using MyBlog.IBLL;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/article/{articleId}")]
    public class ArticleCommentController : ControllerBase
    {
        private readonly IArticleCommentManager _manager;

        public ArticleCommentController(IArticleCommentManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [Route("articleComment")]
        public async Task<IActionResult> CreateArticleComment(Guid articleId, [FromBody] AddArticleCommentDto model)
        {
            if (!TryValidateModel(model))
            {
                return ValidationProblem(ModelState);
            }

            model.ArticleId = articleId;

            var res = await _manager.CreateArticleComment(model)==1;

            return Ok(new { isSuccess = res, msg = "操作成功"});

        }

        [HttpGet]
        public IActionResult GetArticleComment(Guid articleId, [FromQuery] bool isRemove)
        {
            var data = _manager.QueryArticleComments(articleId, isRemove).ToList();

            return Ok(data);
        }
    }
}

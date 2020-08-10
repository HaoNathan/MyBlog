using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO.AddViewDto;
using MyBlog.IBLL;
using MyBlogDTO;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/articleCategory/{articleCategoryId}/article")]
    public class ArticleController:ControllerBase
    {
        private readonly IArticleManager _manager;

        public ArticleController(IArticleManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{articleId}")]
        public ActionResult<List<ArticleCategoryDto>> GetCategories([FromQuery] bool isRemove, bool isNoTracking,Guid articleId)
        {
            return Ok(_manager.QueryArticles(isRemove, isNoTracking)
                .Where(m=>m.Id.Equals(articleId)).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Guid articleCategoryId, [FromBody] AddArticleDto model)
        {
            if (!TryValidateModel(model))
            {
                return ValidationProblem(ModelState);
            }
            model.ArticleCategoryId = articleCategoryId;
            return Ok(await _manager.CreateArticle(model));
        }


        
    }
}

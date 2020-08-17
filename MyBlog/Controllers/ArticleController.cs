using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.IBLL;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/articleCategory/{articleCategoryId}/article")]
    public class ArticleController:ControllerBase
    {
        private readonly IArticleManager _manager;
        private readonly IMapper _mapper;

        public ArticleController(IArticleManager manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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

        [HttpPost]
        [Route("{articleId}/updateStatus")]
        public async Task<IActionResult> UpdateArticleStatus( [FromRoute]Guid articleId,[FromBody] ArticleDto model)
        {
            await _manager.UpdateArticleStatus(articleId, model.IsRemove);

            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO;
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
    }
}

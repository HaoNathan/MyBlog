using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO.AddViewDto;
using MyBlog.IBLL;
using MyBlog.MODEL;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/article/{articleId}/articleComment")]
    public class ArticleCommentController : ControllerBase
    {
        private readonly IArticleCommentManager _manager;
        private readonly IMapper _mapper;

        public ArticleCommentController(IArticleCommentManager manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticleComment(Guid articleId, [FromBody] AddArticleCommentDto model)
        {
            if (!TryValidateModel(model))
            {
                return ValidationProblem(ModelState);
            }

            model.ArticleId = articleId;

            var articleComment = _mapper.Map<ArticleComment>(model);

            if (await _manager.CreateArticleComment(articleComment) != 1)
            {
                return BadRequest();
            }

            return CreatedAtRoute(nameof(GetArticleComment), new {articleId, isRemove = false }, articleComment);

        }

        [HttpGet(Name = nameof(GetArticleComment))]
        public IActionResult GetArticleComment([FromRoute]Guid articleId, [FromQuery] bool isRemove)
        {
            var data = _manager.QueryArticleComments(articleId, isRemove).ToList();

            return Ok(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO;
using MyBlog.IBLL;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticlesController:ControllerBase
    {
        private readonly IArticleManager _manager;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleManager manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ArticleDto>> GetArticles(bool isRemove,bool isNoTracking)
        {
            var data = _manager.QueryArticles(isRemove, isNoTracking);
            return Ok(_mapper.Map<List<ArticleDto>>(data).ToList());
        }

        [HttpGet]
        [Route("{articleId}")]
        public ActionResult<ArticleDto> GetArticle([FromQuery]bool isRemove,[FromQuery] bool isNoTracking,Guid articleId)
        {
            var data = _manager.QueryArticles(isRemove, isNoTracking)
                .FirstOrDefault(m=>m.Id.Equals(articleId));
            return Ok(_mapper.Map<ArticleDto>(data));
        }
    }
}

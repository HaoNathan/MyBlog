using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO;
using MyBlog.DTO.ParameterDto;
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

        [HttpGet(Name = nameof(GetArticles))]
        public async Task<ActionResult<List<ArticleDto>>> GetArticles(ArticleParameter parameter)
        {
            var data =await _manager.QueryArticles(parameter);
            return Ok(_mapper.Map<List<ArticleDto>>(data).ToList());
        }

        [HttpGet]
        [Route("{articleId}")]
        public ActionResult<ArticleDto> GetArticle(Guid articleId)
        {
            var data = _manager.QueryArticle(articleId);
               
            return Ok(_mapper.Map<ArticleDto>(data));
        }



        private string CreateCompaniesResourceUri(ArticleParameter parameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:

                    return Url.Link(nameof(GetArticles), new
                    {
                        parameters.Fields,
                        parameters.PageSize,
                        PageNum = parameters.PageNum - 1,
                        parameters.Search
                    });

                case ResourceUriType.NextPage:
                    return Url.Link(nameof(GetArticles), new
                    {
                        parameters.Fields,
                        parameters.PageSize,
                        PageNum = parameters.PageNum + 1,
                        parameters.Search
                    });

                default:
                    return Url.Link(nameof(GetArticles), new
                    {
                        parameters.Fields,
                        parameters.PageSize,
                        parameters.PageNum,
                        parameters.Search
                    });

            }
        }

        private IEnumerable<LinkDto> CreateLinksForCompany(ArticleParameter parameters, bool hasPrevious,
            bool hasNext)
        {
            var links = new List<LinkDto>();

            links.Add(new LinkDto(CreateCompaniesResourceUri(parameters, ResourceUriType.CurrentPage), "self", "Get"));

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateCompaniesResourceUri(parameters, ResourceUriType.PreviousPage),
                    "previousPage", "Get"));
            }

            if (hasNext)
            {
                links.Add(new LinkDto(CreateCompaniesResourceUri(parameters, ResourceUriType.NextPage), "nextPage",
                    "Get"));
            }

            return links;
        }
    }
}

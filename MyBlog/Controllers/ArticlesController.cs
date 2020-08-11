using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Extens;
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
        public  ActionResult<List<ArticleDto>> GetArticles([FromQuery]ArticleParameter parameter)
        {
            var data = _manager.QueryArticles(parameter);
            
            var pageNationMetaData = new
            {
                data.PageSize,
                currentPage = data.CurrentPage,
                totalCount = data.TotalCount,
                totalPages = data.TotalPages
            };

            Response.Headers.Add("xPageNation", JsonSerializer.Serialize(pageNationMetaData, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }));

            var links = CreateLinksForArticle(parameter, data.HasPrevious, data.HasNext);

            var articles =(IEnumerable<ArticleDto>)data;

            var articlesShape = articles.ShapeData(parameter.Fields);

            return Ok(new{values=articlesShape,links});
        }

        [HttpGet]
        [Route("{articleId}")]
        public async Task<ActionResult<ArticleDto>> GetArticle(Guid articleId)
        {
            var data =await _manager.QueryArticle(articleId);
               
            return Ok(data);
        }



        private string CreateArticleResourceUri(ArticleParameter parameters, ResourceUriType type)
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

        private IEnumerable<LinkDto> CreateLinksForArticle(ArticleParameter parameters, bool hasPrevious,
            bool hasNext)
        {
            var links = new List<LinkDto>();

            links.Add(new LinkDto(CreateArticleResourceUri(parameters, ResourceUriType.CurrentPage), "self", "Get"));

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateArticleResourceUri(parameters, ResourceUriType.PreviousPage),
                    "previousPage", "Get"));
            }

            if (hasNext)
            {
                links.Add(new LinkDto(CreateArticleResourceUri(parameters, ResourceUriType.NextPage), "nextPage",
                    "Get"));
            }

            return links;
        }
    }
}

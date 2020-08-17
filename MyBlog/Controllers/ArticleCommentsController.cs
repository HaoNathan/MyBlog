using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Helper.PageList;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Extens;
using MyBlog.DTO;
using MyBlog.DTO.ParameterDto;
using MyBlog.IBLL;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/articleComments")]
    public class ArticleCommentsController:ControllerBase
    {
        private readonly IArticleCommentManager _manager;

        public ArticleCommentsController(IArticleCommentManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public ActionResult<PageList<ArticleCommentDto>> GetAllArticleComments([FromQuery]ArticleCommentParameter parameter)
        {
            var data = _manager.QueryAllArticleComments(parameter);

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

            return Ok(data);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.IBLL;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/articleCategory")]
    public class ArticleCategoryController:ControllerBase
    {
        private readonly IArticleCategoryManager _manager;

        public ArticleCategoryController(IArticleCategoryManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]AddArticleCategoryDto model)
        {
            //如果不符合数据约束

            if (!TryValidateModel(model))
            {
                return ValidationProblem(ModelState);//返回422数据错误
            }

            if (await _manager.CreateCategory(model)==1)
                return Ok(new {msg = "新增成功"});

            return Ok(new {msg = "新增失败"});
        }

        [HttpGet]
        [ResponseCache(Duration = 180)]
        public ActionResult<List<ArticleCategoryDto>> GetCategories([FromQuery]bool isRemove)
        {
            return Ok(_manager.QueryAll(isRemove,true).ToList());
        }

      
    }
}

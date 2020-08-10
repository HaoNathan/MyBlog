using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/Upload")]
    public class UploadImage:ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public UploadImage(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">来自form表单的文件信息</param>
        /// <returns></returns>
        [HttpPost("UploadArticleImage")]
        public IActionResult Post([FromForm] IFormFile file)
        {

            var path = Path.Combine(_hostEnvironment.WebRootPath, "Upload", "Article");

            var newName = Guid.NewGuid() + "_" + file.FileName;

            using (FileStream fs = System.IO.File.Create(path +"/"+ newName))//注意路径里面最好不要有中文
            {
                file.CopyTo(fs);//将上传的文件文件流，复制到fs中
                fs.Flush();//清空文件流
            }
            return StatusCode(200, new { newFileName = $"{"Upload/"+"Article/"+newName}" });//将新文件文件名回传给前端


        }
    }
}

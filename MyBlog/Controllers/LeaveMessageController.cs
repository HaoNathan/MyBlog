using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.IBLL;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/leaveMessage")]
    public class LeaveMessageController : ControllerBase
    {
        private readonly ILeaveMessageManager _manager;

        public LeaveMessageController(ILeaveMessageManager manager)
        {
            _manager = manager;
      
        }
        [HttpPost]
        public async Task<IActionResult> CreateLeaveMessage([FromBody]AddLeaveMessageDto model)
        {
            var res = await _manager.CreateLeaveMessage(model)==1;
           
            return Ok(new{isSuccess=res,msg="操作成功"});
        }

        [HttpGet]
        public ActionResult<LeaveMessageDto> GetLeavMessages([FromQuery]bool isRemove)
        {
            var data = _manager.QueryLeaveMessages(isRemove).ToList();

            return Ok(data);
        }

    }
}

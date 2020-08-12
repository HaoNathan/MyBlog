using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.IBLL;
using MyBlog.MODEL;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/leaveMessage")]
    public class LeaveMessageController : ControllerBase
    {
        private readonly ILeaveMessageManager _manager;
        private readonly IMapper _mapper;

        public LeaveMessageController(ILeaveMessageManager manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaveMessage([FromBody] AddLeaveMessageDto model)
        {
            if (!TryValidateModel(model))
            {
                return ValidationProblem(ModelState);
            }

            var leaveMessage = _mapper.Map<LeaveMessage>(model);

            if (await _manager.CreateLeaveMessage(leaveMessage)!=1)
            {
                return BadRequest();
            }

            return CreatedAtRoute(nameof(GetLeaveMessages), new {isRemove = false}, leaveMessage);
        }

        [HttpGet(Name = nameof(GetLeaveMessages))]
        public ActionResult<LeaveMessageDto> GetLeaveMessages([FromQuery]bool isRemove)
        {
            var data = _manager.QueryLeaveMessages(isRemove).ToList();

            return Ok(data);
        }

    }
}

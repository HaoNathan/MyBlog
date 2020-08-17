using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Helper.PageList;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Extens;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.DTO.ParameterDto;
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
        public ActionResult<IEnumerable<LeaveMessageDto>> GetLeaveMessages([FromQuery]LeaveMessageParameter parameter)
        {
            if (parameter.IsAll)
            {
                return Ok(_manager.QueryAllMessages().ShapeData("userName,createTime,message,replyMessages"));
            }

            var data = _manager.QueryLeaveMessages(parameter);

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

        [HttpPost]
        [Route("UpdateLeaveMessageStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody]LeaveMessageDto model)
        {
             await _manager.UpdateLeaveMessageStatus(model.Id, model.IsRemove);

             return NoContent();
        }

    }
}

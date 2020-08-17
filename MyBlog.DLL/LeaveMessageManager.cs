using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Helper.PageList;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.DTO.ParameterDto;
using MyBlog.IBLL;
using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.BLL
{
    public class LeaveMessageManager:ILeaveMessageManager
    {
        private readonly ILeaveMessageService _server;
        private readonly IMapper _mapper;
        private readonly IReplyMessageManager _manager;

        public LeaveMessageManager(ILeaveMessageService service,IMapper mapper,IReplyMessageManager manager)
        {
            _server = service;
            _mapper = mapper;
            _manager = manager;
        }
        public async Task<int> CreateLeaveMessage(LeaveMessage model)
        {
            return await _server.AddAsync(model);
        }

        public PageList<LeaveMessageDto> QueryLeaveMessages(LeaveMessageParameter parameter)
        {
            var data = _server.QueryAll(true);

            if (!parameter.IsRemove)
            {
                data = data.Where(m => !m.IsRemove);
            }

            var leaveMessageDto = _mapper.Map<IEnumerable<LeaveMessageDto>>(data).ToList();

            return PageList<LeaveMessageDto>.Create(leaveMessageDto, parameter.PageNum, parameter.PageSize);

        }

        public IEnumerable<LeaveMessageDto> QueryAllMessages()
        {
            var data= _mapper.Map<IEnumerable<LeaveMessageDto>>(_server.QueryAll(true)
                .Where(m=>!m.IsRemove)).ToList();

            foreach (var leaveMessageDto in data)
            {
                var replies = _manager.QueryMessages(leaveMessageDto.Id);
                leaveMessageDto.ReplyMessages = replies;
            }

            return data.OrderByDescending(m=>m.CreateTime);
        }

        public async Task<int> UpdateLeaveMessageStatus(Guid id,bool status)
        {

            var leaveMessage = await _server.QueryAsync(id);

            leaveMessage.IsRemove = status;

            return await _server.UpdateAsync(leaveMessage);
        }
    }
}
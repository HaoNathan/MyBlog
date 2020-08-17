using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Helper.PageList;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.DTO.ParameterDto;
using MyBlog.MODEL;

namespace MyBlog.IBLL
{
    public interface ILeaveMessageManager
    {
        Task<int> CreateLeaveMessage(LeaveMessage model);

        PageList<LeaveMessageDto> QueryLeaveMessages(LeaveMessageParameter parameter);

        IEnumerable<LeaveMessageDto> QueryAllMessages();

        Task<int> UpdateLeaveMessageStatus(Guid id,bool status);

    }
}
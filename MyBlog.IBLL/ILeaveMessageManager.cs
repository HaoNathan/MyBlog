using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.MODEL;

namespace MyBlog.IBLL
{
    public interface ILeaveMessageManager
    {
        Task<int> CreateLeaveMessage(LeaveMessage model);
        IEnumerable<LeaveMessageDto> QueryLeaveMessages(bool isRemove);
    }
}
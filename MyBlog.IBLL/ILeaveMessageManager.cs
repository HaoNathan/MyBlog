using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;

namespace MyBlog.IBLL
{
    public interface ILeaveMessageManager
    {
        Task<int> CreateLeaveMessage(AddLeaveMessageDto model);
        IEnumerable<LeaveMessageDto> QueryLeaveMessages(bool isRemove);
    }
}
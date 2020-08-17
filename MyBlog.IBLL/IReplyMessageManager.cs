using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.DTO;

namespace MyBlog.IBLL
{
    public interface IReplyMessageManager
    {
        Task<int> CreateReplyMessage(ReplyMessageDto model);

        IEnumerable<ReplyMessageDto> QueryMessages(Guid id);

    }
}
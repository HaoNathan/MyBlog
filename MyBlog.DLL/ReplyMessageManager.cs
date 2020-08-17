using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyBlog.DTO;
using MyBlog.IBLL;
using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.BLL
{
    public class ReplyMessageManager:IReplyMessageManager
    {
        private readonly IReplyMessageService _service;
        private readonly IMapper _mapper;

        public ReplyMessageManager(IReplyMessageService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<int> CreateReplyMessage(ReplyMessageDto model)
        {
            return await _service.AddAsync(_mapper.Map<ReplyMessage>(model));
        }

        public IEnumerable<ReplyMessageDto> QueryMessages(Guid id)
        {
            var data = _service.QueryAll(true)
                .Where(m => m.CommentId.Equals(id))
                .OrderBy(m=>m.CreateTime);

            return _mapper.Map<IEnumerable<ReplyMessageDto>>(data);
        }
    }
}
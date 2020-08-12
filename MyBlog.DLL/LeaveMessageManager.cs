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
    public class LeaveMessageManager:ILeaveMessageManager
    {
        private readonly ILeaveMessageService _server;
        private readonly IMapper _mapper;

        public LeaveMessageManager(ILeaveMessageService service,IMapper mapper)
        {
            _server = service;
            _mapper = mapper;
        }
        public async Task<int> CreateLeaveMessage(LeaveMessage model)
        {
            return await _server.AddAsync(model);
        }

        public IEnumerable<LeaveMessageDto> QueryLeaveMessages(bool isRemove)
        {
            var data = _server.QueryAll(true);

            if (isRemove)
            {
                return _mapper.Map<IEnumerable<LeaveMessageDto>>(data);
            }

            return _mapper.Map<IEnumerable<LeaveMessageDto>>(data.Where(m => !m.IsRemove));

        }
    }
}
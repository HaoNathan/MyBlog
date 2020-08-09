using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.DAl
{
    public class LeaveMessageService:BaseService<LeaveMessage>,ILeaveMessageService
    {
        public LeaveMessageService(MyBlogContext context) : base(context)
        {
        }
    }
}
using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.DAl
{
    public class ReplyMessageService:BaseService<ReplyMessage>,IReplyMessageService
    {
        public ReplyMessageService( MyBlogContext context ):base(context)
        {
            
        }
    }
}
using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.DAl
{
    public class AdminService:BaseService<Admin>,IAdminService
    {
        public AdminService(MyBlogContext context) : base(context)
        {
        }
    }
}
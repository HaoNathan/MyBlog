using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.DAl
{
    public class PictureWallService:BaseService<PictureWall>,IPictureWallService
    {
        public PictureWallService(MyBlogContext context) : base(context)
        {
        }
    }
}
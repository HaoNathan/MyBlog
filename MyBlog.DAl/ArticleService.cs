using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.DAl
{
    public class ArticleService:BaseService<Articles>,IArticleService
    {

        public ArticleService(MyBlogContext context) : base(context)
        {

        }

    }
}
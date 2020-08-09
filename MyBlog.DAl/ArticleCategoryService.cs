using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.DAl
{
    public class ArticleCategoryService:BaseService<ArticleCategory>,IArticleCategoryService
    {
        public ArticleCategoryService(MyBlogContext context) : base(context)
        {
        }
    }
}
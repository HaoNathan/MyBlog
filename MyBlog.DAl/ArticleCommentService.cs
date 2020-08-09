using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.DAl
{
    public class ArticleCommentService:BaseService<ArticleComment>,IArticleCommentService
    {

        public ArticleCommentService(MyBlogContext context) : base(context)
        {

        }


    }
}
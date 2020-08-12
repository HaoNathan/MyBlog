using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.DTO;
using MyBlog.MODEL;

namespace MyBlog.IBLL
{
    public interface IArticleCommentManager
    {
        Task<int> CreateArticleComment(ArticleComment model);
        IEnumerable<ArticleCommentDto> QueryArticleComments(Guid articleId,bool isRemove);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Helper.PageList;
using MyBlog.DTO;
using MyBlog.DTO.ParameterDto;
using MyBlog.MODEL;

namespace MyBlog.IBLL
{
    public interface IArticleCommentManager
    {
        Task<int> CreateArticleComment(ArticleComment model);
        IEnumerable<ArticleCommentDto> QueryArticleComments(Guid articleId,bool isRemove);
        PageList<ArticleCommentDto> QueryAllArticleComments(ArticleCommentParameter parameter);

        Task<int> UpdateArticleCommentStatus(Guid id, bool status);

    }
}
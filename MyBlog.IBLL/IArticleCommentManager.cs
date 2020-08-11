using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;

namespace MyBlog.IBLL
{
    public interface IArticleCommentManager
    {
        Task<int> CreateArticleComment(AddArticleCommentDto model);
        IEnumerable<ArticleCommentDto> QueryArticleComments(Guid articleId,bool isRemove);
    }
}
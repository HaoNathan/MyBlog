using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;

namespace MyBlog.IBLL
{
    public interface IArticleManager
    {
        Task<int> CreateArticle(AddArticleDto model);

        IEnumerable<ArticleDto> QueryArticles(bool isRemove, bool isNoTracking);
    }
}

using System;
using System.Threading.Tasks;
using MyBlog.BLL.Helper;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.DTO.ParameterDto;

namespace MyBlog.IBLL
{
    public interface IArticleManager
    {
        Task<int> CreateArticle(AddArticleDto model);

        Task<PageList<ArticleDto>> QueryArticles(ArticleParameter parameter);

        Task<ArticleDto> QueryArticle(Guid id);

    }
}

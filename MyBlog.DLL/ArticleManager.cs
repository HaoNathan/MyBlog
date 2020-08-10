using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyBlog.BLL.Helper;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.DTO.ParameterDto;
using MyBlog.IBLL;
using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.BLL
{
    public class ArticleManager:IArticleManager
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticleManager( IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        public async Task<int> CreateArticle(AddArticleDto model)
        {
            var article = _mapper.Map<Articles>(model);

            return await _articleService.AddAsync(article);
        }

        public async Task<PageList<ArticleDto>> QueryArticles(ArticleParameter parameter)
        {
            var data = _articleService.QueryAll(true) as IQueryable<Articles>;

            if (data==null)
                return null;

            if (!string.IsNullOrWhiteSpace(parameter.Id.ToString()))
            {
                data = data .Where(m => m.Id.Equals(parameter.Id));
            }

            if (!parameter.IsRemove)
            {
                data = data.Where(m=>!m.IsRemove);
            }

            if (string.IsNullOrWhiteSpace(parameter.Search))
            {
                data = data.Where(m => m.Title.Contains(parameter.Search));
            }

            var articles = _mapper.Map<IQueryable<ArticleDto>>(data);

            return await PageList<ArticleDto>.Create(articles, parameter.PageNum, parameter.PageSize);
        }

        public async Task<ArticleDto> QueryArticle(Guid id)
        {
            var article = await _articleService.QueryAsync(id);

            return _mapper.Map<ArticleDto>(article);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
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

        public IEnumerable<ArticleDto> QueryArticles(bool isRemove, bool isNoTracking)
        {
            List<Articles> list;

            if (isRemove)
            {
                list = _articleService.QueryAll(isNoTracking).ToList();
                return _mapper.Map<List<ArticleDto>>(list);
            }


            list = _articleService.QueryAll(isNoTracking).Where(m => !m.IsRemove).ToList();

            return _mapper.Map<List<ArticleDto>>(list);

        }
    }
}

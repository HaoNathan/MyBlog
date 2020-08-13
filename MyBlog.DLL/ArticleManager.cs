using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Helper.PageList;
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
        private readonly IArticleCategoryManager _categoryService;
        private readonly IArticleCommentService _commentService;


        public ArticleManager( IArticleService articleService, IMapper mapper
            ,IArticleCategoryManager categoryService
            ,IArticleCommentService commentService)
        {
            _articleService = articleService;
            _mapper = mapper;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public async Task<int> CreateArticle(AddArticleDto model)
        {
            var article = _mapper.Map<Articles>(model);

            return await _articleService.AddAsync(article);
        }

        public async Task< PageList<ArticleDto>> QueryArticles(ArticleParameter parameter)
        {
            var data = _articleService.QueryAll(true);

            if (data==null)
                return null;

            if (parameter.Id!=Guid.Empty)
            {
                data = data .Where(m => m.ArticleCategoryId.Equals(parameter.Id));
            }


            if (!parameter.IsRemove)
            {
                data = data.Where(m=>!m.IsRemove);
            }

            if (!string.IsNullOrWhiteSpace(parameter.CategoryName))
            {
                var category = await _categoryService.QueryCategory(parameter.CategoryName);

                data = data.Where(m => m.ArticleCategoryId.Equals(category.CategoryId));
            }

            if (!string.IsNullOrWhiteSpace(parameter.Search))   
            {
                data = data.Where(m => m.Title.Contains(parameter.Search));
            }

            var articles = _mapper.Map<IEnumerable<ArticleDto>>(data).ToList();

            if (parameter.IsOrder)
            {
                articles = articles.OrderByDescending(m => m.CreateTime).ToList();
            }
            else
            {
                foreach (var articleDto in articles)
                {
                    articleDto.CommentCount = _commentService.QueryAll(true)
                        .Count(m=>m.ArticleId.Equals(articleDto.Id) && !m.IsRemove);
                }

                articles=  articles.OrderByDescending(m => m.CommentCount).ToList();
            }

            return  PageList<ArticleDto>.Create(articles, parameter.PageNum, parameter.PageSize);
        }

        public async Task<ArticleDto> QueryArticle(Guid id)
        {
            var article = await _articleService.QueryAsync(id);

            return _mapper.Map<ArticleDto>(article);
        }
    }
}

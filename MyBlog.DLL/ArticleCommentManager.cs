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
    public class ArticleCommentManager:IArticleCommentManager
    {
        private readonly IMapper _mapper;
        private readonly IArticleCommentService _service;

        public ArticleCommentManager(IMapper mapper,IArticleCommentService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<int> CreateArticleComment(AddArticleCommentDto model)
        {
            return await _service.AddAsync(_mapper.Map<ArticleComment>(model));
        }

        public IEnumerable<ArticleCommentDto> QueryArticleComments(Guid articleId, bool isRemove)
        {

            var data = _service.QueryAll(true);

            if (isRemove)
                return _mapper.Map<IEnumerable<ArticleCommentDto>>(
                    data.Where(m => m.ArticleId.Equals(articleId)));

            return _mapper.Map<IEnumerable<ArticleCommentDto>>(data.Where(m =>
                m.ArticleId.Equals(articleId) && !m.IsRemove));
        }
    }
}
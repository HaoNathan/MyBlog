using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Helper.PageList;
using MyBlog.BLL.Extens;
using MyBlog.DTO;
using MyBlog.DTO.ParameterDto;
using MyBlog.IBLL;
using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.BLL
{
    public class ArticleCommentManager:IArticleCommentManager
    {
        private readonly IMapper _mapper;
        private readonly IArticleCommentService _service;
        private readonly IReplyMessageManager _manager;

        public ArticleCommentManager(IMapper mapper,IArticleCommentService service,IReplyMessageManager manager)
        {
            _mapper = mapper;
            _service = service;
            _manager = manager;
        }
        public async Task<int> CreateArticleComment(ArticleComment model)
        {
            return await _service.AddAsync(model);
        }

        public IEnumerable<ArticleCommentDto> QueryArticleComments(Guid articleId, bool isRemove)
        {

            var data = _service.QueryAll(true);

            if (isRemove)
                data= data.Where(m => m.ArticleId.Equals(articleId));

            data = data.Where(m =>
                m.ArticleId.Equals(articleId) && !m.IsRemove).OrderByDescending(m=>m.CreateTime);

            var articleComments= _mapper.Map<IEnumerable<ArticleCommentDto>>(data).ToList();

            foreach (var item in articleComments)
            {
                var replies = _manager.QueryMessages(item.Id);

                item.ReplyMessages = replies;
            }

            return articleComments;
        }

        public PageList<ArticleCommentDto> QueryAllArticleComments(ArticleCommentParameter parameter)
        {
            var data = _service.QueryAll(true);

            var commentsDto = _mapper.Map<IEnumerable<ArticleCommentDto>>(data).ToList();

            return PageList<ArticleCommentDto>.Create(commentsDto,parameter.PageNum,parameter.PageSize);
        }

        public async Task<int> UpdateArticleCommentStatus(Guid id, bool status)
        {
            var articleComment = await _service.QueryAsync(id);

            articleComment.IsRemove = status;

            return await _service.UpdateAsync(articleComment);
        }
    }
}
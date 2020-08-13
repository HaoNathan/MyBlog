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
using MyBlogDTO;

namespace MyBlog.BLL
{
    public class ArticleCategoryManager:IArticleCategoryManager
    {
        private readonly IArticleCategoryService _service;
        private readonly IMapper _mapper;

        public ArticleCategoryManager(IArticleCategoryService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<int> CreateCategory(AddArticleCategoryDto model)
        {
            var category = _mapper.Map<ArticleCategory>(model);

            return await _service.AddAsync(category);
        }

        public IEnumerable<ArticleCategoryDto> QueryAll(bool isRemove, bool isNoTracking)
        {
            if (isRemove)
            {
                var data = _service.QueryAll(isNoTracking);

                return _mapper.Map<IEnumerable<ArticleCategoryDto>>(data);
            }

            var data2 = _service.QueryAll(isNoTracking).Where(m=>!m.IsRemove);

            return _mapper.Map<IEnumerable<ArticleCategoryDto>>(data2);
        }

        public async Task<ArticleCategoryDto> QueryCategory(string name)
        {
            var category = await _service.QueryAsync(m => m.CategoryName.Equals(name));

            return _mapper.Map<ArticleCategoryDto>(category);
        }


        public async Task<int> UpdateCategoryState(Guid id)
        {
            var category = await _service.QueryAsync(m => m.Id.Equals(id));

            category.IsRemove = true;

            return await _service.UpdateAsync(category);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlogDTO;

namespace MyBlog.IBLL
{
    public interface IArticleCategoryManager
    {
        Task<int> CreateCategory(AddArticleCategoryDto model);

        IEnumerable<ArticleCategoryDto> QueryAll(bool isRemove,bool isNoTracking);

        Task<ArticleCategoryDto> QueryCategory(string name);

        Task<int> UpdateCategoryState(Guid id);

    }


}
using System;

namespace MyBlog.DTO.ParameterDto
{
    public class ArticleParameter
    {
        private const int MaxPageSize = 10;
        public Guid Id { get; set; }
        public string Search { get; set; }
        public int PageNum { get; set; } = 1;
        public bool IsRemove { get; set; }
        private int _pageSize = 5;

        public string Fields { get; set; }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string OrderBy { get; set; } = "CreateTime";
    }
}
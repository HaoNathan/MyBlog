using System;

namespace MyBlog.DTO
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
      
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid ArticleCategoryId { get; set; }
    }
}
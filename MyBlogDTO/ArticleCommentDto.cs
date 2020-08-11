using System;

namespace MyBlog.DTO
{
    public class ArticleCommentDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Contact { get; set; }

        public string Comment { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
using System;
using System.Collections.Generic;

namespace MyBlog.DTO
{
    public class ArticleCommentDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Contact { get; set; }

        public string Message { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid ArticleId { get; set; }

        public bool IsRemove { get; set; }

        public IEnumerable<ReplyMessageDto> ReplyMessages { get; set; }

    }
}
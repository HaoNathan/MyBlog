using System;

namespace MyBlog.DTO
{
    public class ReplyMessageDto
    {
        public Guid CommentId { get; set; }
        public string Message { get; set; }
    }
}
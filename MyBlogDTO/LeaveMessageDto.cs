using System;

namespace MyBlog.DTO
{
    public class LeaveMessageDto
    {
        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }

        public string UserName { get; set; }

        public string Message { get; set; }
    }
}
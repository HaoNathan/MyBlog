using System;

namespace MyBlog.MODEL
{
    public class BaseEntity
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}
using System;

namespace MyBlog.MODEL
{
    public class BaseEntity
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public DateTime CreateTime { get; set; }=DateTime.Now;
        public DateTime UpdateTime { get; set; }=DateTime.Now;
        public bool IsRemove { get; set; }
    }
}
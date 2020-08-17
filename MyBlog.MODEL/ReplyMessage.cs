using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.MODEL
{
   public class ReplyMessage:BaseEntity
    {
        [DisplayName("回复信息")]
        [Column(TypeName = "varchar(100)")]
        [StringLength(maximumLength:100,ErrorMessage = "{0}的长度不能超过{1}")]
        public string Message { get; set; }

        public Guid CommentId { get; set; }

    }
}

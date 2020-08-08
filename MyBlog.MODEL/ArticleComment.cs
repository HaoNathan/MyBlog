using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.MODEL
{
    public class ArticleComment:BaseEntity
    {
        [Required]
        [DisplayName("留言")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0}最大长度为{1}")]
        public string Message { get; set; }

        [ForeignKey(nameof(Article))]
        public Guid ArticleId { get; set; }
        public Articles Article { get; set; }
    }
}
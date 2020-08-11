using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.DTO.AddViewDto
{
    public class AddArticleCommentDto
    {
        [Required]
        [DisplayName("评论")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0}最大长度为{1}")]
        public string Comment { get; set; }

        [Required]
        [DisplayName("访客昵称")]
        [Column(TypeName = "nvarchar(10)")]
        [StringLength(maximumLength: 10, ErrorMessage = "{0}最大长度为{1}")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("联系方式")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0}最大长度为{1}")]
        public string Contact { get; set; }

        public Guid ArticleId { get; set; }
    }
}
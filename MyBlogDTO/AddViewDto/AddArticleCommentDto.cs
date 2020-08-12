using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.DTO.AddViewDto
{
    public class AddArticleCommentDto
    {
        [Required]
        [DisplayName("评论")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0}最大长度为{1}")]
        public string Message { get; set; }

        [Required]
        [DisplayName("访客昵称")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0}最大长度为{1}")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("联系方式")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0}最大长度为{1}")]
        public string Contact { get; set; }

        public Guid ArticleId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.DTO.AddViewDto
{
    public class AddArticleDto
    {
        [Required]
        [DisplayName("文章标题")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0}最大长度为{1}")]
        public string Title { get; set; }


        [Required]
        [DisplayName("封面图片")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0}最大长度为{1}")]
        public string ImageUrl { get; set; }

        [Required]
        [DisplayName("文章说明")]
        [StringLength(maximumLength: 200, ErrorMessage = "{0}最大长度为{1}")]
        public string Description { get; set; }

        [Required]
        [DisplayName("文章内容")]
        public string Content { get; set; }
        public Guid ArticleCategoryId { get; set; }
    }
}

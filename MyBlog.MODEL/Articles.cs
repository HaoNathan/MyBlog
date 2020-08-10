using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.MODEL
{
    public class Articles:BaseEntity
    {
        [Required]
        [DisplayName("文章标题")]
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0}最大长度为{1}")]
        public string Title { get; set; }


        [Required]
        [DisplayName("封面图片")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0}最大长度为{1}")]
        public string ImageUrl { get; set; }


        [Required]
        [DisplayName("文章内容")]
        [Column(TypeName = "MEDIUMBLOB")]
        public string Content { get; set; }

        [Required]
        [DisplayName("文章描述")]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
    
         [ForeignKey(nameof(ArticleCategory))]
        public Guid ArticleCategoryId { get; set; }
        public ArticleCategory ArticleCategory { get; set; }
    }
}
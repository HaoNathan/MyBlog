using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.MODEL
{
    public class ArticleCategory:BaseEntity
    {
        [Required]
        [DisplayName("文章类别")]
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0}最大长度为{1}")]
        public string CategoryName { get; set; }

    }
}
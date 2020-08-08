using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.MODEL
{
    public class PictureWall:BaseEntity
    {
        [Required]
        [DisplayName("图片路径")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(maximumLength:100,ErrorMessage = "{0}最大长度为{1}")]
        public string ImageUrl { get; set; }
    }
}
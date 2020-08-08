using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.MODEL
{
    public class LeaveMessage:BaseEntity
    {
        [Required]
        [DisplayName("留言")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0}最大长度为{1}")]
        public string Message { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.MODEL
{
    public class Admin:BaseEntity
    {
        [Required]
        [DisplayName("用户名")]
        [Column(TypeName = "nvarchar(20)")]
        [StringLength(20,MinimumLength = 10,ErrorMessage = "{0}长度为{2}到{1}之间")]
        public string Name { get; set; }

        [Required]
        [DisplayName("密码")]
        [Column(TypeName = "nvarchar(20)")]
        [StringLength(20,MinimumLength = 10, ErrorMessage = "{0}长度为{2}到{1}之间")]
        public string Password { get; set; }

    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.DTO.AddViewDto
{
    public class AddLeaveMessageDto
    {
        [Required]
        [DisplayName("留言")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0}最大长度为{1}")]
        public string Message { get; set; }

        [Required]
        [DisplayName("访客名")]
        [StringLength(maximumLength: 10, ErrorMessage = "{0}最大长度为{1}")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("联系方式")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0}最大长度为{1}")]
        public string Contact { get; set; }
    }
}
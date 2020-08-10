using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.DTO.AddViewDto
{
    public class AddArticleCategoryDto
    {
        [Required]
        [DisplayName("类别名")]
        [StringLength(45,MinimumLength = 2,ErrorMessage = "{0}的长度是{2}到{1}")]
        public string CategoryName { get; set; }
    }
}
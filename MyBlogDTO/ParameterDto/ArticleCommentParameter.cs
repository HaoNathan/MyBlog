namespace MyBlog.DTO.ParameterDto
{
    public class ArticleCommentParameter
    {
        public int PageNum { get; set; } = 1;

        public bool IsRemove { get; set; }

        public bool IsOrder { get; set; }

        public int PageSize { get; set; } = 10;
    }
}
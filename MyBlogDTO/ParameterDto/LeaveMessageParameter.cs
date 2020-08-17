namespace MyBlog.DTO.ParameterDto
{
    public class LeaveMessageParameter
    {
        public int PageNum { get; set; } = 1;

        public bool IsRemove { get; set; }

        public bool IsOrder { get; set; }

        public bool IsAll { get; set; }

        public int PageSize { get; set; } = 10;

    }
}
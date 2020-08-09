using System.Threading.Tasks;
using MyBlogDTO;

namespace MyBlog.IBLL
{
    public interface IAdminManager
    {
        Task<bool> Login(AdminDto model);
    }
}
using System.Linq;
using System.Threading.Tasks;
using MyBlog.IBLL;
using MyBlog.IDAL;
using MyBlogDTO;

namespace MyBlog.BLL
{
    public class AdminManager:IAdminManager
    {
        private readonly IAdminService _service;

        public AdminManager(IAdminService service)
        {
            _service = service;
        }

        public async Task<bool> Login(AdminDto model)
        {
            var result = await _service.QueryAsync(m => m.Name.Equals(model.Name)
                                                        && m.Password.Equals(model.Password));
            if (result == null)
                return false;

            return true;
        }
    }
}
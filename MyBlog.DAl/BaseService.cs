using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.IDAL;
using MyBlog.MODEL;

namespace MyBlog.DAl
{
    public class BaseService<T>:IBaseService<T> where T :BaseEntity,new()
    {
        private readonly MyBlogContext _context;

        public BaseService(MyBlogContext context )
        {
            _context = context;
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> AddAsync(T model)
        {
            await _context.AddAsync(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T model)
        {
             _context.Update(model);
             return await _context.SaveChangesAsync();
        }

        public IEnumerable<T> QueryAsync()
        {
            return _context.Set<T>();
        }
    }
}
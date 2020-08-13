using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<T> QueryAll(bool isNoTracking)
        {
            if (isNoTracking)
                return _context.Set<T>().AsNoTracking();

            return _context.Set<T>();

        }
        public async Task<T> QueryAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(m=>m.Id.Equals(id));
        }

        public async Task<T> QueryAsync(Expression<Func<T, bool>> lambdaFunc)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(lambdaFunc);
        }
    }
}
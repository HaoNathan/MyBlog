using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyBlog.MODEL;

namespace MyBlog.IDAL
{
    public interface IBaseService<T>:IDisposable where T : BaseEntity, new()
    {
        Task<int> AddAsync(T model);

        Task<int> UpdateAsync(T model);

        IEnumerable<T> QueryAll(bool isNoTracking);

        Task<T> QueryAsync(Guid id);

        Task<T> QueryAsync(Expression<Func<T,bool>>lambdaFunc);
    }
}

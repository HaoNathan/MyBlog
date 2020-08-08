using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.MODEL;

namespace MyBlog.IDAL
{
    public interface IBaseService<T>:IDisposable where T : BaseEntity, new()
    {
        Task<int> AddAsync(T model);

        Task<int> UpdateAsync(T model);

        IEnumerable<T> QueryAsync();

    }
}

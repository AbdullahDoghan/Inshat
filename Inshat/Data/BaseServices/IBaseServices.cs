using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Data.BaseServices
{
  
    public interface IBaseServices<T, Key> : BaseEntity<Key>  where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Key id);
        Task CreateAsync(T entity);
        Task UpdateAsync(Key Id, T entity);
        Task DeleteAsync(Key Id);
    }
}

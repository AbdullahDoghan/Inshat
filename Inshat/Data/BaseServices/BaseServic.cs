using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Data.BaseServices
{
    public class BaseServic<T,Key> : IBaseServices<T,Key> where T : class
    {
        private readonly DbContextConfig _db;
        public BaseServic(DbContextConfig db)
        {
            _db = db;
        }

        public Key Id { get ; set ; }

        public async Task CreateAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Key id)
        {
           var entity= await _db.Set<T>().FindAsync(id);
            _db.Remove(entity);
            await _db.SaveChangesAsync();

        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await _db.Set<T>().ToListAsync();
            return data;
        }

        public async Task<T> GetByIdAsync(Key id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            return entity;

        }

        public async Task UpdateAsync(Key id, T entity)
        {
            EntityEntry entityEntry = _db.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}

using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly CaveServiceContext database;

        public Repository(CaveServiceContext context)
        {
            database = context;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await database.Set<T>()
                                 .FindAsync(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return database.Set<T>()
                           .AsNoTracking();
        }

        public virtual async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public virtual IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return database.Set<T>()
                           .Where(predicate)
                           .AsNoTracking();
        }

        public virtual async Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                database.Set<T>().Add(entity);
                await database.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            try
            {
                database.Set<T>().Remove(entity);
                await database.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(int id)
        {
                var entity = await GetById(id);
                if (entity == null) return null;
                return await Delete(entity);
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                database.Entry(entity).State = EntityState.Modified;
                await database.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        private async Task<bool> Exists(int id)
        {
            return await database.Set<T>().AnyAsync(entity => entity.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreSQLiteXamFormsApp.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp.Services
{
    public class LocalDataBaseService<T> : ILocalDataBaseService<T>
        where T: BaseModel
    {
        private IDbContext DbAccessService => DependencyService.Get<IDbContext>();
        protected DataBaseContext DbContext => DbAccessService.DbContext;
        protected DbSet<T> DbSet => DbContext.Set<T>();


        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public  async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
        }
    }
}

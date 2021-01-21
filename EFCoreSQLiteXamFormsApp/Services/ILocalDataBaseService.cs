using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreSQLiteXamFormsApp.Services
{
    public interface ILocalDataBaseService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task AddRangeAsync(List<T> entities);
    }
}

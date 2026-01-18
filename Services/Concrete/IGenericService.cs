using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<PagedResault<T>> GetAllAsync();   // Query → veri döner
        Task<T> GetByIdAsync(int id);          // Query → veri döner
        Task AddAsync(T entity);               // Command → değer dönmez
        Task UpdateAsync(T entity);            // Command → değer dönmez
        IQueryable<T> Query();
    }
}

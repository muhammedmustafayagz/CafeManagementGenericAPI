using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstarct
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly RepositoryContext _context;
        public GenericRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity); // belleğe ekler 
            await _context.SaveChangesAsync(); // değişiklikleri db ye kaydeder
            // command metot değer döndürmez
        }

        public async Task<PagedResault<T>> GetAllAsync()
        {
            var query = _context.Set<T>().AsQueryable(); // asqueryble sorgulanailir hale getirir 
            var items = await query.ToListAsync(); // listeye çevirir dbden veri çeker 
            var totalCount = items.Count; // toplam sayıyı alır
            return new PagedResault<T>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity); // bellekte günceller
            await _context.SaveChangesAsync(); // değişiklikleri db ye kaydeder
        }

        public async Task DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            _context.Set<T>().Update(entity); // bellekte günceller
            await _context.SaveChangesAsync(); // değişiklikleri db ye kaydeder
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }
    }


}

using Entities.Model;
using Repository.Concrete;
using Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstarct
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> repository) 
        {
            _repository = repository; // service repoyu kenndi üretmiyececek dışarıdan alıcak 
        }
        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<PagedResault<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
      
        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IQueryable<T> Query()
        {
            return _repository.Query();
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}

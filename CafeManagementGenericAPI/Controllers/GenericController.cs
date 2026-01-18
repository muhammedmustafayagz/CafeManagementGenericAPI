using CafeManagementGenericAPI.Extensions;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Concrete;

namespace CafeManagementGenericAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T> : ControllerBase where T : BaseEntity
    {
        private readonly IGenericService<T> _service;
        public GenericController(IGenericService<T> service)
        {
            _service = service;
        }
        [HttpGet("paged")]
        public IActionResult GetPaged([FromQuery] PaginationModel pagination)
        {
            var query = _service.Query();

            var totalCount = query.Count();

            var items = query
                .ApplyPagination(pagination.PageNumber, pagination.PageSize)
                .ToList();

            var result = new PagedResault<T>
            {
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                Items = items
            };

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(); // 404 döner 
            }
            return Ok(entity); // 200 döner
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] T entity)
        {
            try
            {
                await _service.AddAsync(entity);
                return Ok(); // sadece başaralı olduğunu döner
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] T entity)
        {
            try
            {
                await _service.UpdateAsync(entity);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] T entity)
        {
            try
            {
                entity.IsDeleted = true;
                await _service.UpdateAsync(entity);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
   
}

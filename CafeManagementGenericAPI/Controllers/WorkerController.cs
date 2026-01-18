using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Concrete;

namespace CafeManagementGenericAPI.Controllers
{
    public class WorkerController : GenericController<Worker>
    {
        public WorkerController(IGenericService<Worker> service) : base(service)
        {
        }
    }
}

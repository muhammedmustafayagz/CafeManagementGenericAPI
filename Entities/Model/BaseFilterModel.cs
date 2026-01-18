using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class BaseFilterModel
    {
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }

        public string? CreatedBy { get; set; }
    }
}

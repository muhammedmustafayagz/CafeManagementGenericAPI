using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class PagedResault<T>
    {
        public int TotalCount { get; set; } // Toplam kayıt sayısı
        public int PageNumber { get; set; } // aktif sayfa 
        public int PageSize { get; set; } // sayfa başına gelen kayıt sayısı
        public List<T> Items { get; set; } // gelen kayıtlar 
    }
}

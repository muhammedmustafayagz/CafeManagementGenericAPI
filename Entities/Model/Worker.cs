using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
   public class Worker : BaseEntity
    {
        public int Id { get; set; }
        public string Name   { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Mission { get; set; }
    }
}

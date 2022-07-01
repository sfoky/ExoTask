using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCategory { get; set; }
        public int IdPerson { get; set; }
        public string Descr { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndingDateMax { get; set; }
        public DateTime? EndingDate { get; set; }
    }
}

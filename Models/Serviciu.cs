using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chis_Denisa_Proiect1.Models
{
    public class Serviciu
    {
        public int ID { get; set; }
        public string NumeServiciu { get; set; }
        public ICollection<ProgramareServiciu> ProgramareServicii { get; set; }
    }
}

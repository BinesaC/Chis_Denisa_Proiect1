using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chis_Denisa_Proiect1.Models
{
    public class ProgramareServiciu
    {
        public int ID { get; set; }
        public int ProgramareID { get; set; }
        public Programare Programare { get; set; }
        public int ServiciuID { get; set; }
        public Serviciu Serviciu { get; set; }
    }
}

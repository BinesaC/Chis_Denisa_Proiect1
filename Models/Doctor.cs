using Chis_Denisa_Proiect1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chis_Denisa_Proiect1.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string NumeDoctor { get; set; }
        public ICollection<Programare> Programari { get; set; }
    }
}

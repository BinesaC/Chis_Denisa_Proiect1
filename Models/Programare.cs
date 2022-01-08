using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chis_Denisa_Proiect1.Models
{
    public class Programare
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Animal")]

        public string Animal { get; set; }
        public string Contact { get; set; }
        [Range(1, 300)]

        [Column(TypeName = "decimal(6, 2)")]

        public decimal Pret { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<ProgramareServiciu> ProgramareServicii { get; set; }
    }
}

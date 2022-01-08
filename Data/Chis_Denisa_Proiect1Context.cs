using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chis_Denisa_Proiect1.Models;

namespace Chis_Denisa_Proiect1.Data
{
    public class Chis_Denisa_Proiect1Context : DbContext
    {
        public Chis_Denisa_Proiect1Context (DbContextOptions<Chis_Denisa_Proiect1Context> options)
            : base(options)
        {
        }

        public DbSet<Chis_Denisa_Proiect1.Models.Programare> Programare { get; set; }

        public DbSet<Chis_Denisa_Proiect1.Models.Doctor> Doctor { get; set; }

        public DbSet<Chis_Denisa_Proiect1.Models.Serviciu> Serviciu { get; set; }
    }
}

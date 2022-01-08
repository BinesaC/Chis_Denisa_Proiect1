using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chis_Denisa_Proiect1.Data;
using Chis_Denisa_Proiect1.Models;

namespace Chis_Denisa_Proiect1.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context _context;

        public IndexModel(Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get; set; }
        public ProgramareData ProgramareD { get; set; }
        public int ID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? serviciuID)
        {
            {
                ProgramareD = new ProgramareData();

                Programare = await _context.Programare
                    .Include(b => b.Doctor)
                    .Include(b => b.ProgramareServicii)
                    .ThenInclude(b => b.Serviciu)
                    .AsNoTracking()
                    .OrderBy(b => b.Animal)
                    .ToListAsync();
            }
        }
    }
}

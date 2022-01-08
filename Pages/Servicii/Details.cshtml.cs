using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chis_Denisa_Proiect1.Data;
using Chis_Denisa_Proiect1.Models;

namespace Chis_Denisa_Proiect1.Pages.Servicii
{
    public class DetailsModel : PageModel
    {
        private readonly Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context _context;

        public DetailsModel(Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context context)
        {
            _context = context;
        }

        public Serviciu Serviciu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);

            if (Serviciu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

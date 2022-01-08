using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chis_Denisa_Proiect1.Data;
using Chis_Denisa_Proiect1.Models;

namespace Chis_Denisa_Proiect1.Pages.Servicii
{
    public class EditModel : PageModel
    {
        private readonly Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context _context;

        public EditModel(Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Serviciu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciuExists(Serviciu.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ServiciuExists(int id)
        {
            return _context.Serviciu.Any(e => e.ID == id);
        }
    }
}

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


namespace Chis_Denisa_Proiect1.Pages.Programari

{
    public class EditModel : ProgramareServiciuModell
    {
        private readonly Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context _context;
        public EditModel(Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context context)
        {
            _context = context;
        }
        [BindProperty]
        public Programare Programare { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Programare = await _context.Programare
            .Include(b => b.Doctor)
            .Include(b => b.ProgramareServicii).ThenInclude(b => b.Serviciu)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Programare == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulareServiciuAlocat(_context, Programare);
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "ID",
           "NumeDoctor");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
       selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookToUpdate = await _context.Programare
 .Include(i => i.Doctor)
 .Include(i => i.ProgramareServicii)
 .ThenInclude(i => i.Serviciu)
 .FirstOrDefaultAsync(s => s.ID == id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Programare>(
            bookToUpdate,
            "Programare",
            i => i.Animal, i => i.Contact,
            i => i.Pret, i => i.Data, i => i.Doctor))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulareServiciuAlocat(_context, bookToUpdate);
            return Page();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chis_Denisa_Proiect1.Data;
using Chis_Denisa_Proiect1.Models;

namespace Chis_Denisa_Proiect1.Pages.Programari
{
    public class CreateModel : ProgramareServiciuModell
    {
        private readonly Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context _context;
        public CreateModel(Chis_Denisa_Proiect1.Data.Chis_Denisa_Proiect1Context context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "ID",
           "NumeDoctor");

            var Programare = new Programare();
            Programare.ProgramareServicii = new List<ProgramareServiciu>();
            PopulareServiciuAlocat(_context, Programare);
            return Page();
        }
        [BindProperty]
        public Programare programare { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedServicii)
        {
            var newProgramare = new Programare();
            if (selectedServicii != null)
            {
                newProgramare.ProgramareServicii = new List<ProgramareServiciu>();
                foreach (var cat in selectedServicii)
                {
                    var catToAdd = new ProgramareServiciu
                    {
                        ServiciuID = int.Parse(cat)
                    };
                    newProgramare.ProgramareServicii.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Programare>( newProgramare, "Programare", i => i.Animal, i => i.Contact,i => i.Pret, i => i.Data, i => i.DoctorID))
            {
                _context.Programare.Add(newProgramare);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulareServiciuAlocat(_context, newProgramare);
            return Page();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Chis_Denisa_Proiect1.Data;

namespace Chis_Denisa_Proiect1.Models
{
    public class ProgramareServiciuModell : PageModel
    {
        public List<ServiciuAlocat> ListaServiciuAlocat;
        public void PopulareServiciuAlocat(Chis_Denisa_Proiect1Context context,
        Programare Programare)
        {
            var allServicii = context.Serviciu;
            var ProgramareServicii = new HashSet<int>(
            Programare.ProgramareServicii.Select(c => c.ServiciuID)); //
            ListaServiciuAlocat = new List<ServiciuAlocat>();
            foreach (var cat in allServicii
                )
            {
                ListaServiciuAlocat.Add(new ServiciuAlocat
                {
                    ServiciuID = cat.ID,
                    Nume = cat.NumeServiciu,
                    Alocare = ProgramareServicii.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(Chis_Denisa_Proiect1Context context,
        string[] selectedCategories, Programare programareToUpdate)
        {
            if (selectedCategories == null)
            {
                programareToUpdate.ProgramareServicii = new List<ProgramareServiciu>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (programareToUpdate.ProgramareServicii.Select(c => c.Serviciu.ID));
            foreach (var cat in context.Serviciu)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        programareToUpdate.ProgramareServicii.Add(
                        new ProgramareServiciu
                        {
                            ID = programareToUpdate.ID,
                            ServiciuID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        ProgramareServiciu courseToRemove
                        = programareToUpdate
                        .ProgramareServicii
                       .SingleOrDefault(i => i.ServiciuID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
            
    


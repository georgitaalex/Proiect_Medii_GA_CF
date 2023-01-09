using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Models;

namespace WEB.Pages.Sporturi
{
    public class EditModel : CategorieSportPageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public EditModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sport Sport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sport = await _context.Sport
            .Include(b => b.Instructor)
            .Include(b => b.Locatie)
           .Include(b => b.CategoriiSport).ThenInclude(b => b.Categorie)
           .Include(b => b.Locatie)
           .AsNoTracking()
           .FirstOrDefaultAsync(m => m.ID == id);

            if (Sport == null)
            {
                return NotFound();
            }

            PopuleazaCategorieAtribuita(_context, Sport);
            var InstructorList = _context.Instructor.Select(x => new
            {
                x.ID,
                FullName = x.Nume + " " + x.Prenume
            });

            ViewData["InstructorID"] = new SelectList(InstructorList, "ID", "FullName");
            ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "NumeSala");


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] categoriiSelectate)  {
            if (id == null)
            {
                return NotFound();
            }

            var sportToUpdate = await _context.Sport
            .Include(i => i.Locatie)
            .Include(i => i.Instructor)
            .Include(i => i.CategoriiSport)
            .ThenInclude(i => i.Categorie)
            .Include(i => i.Instructor)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (sportToUpdate == null)
            {
                return NotFound();
            }
           
            if (await TryUpdateModelAsync<Sport>(sportToUpdate,"Sport",
            i => i.NumeSport, i => i.Instructor, i => i.Pret, i => i.Locatie, i => i.Durata))
            {
                UpdateCategoriiSport(_context, categoriiSelectate, sportToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCategoriiSport(_context, categoriiSelectate, sportToUpdate);

            PopuleazaCategorieAtribuita(_context, sportToUpdate);
            return Page();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB.Data;
using WEB.Models;

namespace WEB.Pages.Sporturi
{
    public class CreateModel : CategorieSportPageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public CreateModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var InstructorList = _context.Instructor.Select(x => new
            {
                x.ID,
                FullName = x.Nume + " " + x.Prenume
            });

            ViewData["InstructorID"] = new SelectList(InstructorList, "ID", "FullName");
            ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "NumeSala");


            var sport = new Sport();
            sport.CategoriiSport = new List<CategorieSport>();
            PopuleazaCategorieAtribuita(_context, sport);

            return Page();
        }

        [BindProperty]
        public Sport Sport { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] categorieSelectata)
        {
            {
                var newSport = new Sport();
                if (categorieSelectata != null)
                {
                    newSport.CategoriiSport = new List<CategorieSport>();
                    foreach (var cat in categorieSelectata)
                    {
                        var catToAdd = new CategorieSport
                        {
                            CategorieID = int.Parse(cat)
                        };
                        newSport.CategoriiSport.Add(catToAdd);
                    }

                    Sport.CategoriiSport = newSport.CategoriiSport;

                    _context.Sport.Add(Sport);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");

                }

                PopuleazaCategorieAtribuita(_context, newSport);
                return Page();

            }
        }
    }
}
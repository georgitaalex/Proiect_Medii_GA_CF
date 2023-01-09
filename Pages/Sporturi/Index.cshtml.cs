using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Models;

namespace WEB.Pages.Sporturi
{
    public class IndexModel : PageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public IndexModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        public IList<Sport> Sport { get; set; }

        public SportDate SportD { get; set; }

        public int SportID { get; set; }
        public int CategorieID { get; set; }

        public int InstructorID { get; set; }

        public string CurrentFilter { get; set; }

        public string SportSortare { get; set; }
        public string InstructorSortare { get; set; }


        public async Task OnGetAsync(int? id, int? CategorieID, string sortOrder, string searchString)
        {
            SportD = new SportDate();

            CurrentFilter = searchString;

            SportSortare = String.IsNullOrEmpty(sortOrder) ? "sport_desc" : "";
            InstructorSortare = String.IsNullOrEmpty(sortOrder) ? "instructori_desc" : "";


            SportD.Sporturi = await _context.Sport
                .Include(b => b.Instructor)
                .Include(b => b.CategoriiSport)
                .ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .OrderBy(b => b.NumeSport)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                SportD.Sporturi = SportD.Sporturi.Where(s => s.Instructor.FullName.Contains(searchString)
                                                              || s.NumeSport.Contains(searchString));

                if (id != null)
                {
                    SportID = id.Value;
                    Sport sport = SportD.Sporturi
                    .Where(i => i.ID == id.Value).Single();

                    SportD.Categorii = sport.CategoriiSport.Select(s => s.Categorie);
                }

                switch (sortOrder)
                {
                    case "title_desc":
                        SportD.Sporturi = SportD.Sporturi.OrderByDescending(s => s.NumeSport);
                        break;
                    case "review_desc":
                        SportD.Sporturi = SportD.Sporturi.OrderByDescending(s => s.Instructor.FullName);
                        break;

                }
            }
        }
    }
}

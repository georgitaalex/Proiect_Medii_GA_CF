using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Models;
using WEB.Models.ViewModels;


namespace WEB.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public IndexModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; }

        public CategorieIndexDate CategorieDate { get; set; }
        public int CategorieID { get; set; }
        public int SportID { get; set; }
        public async Task OnGetAsync(int? id, int? productID)
        {
            CategorieDate = new CategorieIndexDate();
            CategorieDate.Categorii = await _context.Categorie
            .Include(i => i.CategoriiSport)
            .ThenInclude(c => c.Sport)
            .ThenInclude(c => c.Instructor)
            .OrderBy(i => i.NumeCategorie)
            .ToListAsync();

            if (id != null)
            {
                CategorieID = id.Value;
                Categorie categorie = CategorieDate.Categorii
                .Where(i => i.ID == id.Value).Single();
                CategorieDate.Sporturi = categorie.CategoriiSport.Select(bc => bc.Sport);
            }
        }
    }
}
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

namespace WEB.Pages.Locatii
{
    public class IndexModel : PageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public IndexModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        public IList<Locatie> Locatie { get;set; }

        public LocatieIndexData LocatieData { get; set; }

        public int LocatieID { get; set; }
        public string SportID { get; set; }

        public async Task OnGetAsync(int? id, int? sportID)
        {
            LocatieData = new LocatieIndexData();
            LocatieData.Locatii = await _context.Locatie
                .Include(i => i.Sporturi)
                .ThenInclude(c => c.Instructor)
                .OrderBy(i => i.NumeSala)
                .ToListAsync();

            if (id != null)
            {
                LocatieID = id.Value;
                Locatie locatie = LocatieData.Locatii
                    .Where(i => i.ID == id.Value).Single();
                LocatieData.Sporturi = locatie.Sporturi;
            }
        }
    }
}

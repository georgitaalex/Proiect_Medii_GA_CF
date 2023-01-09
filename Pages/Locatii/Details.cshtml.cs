using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Models;

namespace WEB.Pages.Locatii
{
    public class DetailsModel : PageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public DetailsModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        public Locatie Locatie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatie = await _context.Locatie.FirstOrDefaultAsync(m => m.ID == id);

            if (locatie == null)
            {
                return NotFound();
            }
            else
            {
                Locatie = locatie;
            }
            return Page();
        }
    }
}

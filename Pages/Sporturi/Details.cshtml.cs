using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Models;

namespace WEB.Pages.Sporturi
{
    public class DetailsModel : PageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public DetailsModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        public Sport Sport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sport == null)
            {
                return NotFound();
            }

            var sport = await _context.Sport.Include(b => b.Instructor).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Sport == null)
            {
                return NotFound();
            }
            else
            {
                sport = Sport;
            }
            return Page();
        }
    }
}

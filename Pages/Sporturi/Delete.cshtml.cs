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
    public class DeleteModel : PageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public DeleteModel(WEB.Data.WEBContext context)
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

            Sport = await _context.Sport.FirstOrDefaultAsync(m => m.ID == id);

            if (Sport == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sport = await _context.Sport.FindAsync(id);

            if (Sport != null)
            {
                _context.Sport.Remove(Sport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

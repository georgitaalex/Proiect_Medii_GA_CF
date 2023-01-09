using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Models;

namespace WEB.Pages.Instructori
{
    public class DeleteModel : PageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public DeleteModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Instructor == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor.FirstOrDefaultAsync(m => m.ID == id);

            if (instructor == null)
            {
                return NotFound();
            }
            else
            {
                Instructor = Instructor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Instructor == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructor.FindAsync(id);

            if (instructor != null)
            {
                Instructor = Instructor;
                _context.Instructor.Remove(instructor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}


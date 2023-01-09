using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB.Data;
using WEB.Models;

namespace WEB.Pages.Instructori
{
    public class CreateModel : PageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public CreateModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Instructor.Add(Instructor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
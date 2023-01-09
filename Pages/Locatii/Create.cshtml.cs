﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB.Data;
using WEB.Models;

namespace WEB.Pages.Locatii
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
        public Locatie Locatie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "NumeLocatie");
                return Page();
            }

            _context.Locatie.Add(Locatie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly WEB.Data.WEBContext _context;

        public IndexModel(WEB.Data.WEBContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructor { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Instructor != null)
            {
                Instructor = (IList<Instructor>)await _context.Instructor.ToListAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Pages.Copies
{
    public class DetailsModel : PageModel
    {
        private readonly Library.Models.LibraryContext _context;

        public DetailsModel(Library.Models.LibraryContext context)
        {
            _context = context;
        }

        public Copy Copy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Copy = await _context.Copy
                .Include(c => c.IsbnNavigation)
                .Include(c => c.LibuserNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Copy == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

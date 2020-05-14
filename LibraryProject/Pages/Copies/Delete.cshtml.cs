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
    public class DeleteModel : PageModel
    {
        private readonly Library.Models.LibraryContext _context;

        public DeleteModel(Library.Models.LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Copy = await _context.Copy.FindAsync(id);

            if (Copy != null)
            {
                _context.Copy.Remove(Copy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

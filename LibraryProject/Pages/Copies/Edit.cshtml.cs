using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Pages.Copies
{
    public class EditModel : PageModel
    {
        private readonly Library.Models.LibraryContext _context;

        public EditModel(Library.Models.LibraryContext context)
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
           ViewData["Id"] = new SelectList(_context.Book, "ID", "Author");
           ViewData["Libuser"] = new SelectList(_context.User, "Id", "Identitycode");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Copy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CopyExists(Copy.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CopyExists(int id)
        {
            return _context.Copy.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Models;

namespace Library.Pages.Copies
{
    public class CreateModel : PageModel
    {
        private readonly Library.Models.LibraryContext _context;

        public CreateModel(Library.Models.LibraryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Id"] = new SelectList(_context.Book, "ID", "Author");
        ViewData["Libuser"] = new SelectList(_context.User, "Id", "Identitycode");
        ViewData["ISBN"] = new SelectList(_context.Book, "Isbn", "Isbn");
            return Page();
        }

        [BindProperty]
        public Copy Copy { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Copy.Add(Copy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
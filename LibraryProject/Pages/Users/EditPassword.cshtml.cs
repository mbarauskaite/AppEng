using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Services;

namespace Library.Pages.Users
{
    public class EditPasswordModel : PageModel
    {
        private readonly Library.Models.LibraryContext _context;

        private MD5Hash mD5;

        public EditPasswordModel(Library.Models.LibraryContext context)
        {
            _context = context;
            mD5 = new MD5Hash();
        }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public string NewPassword { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            
            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User.Password = mD5.HashPassword(NewPassword);
            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
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

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

    }
}
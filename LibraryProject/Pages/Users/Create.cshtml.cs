using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Models;
using Library.Services;

namespace Library.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly Library.Models.LibraryContext _context;

        private MD5Hash mD5; 

        public CreateModel(Library.Models.LibraryContext context)
        {
            _context = context;
            mD5 = new MD5Hash();
        }

        public IActionResult OnGet()
        {
            ViewData["Roles"] = new SelectList(
                    new List<SelectListItem> {
                        new SelectListItem {Selected = false, Text = "User", Value = "0"},
                        new SelectListItem {Selected = false, Text = "Admin", Value = "1"}
                    }, "Value", "Text"); 
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User.Password = mD5.HashPassword(User.Password);
            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
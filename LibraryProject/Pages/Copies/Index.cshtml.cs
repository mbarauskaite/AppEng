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
    public class IndexModel : PageModel
    {
        private readonly Library.Models.LibraryContext _context;

        public IndexModel(Library.Models.LibraryContext context)
        {
            _context = context;
        }

        public IList<Copy> Copy { get;set; }

        public async Task OnGetAsync()
        {
            Copy = await _context.Copy
                .Include(c => c.IsbnNavigation)
                .Include(c => c.LibuserNavigation).ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vrote_Diana_Laborator2.Data;
using Vrote_Diana_Laborator2.Models;

namespace Vrote_Diana_Laborator2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Vrote_Diana_Laborator2.Data.Vrote_Diana_Laborator2Context _context;

        public IndexModel(Vrote_Diana_Laborator2.Data.Vrote_Diana_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {

                Book = await _context.Book
                 .Include(b => b.Publisher)
                 .Include(a => a.Author)
                 .ToListAsync();

                ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FirstName");
            }
        }
    }
}

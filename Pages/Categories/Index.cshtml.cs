using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vrote_Diana_Laborator2.Data;
using Vrote_Diana_Laborator2.Models;
using Vrote_Diana_Laborator2.Models.ViewModels;

namespace Vrote_Diana_Laborator2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Vrote_Diana_Laborator2.Data.Vrote_Diana_Laborator2Context _context;

        public IndexModel(Vrote_Diana_Laborator2.Data.Vrote_Diana_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; }



        public PublisherIndexData PublisherData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                .ThenInclude(i => i.Book)
                .ThenInclude(i => i.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();



            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(s => s.Book);
            }
        }
    }
    }



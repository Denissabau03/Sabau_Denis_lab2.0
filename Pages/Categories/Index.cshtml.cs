using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sabau_Denis_lab2.Data;
using Sabau_Denis_lab2.Models;
using Sabau_Denis_lab2.Models.ViewModels;

namespace Sabau_Denis_lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context _context;

        public IndexModel(Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
           .Include(i => i.BookCategories)
           .ThenInclude(c => c.Book)
           .ThenInclude(c => c.Authors)
           .OrderBy(i => i.CategoryName)
           .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).SingleOrDefault();
                if (category != null) 
                {
                    CategoryData.Books = category.BookCategories.Select(b => b.Book);
                }
                
            }

        }
    }
}

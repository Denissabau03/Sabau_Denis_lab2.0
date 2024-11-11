using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sabau_Denis_lab2.Data;
using Sabau_Denis_lab2.Models;

namespace Sabau_Denis_lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context _context;

        public DetailsModel(Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;
        public List<string> CategoryNames { get; set; } = new List<string>();
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.Include(b => b.Authors)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
                CategoryNames = book.BookCategories.Select(bc => bc.Category.CategoryName).ToList();
            }

            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "Id", "FullName");
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "Id", "CategoryName");

            return Page();
        }
    }
}

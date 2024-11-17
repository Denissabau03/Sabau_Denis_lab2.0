using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Sabau_Denis_lab2.Data;
using Sabau_Denis_lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Sabau_Denis_lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context _context;

        public CreateModel(Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "Id", "FullName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } //= default!;
        

       
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                PopulateAssignedCategoryData(_context, new Book());

                return Page();
            }

            var newBook = new Book
            {
                Title = Book.Title,
                AuthorID = Book.AuthorID,
                Price = Book.Price,
                PublishingDate = Book.PublishingDate,
                PublisherID = Book.PublisherID,
                BookCategories = new List<BookCategory>()
            };

            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }

            Book.BookCategories = newBook.BookCategories;


            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

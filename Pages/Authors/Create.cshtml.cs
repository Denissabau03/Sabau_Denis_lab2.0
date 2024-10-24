using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sabau_Denis_lab2.Data;
using Sabau_Denis_lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Sabau_Denis_lab2.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context _context;

        public CreateModel(Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Authors { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingFirstName = await _context.Authors
            .FirstOrDefaultAsync(b => b.FirstName == Authors.FirstName);

            var existingLastName = await _context.Authors
            .FirstOrDefaultAsync(b => b.LastName == Authors.LastName);


            if (existingFirstName != null && existingLastName != null)
            {
                throw new Exception("An author with this name already exists.");
            }

            _context.Authors.Add(Authors);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

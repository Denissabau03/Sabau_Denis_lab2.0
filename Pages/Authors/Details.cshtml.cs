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

namespace Sabau_Denis_lab2.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context _context;

        public DetailsModel(Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context context)
        {
            _context = context;
        }

        public Author Authors { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);
            if (authors == null)
            {
                return NotFound();
            }
            else
            {
                Authors = authors;
            }
            return Page();
        }
    }
}
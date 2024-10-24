using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sabau_Denis_lab2.Data;
using Sabau_Denis_lab2.Models;

namespace Sabau_Denis_lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context _context;

        public IndexModel(Sabau_Denis_lab2.Data.Sabau_Denis_lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Authors { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Authors = await _context.Authors.ToListAsync();
        }
    }
}
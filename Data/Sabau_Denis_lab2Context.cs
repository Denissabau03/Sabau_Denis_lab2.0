using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sabau_Denis_lab2.Models;

namespace Sabau_Denis_lab2.Data
{
    public class Sabau_Denis_lab2Context : DbContext
    {
        public Sabau_Denis_lab2Context(DbContextOptions<Sabau_Denis_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Sabau_Denis_lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Sabau_Denis_lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Sabau_Denis_lab2.Models.Author> Authors { get; set; } = default!;
        public DbSet<Sabau_Denis_lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Sabau_Denis_lab2.Models.BookCategory> BookCategory { get; set; } = default!;
    }
}

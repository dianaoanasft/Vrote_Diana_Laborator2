using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vrote_Diana_Laborator2.Models;

namespace Vrote_Diana_Laborator2.Data
{
    public class Vrote_Diana_Laborator2Context : DbContext
    {
        public Vrote_Diana_Laborator2Context (DbContextOptions<Vrote_Diana_Laborator2Context> options)
            : base(options)
        {
        }

        public DbSet<Vrote_Diana_Laborator2.Models.Book> Book { get; set; } = default!;

        public DbSet<Vrote_Diana_Laborator2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Vrote_Diana_Laborator2.Models.Author>? Author { get; set; }
    }
}

using LAB5AFront.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB5AFront.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}

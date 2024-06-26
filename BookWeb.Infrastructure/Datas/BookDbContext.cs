using BookWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Infrastructure.Datas
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
        public virtual DbSet<Book> Books { get; set; }
    }
}

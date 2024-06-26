using BookWeb.Domain.Entities;
using BookWeb.Domain.Interfaces;
using BookWeb.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;
        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        private Book GetBookById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var entity = _context.Books.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }
        public async Task<Book> CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);

            _context.SaveChanges();
            return book;
        }
        public bool Delete(int id)
        {
            var entity = GetBookById(id);

            if (entity == null)
            {
                return false;
            }

            _context.Books.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<Book> GetCompleteAsync(int id)
        {
            var entity = GetBookById(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<IEnumerable<Book>> GetListAsync()
        {
            var entity = await _context.Books.ToListAsync();

            return entity;
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            var entity = GetBookById(id);

            if (entity == null)
            {
                return null;
            }

            entity.Name = book.Name;
            entity.Author = book.Author;
            entity.Publisher = book.Publisher;

            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
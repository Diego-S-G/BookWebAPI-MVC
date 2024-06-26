using BookWeb.Application.Interfaces;
using BookWeb.Domain.Entities;
using BookWeb.Domain.Interfaces;

namespace BookWeb.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository repository)
        {
            _bookRepository = repository;
        }

        public Task<Book> CreateAsync(Book book)
        {
            return _bookRepository.CreateAsync(book);
        }

        public bool Delete(int id)
        {
            return _bookRepository.Delete(id);
        }

        public Task<Book> GetCompleteAsync(int id)
        {
            return _bookRepository.GetCompleteAsync(id);
        }

        public Task<IEnumerable<Book>> GetListAsync()
        {
            return _bookRepository.GetListAsync();
        }

        public Task<Book> UpdateAsync(int id, Book book)
        {
            return _bookRepository.UpdateAsync(id, book);
        }
    }
}
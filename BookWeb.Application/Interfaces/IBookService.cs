using BookWeb.Domain.Entities;

namespace BookWeb.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetListAsync();
        Task<Book> GetCompleteAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(int id, Book book);
        bool Delete(int id);
    }
}

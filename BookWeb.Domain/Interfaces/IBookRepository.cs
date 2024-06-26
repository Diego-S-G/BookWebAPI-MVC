using BookWeb.Domain.Entities;

namespace BookWeb.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetListAsync();
        Task<Book> GetCompleteAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(int id, Book book);
        bool Delete(int id);
    }
}

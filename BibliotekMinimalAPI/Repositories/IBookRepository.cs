using BibliotekMinimalAPI.Models;

namespace BibliotekMinimalAPI.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetAsync(Guid id);
        Task<Book> GetAsync(string bookTitle);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task SaveAsync();
    }
}

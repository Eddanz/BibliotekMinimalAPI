using BibliotekMinimalAPI.Data;
using BibliotekMinimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotekMinimalAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Book book)
        {
            await _db.Books.AddAsync(book);
        }

        public async Task DeleteAsync(Book book)
        {
            _db.Books.Remove(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> GetAsync(Guid id)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> GetAsync(string bookTitle)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.Title == bookTitle);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _db.Books.Update(book);
        }
    }
}

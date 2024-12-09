using LibraryApp.Api.Data;
using LibraryApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.Where(b => !b.IsDeleted).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetAllWithPaginationAsync(BookParameters bookParameters)
        {
            return await _context.Books
                .Where(b => !b.IsDeleted)
                .Skip((bookParameters.PageNumber-1)*bookParameters.PageSize)
                .Take(bookParameters.PageSize)
                .ToListAsync();
        }
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted); 
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            book.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}

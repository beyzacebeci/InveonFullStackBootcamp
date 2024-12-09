using LibraryApp.Api.DTOs;
using LibraryApp.Api.Models;

namespace LibraryApp.Api.Services
{
    public interface IBookService
    {
        Task<ServiceResult<IEnumerable<BookDto>>> GetAllAsync();
        Task<ServiceResult<IEnumerable<BookDto>>> GetAllWithPaginationAsync(BookParameters bookParameters);
        Task<ServiceResult<BookDto>> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(BookCreateDto bookCreateDto);
        Task<ServiceResult> UpdateAsync(BookDto bookDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}

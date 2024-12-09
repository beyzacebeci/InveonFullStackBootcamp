using LibraryApp.Api.DTOs;
using LibraryApp.Api.Models;
using LibraryApp.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace LibraryApp.Api.Services
{
    public class BookService : IBookService
    {
        public readonly IBookRepository _bookRepository;
        private readonly IDistributedCache _distributedCache;

        public BookService(IBookRepository bookRepository, IDistributedCache distributedCache)
        {
            _bookRepository = bookRepository;
            _distributedCache = distributedCache;
        }

        public async Task<ServiceResult<IEnumerable<BookDto>>> GetAllAsync()
        {
            try
            {
                // Önbellek anahtarı
                var cacheKey = "books:all";

                // Önbellekten veri kontrolü
                var cachedBooks = await _distributedCache.GetStringAsync(cacheKey);
                if (!string.IsNullOrEmpty(cachedBooks))
                {
                    // JSON'dan deserialize ederek sonucu döndür
                    var bookDtos = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<BookDto>>(cachedBooks);
                    return ServiceResult<IEnumerable<BookDto>>.Success(bookDtos, 200);
                }

                // Önbellekte veri yoksa veritabanından al
                var books = await _bookRepository.GetAllAsync();

                if (books == null || !books.Any())
                {
                    return ServiceResult<IEnumerable<BookDto>>.Fail("No books found.");
                }

                var bookDtosFromDb = books.Select(book => new BookDto(book.Id, book.Title, book.Genre));

                // JSON olarak Redis'e kaydet
                var serializedBooks = System.Text.Json.JsonSerializer.Serialize(bookDtosFromDb);
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) // Önbellek geçerlilik süresi
                };
                await _distributedCache.SetStringAsync(cacheKey, serializedBooks, options);

                return ServiceResult<IEnumerable<BookDto>>.Success(bookDtosFromDb, 200);
            }
            catch (Exception ex)
            {
                // Hata durumunda bir mesaj döndür
                return ServiceResult<IEnumerable<BookDto>>.Fail($"An error occurred while retrieving books: {ex.Message}");
            }
        }

        public async Task<ServiceResult<IEnumerable<BookDto>>> GetAllWithPaginationAsync(BookParameters bookParameters)
        {
            try
            {
                var books = await _bookRepository.GetAllWithPaginationAsync(bookParameters);

                if (books == null || !books.Any())
                {
                    return ServiceResult<IEnumerable<BookDto>>.Fail("No books found.");
                }

                var bookDtos = books.Select(book => new BookDto(book.Id, book.Title, book.Genre));


                return ServiceResult<IEnumerable<BookDto>>.Success(bookDtos, 200); 
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<BookDto>>.Fail($"An error occurred while retrieving books: {ex.Message}");
            }
        }

        public async Task<ServiceResult> CreateAsync(BookCreateDto bookCreateDto)
        {
            try
            {
                // Book.Create ile doğrulama ve nesne oluşturma
                var book = Book.Create(
                    bookCreateDto.Title,
                    bookCreateDto.Genre
                );

                await _bookRepository.AddAsync(book);

                // Başarılı sonuç döndürülüyor
                return ServiceResult<Book>.Success(book, 201);
            }
            catch (ArgumentException ex)
            {
                // İş kurallarından gelen hata
                return ServiceResult<Book>.Fail(ex.Message);
            }
            catch (Exception)
            {
                // Diğer hatalar için genel bir mesaj
                return ServiceResult<Book>.Fail("Kitap oluşturulurken bir hata meydana geldi.");
            }
        }


        public async Task<ServiceResult<BookDto>> GetByIdAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);

                if (book == null)
                {
                    return ServiceResult<BookDto>.Fail("Book not found.");
                }

                var bookDto = new BookDto(book.Id, book.Title, book.Genre);

                return ServiceResult<BookDto>.Success(bookDto, 200); // HTTP 200 OK
            }
            catch (Exception ex)
            {
                return ServiceResult<BookDto>.Fail($"An error occurred while retrieving the book: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(BookDto bookDto)
        {
            var book = await _bookRepository.GetByIdAsync(bookDto.Id);

            if (book == null)
            {
                return ServiceResult.Fail("Book not found.");
            }
            try
            {
                book.Update(bookDto.Title, bookDto.Genre);
                await _bookRepository.UpdateAsync(book);
                return ServiceResult.Success(204); 
            }
            catch (ArgumentException ex)
            {
                return ServiceResult.Fail(ex.Message); // bussinnes logic exception
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);

                if (book == null)
                {
                    return ServiceResult.Fail("Book not found.");
                }

                await _bookRepository.DeleteAsync(book);

                return ServiceResult.Success(204); // HTTP 204 No Content
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail($"An error occurred while deleting the book: {ex.Message}");
            }
        }


    }

}

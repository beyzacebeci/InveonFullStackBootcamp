using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager,
        IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateBook(BookDtoForInsertion bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);
            _manager.Book.Create(book);
            _manager.Save();
        }

        public void DeleteOneBook(int id)
        {
            Book book = GetOneBook(id, false);
            if (book is not null)
            {
                _manager.Book.DeleteOneBook(book);
                _manager.Save();
            }
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book? GetOneBook(int id, bool trackChanges)
        {
            var book = _manager.Book.GetOneBook(id, trackChanges);
            if (book is null)
                throw new Exception("Book not found!");
            return book;
        }

        public BookDtoForUpdate GetOneBookForUpdate(int id, bool trakcChanges)
        {
            var book = GetOneBook(id, trakcChanges);
            var bookDto = _mapper.Map<BookDtoForUpdate>(book);
            return bookDto;
        }

        public void UpdateOneBook(BookDtoForUpdate bookDto)
        {

            var entity = _mapper.Map<Book>(bookDto);
            _manager.Book.UpdateOneBook(entity);
            _manager.Save();
        }
    }
}

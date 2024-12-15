using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _repositoryManager.Book.GetAllBooks(trackChanges);
        }

        public Book? GetOneBook(int id, bool trackChanges)
        {
            var book = _repositoryManager.Book.GetOneBook(id, trackChanges);
            if (book is null)
                throw new Exception("NotFound");
            return book;

        }
    }
}

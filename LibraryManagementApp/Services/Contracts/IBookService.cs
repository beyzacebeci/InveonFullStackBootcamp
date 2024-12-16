using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {

        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book? GetOneBook(int id, bool trackChanges);
        void CreateBook(BookDtoForInsertion bookDto);
        void UpdateOneBook(BookDtoForUpdate bookDto);
        void DeleteOneBook(int id);
        BookDtoForUpdate GetOneBookForUpdate(int id, bool trackChanges);

    }
}

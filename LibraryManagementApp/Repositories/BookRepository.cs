using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<Book> GetAllBooks(bool trackChanges) => FindAll(trackChanges);

        public Book? GetOneBook(int id, bool trackChanges)
        {
            return FindByCondition(b => b.Id.Equals(id), trackChanges);
        }
    }
}

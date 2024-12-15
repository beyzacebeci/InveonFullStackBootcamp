using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly IBookRepository _bookRepository;

        public RepositoryManager(IBookRepository bookRepository, AppDbContext context)
        {
            _bookRepository = bookRepository;
            _context = context;
        }

        public IBookRepository Book => _bookRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

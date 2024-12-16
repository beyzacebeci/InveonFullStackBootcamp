﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        IQueryable<Book> GetAllBooks(bool trackChanges);
        Book? GetOneBook(int id, bool trackChanges);
        void CreateOneBook(Book product);
        void DeleteOneBook(Book product);
        void UpdateOneBook(Book entity);
    }
}

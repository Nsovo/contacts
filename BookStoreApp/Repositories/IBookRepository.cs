using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BookStoreApp.Models;

namespace BookStoreApp.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        IQueryable<Book> GetBooks();
        Book GetBook(int id);
        void PutBook(int id, Book book);
        Book DeleteBook(Book book);
        Task<int> SaveAsync();
    }
}
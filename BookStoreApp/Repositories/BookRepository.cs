using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Models;

namespace BookStoreApp.Repositories
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly BookStoreAppContext _db = new BookStoreAppContext();


        public void Add(Book book)
        {
            _db.Books.Add(book);
            
        }

        public IQueryable<Book> GetBooks()
        {
            return _db.Books;
        }

        public  Book GetBook(int id)
        {
            return _db.Books.Find(id);
        }

        public void PutBook(int id, Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
        }


        public async Task<int> SaveAsync()
        {
          return  await  _db.SaveChangesAsync();
        }

        public Book DeleteBook(Book book)
        {
            return _db.Books.Remove(book);
        }


        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookStoreApp.Models;
using BookStoreApp.Repositories;

namespace BookStoreApp.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookRepository _bookRepository;


        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        // GET: api/Book
        public IQueryable<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        // GET: api/Book/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            Book book = await Task.FromResult( _bookRepository.GetBook(id));
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Book/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.BookId)
            {
                return BadRequest();
            }


            try
            {
               _bookRepository.PutBook(id,book);
                await _bookRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var bookExist = _bookRepository.GetBook(id);
                if (bookExist.BookId <= 0)
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Book
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bookRepository.Add(book);
            await _bookRepository.SaveAsync();

            return CreatedAtRoute("DefaultApi", new { id = book.BookId }, book);
        }

        // DELETE: api/Book/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = _bookRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.DeleteBook(book);
            await _bookRepository.SaveAsync();

            return Ok(book);
        }
    }
}
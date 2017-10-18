using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MovieCollectionApp.Models;
using MovieCollectionApp.Repositories;

namespace MovieCollectionApp.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMovieRepository _movieRepository;


        public MovieController()
        {
            _movieRepository = new MovieRepository();
        }

        // GET: api/Movie
        public IQueryable<Movie> GetMovies()
        {
            return _movieRepository.GetMovies();
        }

        // GET: api/Movie/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetMovies(int id)
        {
            Movie movie = await Task.FromResult( _movieRepository.GetMovie(id));
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // GET: api/Movie/String
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetByTitle(string title)
        {
            var movies = await Task.FromResult(_movieRepository.GetByTitle(title));
            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        // GET: api/Movie/String
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetByDirector(string director)
        {
            var movies = await Task.FromResult(_movieRepository.GetByDirector(director));
            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        // GET: api/Movie/String
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetByActor(string actor)
        {
            var movies = await Task.FromResult(_movieRepository.GetByActor(actor));
            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        // GET: api/Movie/String
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetByYear(int year)
        {
            var movies = await Task.FromResult(_movieRepository.GetByYear(year));
            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        // GET: api/Movie/String
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> GetByLocation(string location)
        {
            var movies = await Task.FromResult(_movieRepository.GetByLocation(location));
            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        // PUT: api/Movie/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.MovieId)
            {
                return BadRequest();
            }


            try
            {
               _movieRepository.PutMovie(id,movie);
                await _movieRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var movieExist = _movieRepository.GetMovie(id);
                if (movieExist.MovieId <= 0)
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movie
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _movieRepository.Add(movie);
            await _movieRepository.SaveAsync();

            return CreatedAtRoute("DefaultApi", new { id = movie.MovieId }, movie);
        }

        // DELETE: api/Movie/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            Movie movie = _movieRepository.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            _movieRepository.DeleteMovie(movie);
            await _movieRepository.SaveAsync();

            return Ok(movie);
        }
    }
}
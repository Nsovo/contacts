using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MovieCollectionApp.Models;

namespace MovieCollectionApp.Repositories
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private readonly MovieStoreContext _db = new MovieStoreContext();


        public void Add(Movie movie)
        {
            _db.Movies.Add(movie);
        }

        public IQueryable<Movie> GetMovies()
        {
            return _db.Movies;
        }

        public IQueryable<Movie> GetByTitle(string title)
        {
            var movies = _db.Movies.Where(m => m.Title.Contains(title)).ToList();
            return movies.AsQueryable();
        }

        public IQueryable<Movie> GetByDirector(string director)
        {
            var movies = _db.Movies.Where(m => m.Director.Contains(director)).ToList();
            return movies.AsQueryable();
        }

        public IQueryable<Movie> GetByActor(string actor)
        {
            var movies = _db.Movies.Where(m => m.Actor.Contains(actor)).ToList();
            return movies.AsQueryable();
        }

        public IQueryable<Movie> GetByYear(int year)
        {
            return _db.Movies.Where(m => m.DateReleased.Year.Equals(year));
        }

        public IQueryable<Movie> GetByLocation(string location)
        {
            return _db.Movies.Where(m => m.Location.Equals(location));
        }

        public  Movie GetMovie(int id)
        {
            return _db.Movies.Find(id);
        }

        public void PutMovie(int id, Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
        }


        public async Task<int> SaveAsync()
        {
          return  await  _db.SaveChangesAsync();
        }

        public Movie DeleteMovie(Movie movie)
        {
            return _db.Movies.Remove(movie);
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
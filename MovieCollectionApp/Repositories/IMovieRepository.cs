using System.Linq;
using System.Threading.Tasks;
using MovieCollectionApp.Models;

namespace MovieCollectionApp.Repositories
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        IQueryable<Movie> GetMovies();
        IQueryable<Movie> GetByTitle(string title);
        IQueryable<Movie> GetByDirector(string director);
        IQueryable<Movie> GetByActor(string actor);
        IQueryable<Movie> GetByYear(int year);
        IQueryable<Movie> GetByLocation(string location);
        Movie GetMovie(int id);
        void PutMovie(int id, Movie movie);
        Movie DeleteMovie(Movie movie);
        Task<int> SaveAsync();
    }
}
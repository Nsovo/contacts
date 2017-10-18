using System.Data.Entity;

namespace MovieCollectionApp.Models
{
    public class MovieStoreContext : DbContext
    {
    
        public MovieStoreContext() : base("name=MovieStoreContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MovieStoreContext>());
        }

        public DbSet<Movie> Movies { get; set; }
    }
}

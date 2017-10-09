using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStoreApp.Models
{
    public class BookStoreAppContext : DbContext
    {
    
        public BookStoreAppContext() : base("name=BookStoreAppContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BookStoreAppContext>());
        }

        public DbSet<Book> Books { get; set; }
    }
}

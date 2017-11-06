using System.Data.Entity;

namespace ContactsApp.Models
{
    public class ContactsContext : DbContext
    {

        public ContactsContext() : base("name=ContactsContext")
        {
            //once databse is created :CreateDatabaseIfNotExists
            Database.SetInitializer(new CreateDatabaseIfNotExists<ContactsContext>());

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
    }

}

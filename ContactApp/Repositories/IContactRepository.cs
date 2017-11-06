using System.Linq;
using System.Threading.Tasks;
using ContactsApp.Models;

namespace ContactsApp.Repositories
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        IQueryable<Contact> GetContacts();
        Contact GetContacts(int id);
        IQueryable<Contact> GetUserContacts(int id);
        void PutContact(int id, Contact contact);
        Contact DeleteContact(Contact contact);
        Task<int> SaveAsync();
    }
}
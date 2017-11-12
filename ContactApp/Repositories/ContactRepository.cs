using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ContactsApp.Models;

namespace ContactsApp.Repositories
{
    public class ContactRepository : IContactRepository, IDisposable
    {
        private readonly ContactsContext _db = new ContactsContext();


        public void Add(Contact contact) => _db.Contacts.Add(contact);

        public IQueryable<Contact> GetContacts() => _db.Contacts;

        public Contact GetContacts(int id) => _db.Contacts.FirstOrDefault(c => c.ContactId.Equals(id));

        public IQueryable<Contact> GetUserContacts(int id) => _db.Contacts.Where(m => m.UserId.Equals(id)).ToList().AsQueryable();

        public void PutContact(int id, Contact contact) => _db.Entry(contact).State = EntityState.Modified;


        public async Task<int> SaveAsync() => await _db.SaveChangesAsync();

        public Contact DeleteContact(Contact contact) => _db.Contacts.Remove(contact);


        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _db.Dispose();
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
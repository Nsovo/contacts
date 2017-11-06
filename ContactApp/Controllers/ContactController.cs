using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ContactsApp.Models;
using ContactsApp.Repositories;

namespace ContactsApp.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactRepository _contactRepository;


        public ContactController()
        {
            _contactRepository = new ContactRepository();
        }

        // GET: api/Contact
        public IQueryable<Contact> GetContacts()
        {
            return _contactRepository.GetContacts();
        }

        // GET: api/Contact/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> GetUserContacts(int id)
        {
           IQueryable<Contact> userContacts = await Task.FromResult(_contactRepository.GetUserContacts(id));
            if (userContacts == null)
                return NotFound();

            return Ok(userContacts);
        }

        // PUT: api/Contact/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != contact.ContactId)
                return BadRequest();


            try
            {
                _contactRepository.PutContact(id, contact);
                await _contactRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var contactExist = _contactRepository.GetContacts(id);
                if (contactExist.ContactId <= 0)
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contact
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _contactRepository.Add(contact);
            await _contactRepository.SaveAsync();

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactId }, contact);
        }

        // DELETE: api/Contact/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
            Contact contact = _contactRepository.GetContacts(id);
            if (contact == null)
                return NotFound();

            _contactRepository.DeleteContact(contact);
            await _contactRepository.SaveAsync();

            return Ok(contact);
        }
    }
}
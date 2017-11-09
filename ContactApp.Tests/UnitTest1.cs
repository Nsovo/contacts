using ContactsApp.Models;
using ContactsApp.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanAddContact()
        {
            var contact = new Contact();
            contact.CellPhone = 0712544412;
            contact.Email = "test@gmail.com";
            contact.PhoneNumber = 011254441;
            contact.UserId = 1;

           var repository = new ContactRepository();
            repository.Add(contact);
            Assert.IsNull(contact);

            //nothing much to test on a void
        }

        [TestMethod]
        public void CanGetContacts()
        {
            var contact = new Contact();
            contact.CellPhone = 0712544412;
            contact.Email = "test@gmail.com";
            contact.PhoneNumber = 011254441;
            contact.UserId = 1;

            var repository = new ContactRepository();
            repository.Add(contact);

            var contacts  = repository.GetContacts();
            Assert.IsNull(contact);
           // Assert.Equals(contacts);
        }
    }
}

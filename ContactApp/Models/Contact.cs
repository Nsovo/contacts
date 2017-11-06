using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Models
{
    public class Contact
    {

        [Key]
        public int ContactId { get; set; }
        public int CellPhone { get; set; }
        public int PhoneNumber { get; set; }
        public int WorkNumber { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }

    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual List<Contact> Contacts { get; set; }

    }
}
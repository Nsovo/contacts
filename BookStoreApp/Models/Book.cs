using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Format { get; set; }
        public string Title { get; set; }
        public string SubTitle {get;set;}
        public string Description { get; set; }
        public string Contributors { get; set; }
        public string Language { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCollectionApp.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public List<string> Actor { get; set; }
        public int Year { get; set; }
        public string TypeId { get; set; }
        public string Location { get; set; }
        public DateTime DateReleased { get; set; }

        public virtual Type Type { get; set; }
    }

    public class Type
    {
        public int TypeId { get; set; }
        public string Name { get; set; }
    }
}
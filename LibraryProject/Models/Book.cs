using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public partial class Book
    {
        public Book()
        {
            Copy = new HashSet<Copy>();
        }

        public int ID { get; set; }
        [DisplayName("ISBN")]
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public short Date { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        [Range(1, 10000)]
        public short Pages { get; set; }
        public string Description { get; set; }

        public ICollection<Copy> Copy { get; set; }
    }
}

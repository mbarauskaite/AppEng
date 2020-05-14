using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public partial class Copy
    {
        public int Id { get; set; }
        [DisplayName("ISBN")]
        public string Isbn { get; set; }
        [DisplayName("User")]
        public int? Libuser { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Taken { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Return { get; set; }
        [DisplayName("ISBN Navigation")]
        public Book IsbnNavigation { get; set; }
        [DisplayName("User Navigation")]
        public User LibuserNavigation { get; set; }
    }
}

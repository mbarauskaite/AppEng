using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Library.Models
{
    public partial class User
    {
        public User()
        {
            Copy = new HashSet<Copy>();
        }

        public int Id { get; set; }
        [DisplayName("Identity Code")]
        public string Identitycode { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public ICollection<Copy> Copy { get; set; }
    }
}

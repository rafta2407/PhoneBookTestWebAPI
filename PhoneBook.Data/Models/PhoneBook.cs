using System;
using System.Collections.Generic;

#nullable disable

namespace PhoneBook.Data.Models
{
    public partial class PhoneBook
    {
        public PhoneBook()
        {
            PhoneBookEntries = new HashSet<PhoneBookEntry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PhoneBookEntry> PhoneBookEntries { get; set; }
    }
}

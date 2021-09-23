using System;
using System.Collections.Generic;

#nullable disable

namespace PhoneBook.Data.Models
{
    public partial class Entry
    {
        public Entry()
        {
            PhoneBookEntries = new HashSet<PhoneBookEntry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<PhoneBookEntry> PhoneBookEntries { get; set; }
    }
}

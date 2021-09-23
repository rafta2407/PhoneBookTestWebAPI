using System;
using System.Collections.Generic;

#nullable disable

namespace PhoneBook.Data.Models
{
    public partial class PhoneBookEntry
    {
        public int Id { get; set; }
        public int PhoneBookId { get; set; }
        public int EntryId { get; set; }

        public virtual Entry Entry { get; set; }
        public virtual PhoneBook PhoneBook { get; set; }
    }
}

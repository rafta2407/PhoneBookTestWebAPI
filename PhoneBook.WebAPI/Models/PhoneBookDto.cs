using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.WebAPI.Models
{
    public class PhoneBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EntryDto> Entries { get; set; }
    }
}

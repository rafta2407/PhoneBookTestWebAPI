using PhoneBook.Data.Contracts;
using PhoneBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Repositories
{
    public class PhoneBookEntryRepository : RepositoryBase<PhoneBookEntry>, IPhoneBookEntryRepository
    {
        public PhoneBookEntryRepository(phonebookContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}

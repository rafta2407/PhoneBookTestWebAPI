using PhoneBook.Data.Contracts;
using PhoneBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Repositories
{
    public class EntryRepository : RepositoryBase<Models.Entry>, IEntryRepository
    {
        public EntryRepository(phonebookContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}

using PhoneBook.Data.Contracts;
using PhoneBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Repositories
{
    public class PhoneBookRepository : RepositoryBase<Models.PhoneBook>, IPhoneBookRepository
    {
        public PhoneBookRepository(phonebookContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Contracts
{
    public interface IUnitOfWork
    {
        IPhoneBookEntryRepository PhoneBookEntryRepository { get; }
        IPhoneBookRepository PhoneBookRepository { get; }
        IEntryRepository EntryRepository { get; }
        void Save();
    }
}

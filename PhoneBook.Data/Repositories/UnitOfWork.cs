using PhoneBook.Data.Contracts;
using PhoneBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly phonebookContext _context;
        private IPhoneBookEntryRepository _phoneBookEntryRepository;
        private IPhoneBookRepository _phoneBookRepository;
        private IEntryRepository _entryRepository;

        public UnitOfWork(phonebookContext context)
        {
            _context = context;
        }

        public IPhoneBookEntryRepository PhoneBookEntryRepository
        {
            get
            {
                if(_phoneBookEntryRepository == null)
                {
                    _phoneBookEntryRepository = new PhoneBookEntryRepository(_context);
                }
                return _phoneBookEntryRepository;
            }
        }

        public IPhoneBookRepository PhoneBookRepository
        {
            get
            {
                if(_phoneBookRepository == null)
                {
                    _phoneBookRepository = new PhoneBookRepository(_context);
                }
                return _phoneBookRepository;
            }
        }


        public IEntryRepository EntryRepository
        {
            get
            {
                if(_entryRepository == null)
                {
                    _entryRepository = new EntryRepository(_context);
                }
                return _entryRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

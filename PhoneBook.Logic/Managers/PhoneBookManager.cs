using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Logic.Managers
{
    public class PhoneBookManager
    {
        private IUnitOfWork _unitOfWork;

        public PhoneBookManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public void AddEntry(Data.Models.Entry entry)
        {
            _unitOfWork.EntryRepository.Create(entry);
        }

        public List<Data.Models.Entry> GetEntries(int phoneBookId)
        {
            return _unitOfWork.PhoneBookEntryRepository.FindAll()
                .Include(n => n.Entry)
                .Where(n => n.PhoneBookId == phoneBookId)?.Select(n => n.Entry).ToList();
        }

        public void AddPhoneBookEntry(Data.Models.PhoneBookEntry phoneBookEntry)
        {
            _unitOfWork.PhoneBookEntryRepository.Create(phoneBookEntry);
        }

        public void AddPhoneBook(Data.Models.PhoneBook phoneBook)
        {
            _unitOfWork.PhoneBookRepository.Create(phoneBook);
        }

        public List<Data.Models.PhoneBook> GetPhoneBooks()
        {
            return _unitOfWork.PhoneBookRepository
                .FindAll()
                .ToList();
        }

        public List<Data.Models.PhoneBookEntry> GetPhoneBookEntries()
        {
            return _unitOfWork.PhoneBookEntryRepository
                .FindAll()
                .Include(n => n.Entry)
                .ToList();
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}

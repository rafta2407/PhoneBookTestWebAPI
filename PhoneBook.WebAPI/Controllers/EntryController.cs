using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data.Models;
using PhoneBook.Logic.Managers;
using PhoneBook.WebAPI.Models;

namespace PhoneBook.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly PhoneBookManager _manager;        
        public EntryController(PhoneBookManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public IActionResult Post([FromBody]EntryDto dto)
        {
            var entry = new Data.Models.Entry
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber
            };
            _manager.AddEntry(entry);
            _manager.Save();

            var phoneEntry = new PhoneBookEntry
            {
                PhoneBookId = dto.PhoneBookId,
                EntryId = entry.Id
            };

            _manager.AddPhoneBookEntry(phoneEntry);
            _manager.Save();
            dto.Id = entry.Id;
            return Ok(dto);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var results = _manager.GetEntries(id);
            return Ok(results);
        }
    }
}

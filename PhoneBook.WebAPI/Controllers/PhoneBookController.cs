using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data.Models;
using PhoneBook.Logic.Managers;
using PhoneBook.WebAPI.Models;
using System.Linq;

namespace PhoneBook.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class PhoneBookController : ControllerBase
    {
        private readonly PhoneBookManager _manager;
        public PhoneBookController(PhoneBookManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public IActionResult Post([FromBody]PhoneBookDto dto)
        {
            var entry = new Data.Models.PhoneBook
            {
                Name = dto.Name
            };

            _manager.AddPhoneBook(entry);
            _manager.Save();
            dto.Id = entry.Id;
            return Ok(dto);
        }

        [HttpPost("postentry")]
        public IActionResult Post([FromBody] PhoneBookEntryDto dto)
        {
            var entry = new PhoneBookEntry
            {
                PhoneBookId = dto.PhoneBookId,
                EntryId = dto.EntryId
            };

            _manager.AddPhoneBookEntry(entry);
            _manager.Save();

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _manager.GetPhoneBooks();
            var entries = _manager.GetPhoneBookEntries();

            if (result.Count > 0)
            {
                var response = result.Select(n => new PhoneBookDto
                {
                    Id = n.Id,
                    Name = n.Name,
                    Entries = entries.Where(p => p.PhoneBookId == n.Id).Select(o => new EntryDto
                    {
                        Id = o.Entry.Id,
                        Name = o.Entry?.Name,
                        PhoneNumber = o.Entry?.PhoneNumber
                    })?.ToList()
                });
                return Ok(response);
            }
            return NoContent();
        }
    }
}

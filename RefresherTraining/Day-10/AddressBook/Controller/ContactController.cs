using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using ModelLayer.Dtos;

namespace AddressBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        // GET api/Contact
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(_service.GetAllContacts());
        }

        // GET api/Contact/5
        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            ContactDto? contact = _service.GetContactById(id);
            return contact != null ? Ok(contact) : NotFound("Contact not found.");
        }

        // POST api/Contact/add
        [HttpPost("add")]
        public IActionResult AddContact([FromBody] ContactDto contactDto)
        {
            _service.AddContact(contactDto);
            return Ok("Contact added successfully.");
        }

        // PUT api/Contact/5
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] ContactDto contactDto)
        {
            bool updated = _service.UpdateContact(id, contactDto);
            return updated ? Ok("Contact updated successfully.") : NotFound("Contact not found.");
        }

        // DELETE api/Contact/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            bool deleted = _service.DeleteContact(id);
            return deleted ? Ok("Contact deleted successfully.") : NotFound("Contact not found.");
        }
    }
}
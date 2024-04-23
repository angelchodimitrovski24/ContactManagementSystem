using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactManagementSystem.Repositories;
using ContactManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _contactRepository.GetAllContactsAsync()); // Use Ok()
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(Guid id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null) return NotFound();
            return contact;
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            await _contactRepository.AddContactAsync(contact);
            return CreatedAtAction("GetContact", new { id = contact.ContactId }, contact);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(Guid id, Contact contact)
        {
            if (id != contact.ContactId) return BadRequest();

            try
            {
                await _contactRepository.UpdateContactAsync(contact);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle database concurrency issues if desired
                throw; // Or replace with your preferred error handling
            }

            return NoContent();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null) return NotFound();

            await _contactRepository.DeleteContactAsync(contact);
            return NoContent();
        }
    }
}

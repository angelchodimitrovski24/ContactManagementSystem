using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactManagementSystem.Data;
using ContactManagementSystem.Models;

namespace ContactManagementSystem.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactManagementContext _context;

        public ContactRepository(ContactManagementContext context)
        {
            _context = context;
        }

        // Interface implementation
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(Guid contactId)
        {
            return await _context.Contacts.FindAsync(contactId);
        }

        public async Task AddContactAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManagementSystem.Models;
namespace ContactManagementSystem.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(Guid contactId);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(Contact contact);
    }
}

using Microsoft.EntityFrameworkCore;
using ContactManagementSystem.Models;

namespace ContactManagementSystem.Data
{
    public class ContactManagementContext : DbContext
    {
        public ContactManagementContext(DbContextOptions<ContactManagementContext> options) : base(options)
        {
            
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}

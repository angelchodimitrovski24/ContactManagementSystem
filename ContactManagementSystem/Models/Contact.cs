using System.ComponentModel.DataAnnotations;

namespace ContactManagementSystem.Models
{
    public class Contact : IContact
    {
        public Guid ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}


namespace ContactManagementSystem.Models
{
    public interface IContact
    {
        Guid ContactId { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string Lastname { get; set; }
        string PhoneNumber { get; set; }
    }
}
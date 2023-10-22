namespace ContactList_Project_Test3.Models;

public class Contact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public Address FullAddress { get; set; } = null!;
}

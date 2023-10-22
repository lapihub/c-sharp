namespace ContactList_Project.Models;

internal class Contact
{
    public Guid Id { get; set; } // Skapande av Id gör vi i servicen istället
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
}
   
// Vad vi vill ha av systemet när en kontakt hämtas

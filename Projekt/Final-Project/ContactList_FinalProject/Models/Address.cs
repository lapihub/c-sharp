namespace ContactList_FinalProject.Models;

public class Address
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string FullAddress => $"{Street}, {PostalCode} {City}, {Country}";
}

// Separat klass för specifikt adress
namespace ContactList_Project_Test3.Models;

public class Address
{
    public string Street { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string FullAddress => $"{Street} {StreetNumber}, {PostalCode} {City}, {Country}";

}

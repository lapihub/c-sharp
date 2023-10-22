using ContactList_Project.Interfaces;
using ContactList_Project.Models;
using System.Linq.Expressions;

namespace ContactList_Project.Services;

internal class ContactManager : IContactManager

{ 
    private List<Contact> _contacts = new List<Contact>(); // Här har vi skapat en lista och gjort en instans av den

    public void CreateContact(ContactCreateRequest contactCreateRequest)
    {
        _contacts.Add(new Contact // Vi gör om den här till en ny Contact och gör en manuell mappning. 
        {
            Id = Guid.NewGuid(), // Här autogenereras Id:t
            FirstName = contactCreateRequest.FirstName,
            LastName = contactCreateRequest.LastName,
            Email = contactCreateRequest.Email,
            PhoneNumber = contactCreateRequest.PhoneNumber,
            Address = contactCreateRequest.Address,
            City = contactCreateRequest.City,
            PostalCode = contactCreateRequest.PostalCode,
            Country = contactCreateRequest.Country
        });
    }
    public void UpdateContact(ContactCreateRequest contactCreateRequest)
    {
        throw new NotImplementedException();
    }
    public void DeleteContact(string Email)
    {
        var contact = _contacts.FirstOrDefault(x => x.Email == Email, null!); // Här letar vi rätt på listan baserat på email. x = Contact
        if (contact != null) // Jag använder if-sats här ifall den inte är null tar vi bort kontakt från listan. Annars inte. 
        {
            _contacts.Remove(contact);
        }
       
    }
    public Contact GetContact(Func<Contact, bool> expression) // Vi hämtar ut en specifik kontakt. 
    {
        var contact = _contacts.FirstOrDefault(expression, null!); // Om vi inte hämtar en specifik skickar vi tillbaka ett tomt objekt. 
        return contact;
    }
    public IEnumerable<Contact> GetAllContacts()
    {
        return _contacts; // Här ger den tillbaka oss listan vi skapade till en läsbar lista
    }

    
}

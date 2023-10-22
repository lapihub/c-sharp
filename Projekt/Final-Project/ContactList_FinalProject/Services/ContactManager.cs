using ContactList_FinalProject.Models;
using Newtonsoft.Json;

namespace ContactList_FinalProject.Services;

public interface IContactManager // Ett kontrakt (kriterie) för vad som ska finnas
{
    public bool CreateContact(Contact contact);
    public Contact UpdateContact(Contact contact);
    public void DeleteContact(string Email);
    public Contact GetSpecific(Func<Contact, bool> expression);
    IEnumerable<Contact> GetAll();
}
public class ContactManager : IContactManager
{
    private List<Contact> _contacts = new List<Contact>(); // Skapat en lista och gjort en instans av den
    public bool CreateContact(Contact contact)
    {
        try
        {
            _contacts.Add(contact); // Vi sparar den nya kontakten till listan. 

            FileManager.SaveToFile(JsonConvert.SerializeObject(_contacts)); // konverterar listan och sparar den till en json fil 
            return true;
        }
        catch { }
        return false;
    }

    public void DeleteContact(string Email)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(x => x.Email == Email); // Jag letar rätt på listan baserat på email
            if (contact != null) // Använder if-sats här ifall den inte är null tar vi bort kontakt från listan. Annars inte. 
                _contacts.Remove(contact);

            FileManager.SaveToFile(JsonConvert.SerializeObject(_contacts));

        }
        catch { }
    }

    public IEnumerable<Contact> GetAll()
    {
        try
        {
            var content = FileManager.ReadFromFile(); // hämta info här som en sträng
            if (!string.IsNullOrEmpty(content)) // kontrollera om det finns innehåll eller inte
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!; // här blir det en objektlista 
        }
        catch { }

        return _contacts; // Här ger den tillbaka oss listan vi skapade till en läsbar lista. 
    }

    public Contact GetSpecific(Func<Contact, bool> expression)
    {
        try
        {
            var content = FileManager.ReadFromFile();
            if (!string.IsNullOrEmpty(content))
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
        }
        catch { }

        var contact = _contacts.FirstOrDefault(expression, null!); // Om vi inte hämtar en specifik kontakt skickar vi tillbaka null 
        return contact;
    }

    public Contact UpdateContact(Contact contact)
    {
        var _contact = _contacts.FirstOrDefault(x => x.FirstName == contact.FirstName);
        if (_contact != null)
        {
            // Vi uppdaterar kontakten här
            if (_contact.LastName != contact.LastName)
                _contact.LastName = contact.LastName;

            if (_contact.Email != contact.Email)
                _contact.Email = contact.Email;

            if (_contact.PhoneNumber != contact.PhoneNumber)
                _contact.PhoneNumber = contact.PhoneNumber;

            if (_contact.FullAddress != contact.FullAddress)
                _contact.FullAddress = contact.FullAddress;

            FileManager.SaveToFile(JsonConvert.SerializeObject(_contacts));
            return _contact;
        }
        return null!;
    }
}

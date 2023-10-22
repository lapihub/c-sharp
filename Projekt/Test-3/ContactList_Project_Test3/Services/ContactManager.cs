using ContactList_Project_Test3.Models;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace ContactList_Project_Test3.Services;


public interface IContactManager
{
    public bool CreateContact(Contact contact);
    public Contact UpdateContact(Contact contact);
    public void DeleteContact(string Email);
    public Contact GetSpecific(Func<Contact, bool> expression);
    IEnumerable<Contact> GetAll();
}


public class ContactManager : IContactManager
{
    private List<Contact> _contacts = new List<Contact>();
    public bool CreateContact(Contact contact)
    {
        try
        {
            _contacts.Add(contact);

            FileManager.SaveToFile(JsonConvert.SerializeObject(_contacts));
            return true;
        }
        catch { }
        return false;
    }

    public Contact UpdateContact(Contact contact)
    {
        var _contact = _contacts.FirstOrDefault(x => x.FirstName == contact.FirstName);
        if (_contact != null)
        {
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

    public void DeleteContact(string Email)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(x => x.Email == Email);
            if (contact != null)
                _contacts.Remove(contact);

            FileManager.SaveToFile(JsonConvert.SerializeObject(_contacts));

        }
        catch { }
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

        var contact = _contacts.FirstOrDefault(expression, null!);
        return contact;
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

        return _contacts;
    }


}

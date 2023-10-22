using ContactList_Project_Test2.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContactList_Project_Test2.Services;


public interface IContactManage
{
    public void CreateContact(Contact contact);
    public void DeleteContact(string Email);
    public Contact GetSpecific(Func<Contact, bool> expression);
    IEnumerable<Contact> GetAll();
}
public class ContactManage : IContactManage
{
    private List<Contact> _contacts = new List<Contact>(); // Skapat en lista
    public void CreateContact(Contact contact)
    {
        try
        {
            _contacts.Add(new Contact
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                FullAddress = contact.FullAddress,
            });

            FileManage.SaveToFile(JsonConvert.SerializeObject(_contacts));
            
        }
        catch { }
    }

    public void DeleteContact(string Email)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(x => x.Email == Email);
            if (contact != null)
                _contacts.Remove(contact);

            FileManage.SaveToFile(JsonConvert.SerializeObject(_contacts));
        }
        catch { }
        
    }
   
    public IEnumerable<Contact> GetAll()
    {    
        try
        {
            var content = FileManage.ReadFromFile(); // hämta info här som en sträng
            if (!string.IsNullOrEmpty(content)) // kontrollera om det finns innehåll eller inte
               _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!; // här blir det en objektlista 
        }
        catch { }       
        
        return _contacts;    
    }
    
    public Contact GetSpecific(Func<Contact, bool> expression)
    {
        try
        {
            var content = FileManage.ReadFromFile();
            if (!string.IsNullOrEmpty(content))
               _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
        }
        catch { }

        var contact = _contacts.FirstOrDefault(expression, null!);
        return contact;   
    }  
   
}

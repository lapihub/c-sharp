using ContactList_Project.Models;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace ContactList_Project.Interfaces;

internal interface IContactManager // Ett kontrakt (kriterie) för vad som ska finnas 
{
    public void CreateContact(ContactCreateRequest contactCreateRequest); // Vi vill skapa en kund mha vår Model
    public void UpdateContact(ContactCreateRequest contactCreateRequest);
    public void DeleteContact(string Email); // Vi vill kunna radera en kontakt genom att ange epost
    public Contact GetContact(Func<Contact, bool> expression);
    public IEnumerable<Contact> GetAllContacts(); // Hämta kontakter genom en läsbar lista
    void Delete(string v);
}

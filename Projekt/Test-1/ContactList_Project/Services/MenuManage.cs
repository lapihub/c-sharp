using ContactList_Project.Interfaces;
using ContactList_Project.Models;
using System.Reflection.Metadata;

namespace ContactList_Project.Services;

internal interface IMenuManage
{
    public void MainMenu();
    public void CreateMenu();
    public void ListAllMenu();
    public void ListSpecificMenu();
    public void UpdateMenu();
    public void DeleteMenu();
     
}
internal class MenuManage : IMenuManage
{
    private readonly IContactManager _contactManager = new ContactManager();
     public void MainMenu()
    {
        var exit = false;
         
        do
        {
            Console.Clear();
            Console.WriteLine("1. Skapa en ny kontakt");
            Console.WriteLine("2. Visa en specifik kontakt");
            Console.WriteLine("3. Visa alla kontakter");
            Console.WriteLine("4. Uppdatera en kontakt");
            Console.WriteLine("5. Radera en kontakt");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("Välj ett av ovanstående alternativ (0-5): ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateMenu();
                    break;

                case "2":
                    ListSpecificMenu();
                    break;

                case "3":
                    ListAllMenu();
                    break;

                case "4":
                    UpdateMenu();
                    break;

                case "5":
                    DeleteMenu();
                    break;

                case "0":
                    exit = true;
                    break;

                default:
                    break;
            }
        }
        while (!exit);
    }
    public void CreateMenu()
    {
        Console.Clear();
        Console.WriteLine("Skapa en ny kontakt");
        Console.WriteLine("-------------------");

        var contact = new ContactCreateRequest(); // Object för att spara in all info

        Console.Write("Förnamn: ");
        contact.FirstName = Console.ReadLine()!.Trim();

        Console.Write("Efternamn: ");
        contact.LastName = Console.ReadLine()!.Trim();

        Console.Write("E-postadress: ");
        contact.Email = Console.ReadLine()!.Trim().ToLower();

        Console.Write("Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine()!.Trim();

        Console.Write("Adress: ");
        contact.Address = Console.ReadLine()!.Trim();

        Console.Write("Stad: ");
        contact.City = Console.ReadLine()!.Trim();

        Console.Write("Postnummer: ");
        contact.PostalCode = Console.ReadLine()!.Trim();

        Console.Write("Land: ");
        contact.Country = Console.ReadLine()!.Trim();

        _contactManager.CreateContact(contact);

        Console.WriteLine("En ny kontakt har blivit tillagd.");
        Console.ReadKey();
    }
    public void ListAllMenu()
    {
        Console.Clear();
        Console.WriteLine("Alla kontakter");
        Console.WriteLine("------------------------------");

        foreach (var contact in _contactManager.GetAllContacts())
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} {contact.Address} {contact.City} {contact.PostalCode} {contact.Country}");
        Console.ReadKey();
    
    }
    public void ListSpecificMenu()
    {
        Console.Clear();
        Console.WriteLine("Specifik kontakt");
        Console.WriteLine("------------------------------");
        Console.Write("Ange e-postadress: ");
        var email = Console.ReadLine()!.Trim().ToLower();
        var contact = _contactManager.GetContact(contact => contact.Email == email);

        if (contact != null)
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} {contact.Address} {contact.City} {contact.PostalCode} {contact.Country}");
        else 
            Console.WriteLine($"Kunde inte hitta någon kontakt med e-postadressen {email}");

        Console.ReadKey();
    }
    public void UpdateMenu()
    {
        throw new NotImplementedException();
    } 
    public void DeleteMenu()
    {
        Console.Clear();
        Console.WriteLine("Ange e-postadress: ");
        var emailAddress = Console.ReadLine();
        try
        {
            _contactManager.Remove(new string(emailAddress));
        }
        catch { }
    }
}

using ContactList_Project_Test2.Models;
using System;

namespace ContactList_Project_Test2.Services;

public interface IMenuManage
{
    public void MainMenu();
    public void CreateMenu();
    public void DeleteMenu();
    public void ListSpecificMenu();
    public void ListAllMenu();
}
public class MenuManage : IMenuManage
{
    private readonly IContactManage _contactManage = new ContactManage();
    
    public void MainMenu()
    {
        var exit = false;

        do
        {
            Console.Clear();
            Console.WriteLine("------------------ MENY ------------------");
            Console.WriteLine("1. Skapa en ny kontakt");
            Console.WriteLine("2. Visa en specifik kontakt");
            Console.WriteLine("3. Visa alla kontakter");
            Console.WriteLine("4. Radera en kontakt");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Välj ett av ovanstående alternativ (0-4): ");
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
        Console.WriteLine("Lägg till en ny kontakt");
        Console.WriteLine("-----------------------");

        var contact = new Contact(); // Object för att spara in all info

        Console.Write("Förnamn: ");
        contact.FirstName = Console.ReadLine()!.Trim();

        Console.Write("Efternamn: ");
        contact.LastName = Console.ReadLine()!.Trim();

        Console.Write("E-postadress: ");
        contact.Email = Console.ReadLine()!.Trim().ToLower();

        Console.Write("Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine()!.Trim();

        Console.WriteLine();
        Console.WriteLine("Fullständig adress");
        Console.WriteLine("-----------------------");

        contact.FullAddress = new Address();

        Console.Write("Gata: ");
        contact.FullAddress.Street = Console.ReadLine()!.Trim();

        Console.Write("Gatunummer: ");
        contact.FullAddress.StreetNumber = Console.ReadLine()!.Trim();

        Console.Write("Stad: ");
        contact.FullAddress.City = Console.ReadLine()!.Trim();

        Console.Write("Postnummer: ");
        contact.FullAddress.PostalCode = Console.ReadLine()!.Trim();

        Console.Write("Land: ");
        contact.FullAddress.Country = Console.ReadLine()!.Trim();

        _contactManage.CreateContact(contact);

        Console.Clear();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("En ny kontakt har blivit tillagd i adressboken!");
        Console.ReadKey();
    }

    public void DeleteMenu()
    {
        Console.Clear();
        Console.WriteLine("Ange e-postadress: ");
        Console.WriteLine("-------------------");

        var email = Console.ReadLine()!.Trim().ToLower();
        var contact = _contactManage.GetSpecific(contact => contact.Email == email);
        
        if (contact != null)
        {
            Console.Clear();
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} - {contact.FullAddress.FullAddress}");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Tryck på valfri knapp för att radera kontakt");
            Console.ReadKey();

            try
            {
                _contactManage.DeleteContact(new string(email));
            }
            catch { }

            Console.Clear();
            Console.WriteLine("Din valda kontakt har nu blivit borttagen från adressboken");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine($"Kunde inte hitta någon kontakt med e-postadress <{email}>");
            Console.ReadKey();
        }
    }

    public void ListAllMenu()
    {
        Console.Clear();
        Console.WriteLine("Alla kontakter");
        Console.WriteLine("------------------------------");

        if (_contactManage.GetAll() != null)
        {
            foreach (var contact in _contactManage.GetAll())
                Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} - {contact.FullAddress.FullAddress}");
        }
        else
        {
            Console.WriteLine("Kontaktlistan är tom. Det finns inga kontakter att visa.");
        }
        Console.ReadKey();
    }

    public void ListSpecificMenu()
    {
        Console.Clear();
        Console.WriteLine("Specifik kontakt");
        Console.WriteLine("------------------------------");
        Console.Write("Ange e-postadress: ");

        var email = Console.ReadLine()!.Trim().ToLower();
        var contact = _contactManage.GetSpecific(contact => contact.Email == email);

        if (contact != null)
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} - {contact.FullAddress.FullAddress}");
        else
            Console.WriteLine($"Kunde inte hitta någon kontakt med e-postadressen <{email}>");

        Console.ReadKey();
    }

}




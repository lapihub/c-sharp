using ContactList_FinalProject.Models;

namespace ContactList_FinalProject.Services;


public interface IMenuManage
{
    public void MainMenu();
    public void CreateMenu();
    public void UpdateMenu();
    public void DeleteMenu();
    public void ListSpecificMenu();
    public void ListAllMenu();
}

public class MenuManager : IMenuManage
{
    private readonly IContactManager _contactManager = new ContactManager(); // En instans till ContactManager
    
    public void MainMenu()
    {
        var exit = false;

        do
        {
            Console.Clear();
            Console.WriteLine("------------ MENY ------------");
            Console.WriteLine("1. Lägg till en ny kontakt");
            Console.WriteLine("2. Visa en specifik kontakt");
            Console.WriteLine("3. Visa alla kontakter");
            Console.WriteLine("4. Uppdatera en kontakt");
            Console.WriteLine("5. Ta bort en kontakt");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Välj ett av ovanstående alternativ (0-5): ");
            var option = Console.ReadLine();

            switch (option!.ToLower()) // vi använder switch för att skicka användare visare beroende på option de matat in. 
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
        Console.WriteLine("Lägg till en ny kontakt");
        Console.WriteLine("-----------------------");

        var contact = new Contact(); // Object för att spara in all info. En instans. 

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

        Console.Write("Gatuadress: ");
        contact.FullAddress.Street = Console.ReadLine()!.Trim();

        Console.Write("Stad: ");
        contact.FullAddress.City = Console.ReadLine()!.Trim();

        Console.Write("Postnummer: ");
        contact.FullAddress.PostalCode = Console.ReadLine()!.Trim();

        Console.Write("Land: ");
        contact.FullAddress.Country = Console.ReadLine()!.Trim();

        _contactManager.CreateContact(contact); // Sparar in info till metoden från ContactManager klassen. 

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
        var contact = _contactManager.GetSpecific(contact => contact.Email == email);

        if (contact != null)
        {
            Console.Clear();
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} - {contact.FullAddress.FullAddress}");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Tryck på valfri knapp för att radera kontakt.");
            Console.ReadKey();

            try
            {
                _contactManager.DeleteContact(new string(email)); // här raderas kontakten baserat på email om matchen är rätt. 
            }
            catch { }

            Console.Clear();
            Console.WriteLine("Din valda kontakt har nu blivit borttagen från adressboken!");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Kunde inte hitta någon kontakt med e-postadress <{email}>");
            Console.ReadKey();
        }
    }

    public void ListAllMenu()
    {
        Console.Clear();
        Console.WriteLine("Alla kontakter");
        Console.WriteLine("------------------------------");

        var contactList = _contactManager.GetAll();
        if (contactList.Count() > 0) // om vår lista ej innehåller element över 0, skriver vi ut meningen längst ner på denna kod. 
        {
            foreach (var contact in _contactManager.GetAll()) // foreach loop körs och hämtar alla kontakter från listan. 
                if (contact != null)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} - {contact.FullAddress.FullAddress}");
                }
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
        var contact = _contactManager.GetSpecific(contact => contact.Email == email); // hämtar ut en specifik kontakt baserat på email. 

        if (contact != null)
        {
            Console.WriteLine();
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} \n{contact.FullAddress.FullAddress}");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"Kunde inte hitta någon kontakt med e-postadress <{email}>");

        }

        Console.ReadKey();
    }

    public void UpdateMenu()
    {
        Console.Clear();
        Console.WriteLine("Uppdatera en kontakt");
        Console.WriteLine("--------------------");
        Console.Write("Ange e-postadress: ");
        var email = Console.ReadLine()!.Trim().ToLower();

        var contact = _contactManager.GetSpecific(x => x.Email == email);
        if (contact != null)
        {
            Console.Clear();
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} \n{contact.FullAddress.FullAddress}");

            Console.WriteLine();
            Console.WriteLine("Uppdatera de fält där ändringar önskas. Lämna övriga fält tomma.");
            Console.WriteLine();

            Console.Write("Nytt förnamn: ");
            var newFirstName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newFirstName)) contact.FirstName = newFirstName;

            Console.Write("Nytt efternamn: ");
            var newLastName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newLastName)) contact.LastName = newLastName;

            Console.Write("Nytt telefonnummer: ");
            var newPhoneNumber = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPhoneNumber)) contact.PhoneNumber = newPhoneNumber;

            Console.Write("Ny e-postadress: ");
            var newEmail = Console.ReadLine()?.Trim().ToLower();
            if (!string.IsNullOrEmpty(newEmail)) contact.Email = newEmail;

            Console.Write("Ny gatuadress: ");
            var newStreetName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newStreetName)) contact.FullAddress!.Street = newStreetName;

            Console.Write("Nytt postnummer: ");
            var newPostalCode = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPostalCode)) contact.FullAddress!.PostalCode = newPostalCode;

            Console.Write("Ny stad: ");
            var newCity = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCity)) contact.FullAddress!.City = newCity;

            Console.Write("Nytt land: ");
            var newCountry = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCountry)) contact.FullAddress!.Country = newCountry;

            _contactManager.UpdateContact(contact); // sparar in alla ändringar som gjorts i UpdaterContact för kontakten 

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Din kontakt är nu uppdaterad!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Kunde inte hitta någon kontakt med e-postadress <{email}>. Ingen ändring gjordes.");
        }
        Console.ReadKey();
    }
}

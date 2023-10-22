using ContactList_FinalProject.Models;
using ContactList_FinalProject.Services;

namespace ContactList.UnitTests
{
    public class ContactManagerTests
    {
        [Fact]
        public void CreateContact_ShouldAddToContactList_ReturnTrue()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(); // Vi skapar en instans f�r att testa metoden

            Contact contact = new Contact() // h�r skapas en kontakt f�r testet
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                PhoneNumber = "Test",

                FullAddress = new Address
                {
                    Street = "Test",
                    PostalCode = "Test",
                    City = "Test",
                    Country = "Test",
                }
            };

            // Act - vi h�mtar metoden CreateContact och sparar ner testkontakten 
            bool result = contactManager.CreateContact(contact); 

            // Assert - h�r ska resultat visas true om testkontakten har lagts in i listan. 
            Assert.True(result); 
        }
    }
}
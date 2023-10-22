using ContactList_Project_Test3.Models;
using ContactList_Project_Test3.Services;

namespace ContactList_UnitTest;

public class ContactManagerTest
{
    [Fact]
    public void CreateContact_ShouldAddToContactList_ReturnTrue()
    {
        // Arrange
        ContactManager contactManager = new ContactManager();

        Contact contact = new Contact()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "Test",
            PhoneNumber = "Test",

            FullAddress = new Address
            {
                Street = "Test",
                StreetNumber = "Test",
                City = "Test",
                PostalCode = "Test",
                Country = "Test",
            }
        };

        // Act
        bool result = contactManager.CreateContact(contact);

        // Assert
        Assert.True(result);

    }
}
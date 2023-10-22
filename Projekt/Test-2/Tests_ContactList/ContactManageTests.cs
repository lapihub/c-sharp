using ContactList_Project_Test2.Models;
using ContactList_Project_Test2.Services;

namespace Tests_ContactList
{
    public class ContactManageTests
    {
        [Fact]
        public void CreateContact_ShouldAddToContactList_ReturnTrue()
        {
            // Arrange
            IContactManage contactManage = new ContactManage();
            Contact contact = new Contact();

            // Act
            bool result = contactManage.CreateContact(contact);


            // Assert
            Assert.True(result);
        }
    }
}
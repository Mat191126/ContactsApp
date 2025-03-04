using ContactAppProject.models;

namespace ContactAppProject.Test;

public class ContactTest
{
    [Fact]
    public void Constructor_SetsAllPropertiesCorrectly()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "john@doe.com";
        string phone = "0888888888";
        
        //Act
        Contact contact = new Contact(firstName, lastName, email, phone);
        
        //Assert
        Assert.Equal(firstName, contact.FirstName);
        Assert.Equal(lastName, contact.LastName);
        Assert.Equal(email, contact.Email);
        Assert.Equal(phone, contact.PhoneNumber);
    }

    [Fact]
    public void ToString_ReturnsCorrectString()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "john@doe.com";
        string phone = "0888888888";
        Contact contact = new Contact(firstName, lastName, email, phone);
        
        //Act
        var result = contact.ToString();
        
        //Assert
        Assert.Equal($"Name: {firstName} {lastName}, Email: {email}, Phone: {phone}", result);
        
    }
}
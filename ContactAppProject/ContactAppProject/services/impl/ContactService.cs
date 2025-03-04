using System.Text.RegularExpressions;
using ContactAppProject.models;

namespace ContactAppProject.services.impl;

public class ContactService : IContactService
{
    private readonly List<Contact> _contacts = new();
    
    public void AddNewContact()
    {
        Console.WriteLine("\n=== Add new contact ===");
        
        string firstName = ReadNonEmptyInput("Enter first name:");
        string lastName = ReadNonEmptyInput("Enter last name:");
        string email = ReadValidEmail("Enter email:");
        string phoneNumber = ReadValidPhoneNumber("Enter Phone number:");
        
        _contacts.Add(new Contact(firstName, lastName, email, phoneNumber));
        Console.WriteLine("New contact added");
    }

    public void ShowContacts()
    {
        Console.WriteLine("\n=== All contacts list ===");
        if (_contacts.Count == 0)
        {
            Console.WriteLine("No contacts found");
            return;
        }

        TablePrinter.PrintContacts(_contacts);
    }

    public void SearchContact()
    {
        Console.WriteLine("\n=== Search contacts ===");
        string searchName = ReadNonEmptyInput("Enter first name:");
        
        var foundContact = _contacts.FindAll(contact => contact.FirstName.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundContact.Count == 0)
        {
            Console.WriteLine("No contacts found");
            return;
        }

        Console.WriteLine("\nFound matching contact(s):");
        TablePrinter.PrintContacts(foundContact);
    }

    private string ReadNonEmptyInput(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine()?.Trim();
        
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("!!! Improper data");
            return ReadNonEmptyInput(prompt);
        }
        
        return input;
    }

    private string ReadValidEmail(string prompt)
    {
        Console.WriteLine(prompt);
        string email = Console.ReadLine()?.Trim();
        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        
        if (string.IsNullOrEmpty(email) || !emailRegex.IsMatch(email))
        {
            Console.WriteLine("!!! Improper email");
            return ReadValidEmail(prompt);
        }
        
        return email;
    }

    private string ReadValidPhoneNumber(string prompt)
    {
        Console.WriteLine(prompt);
        string phoneNumber = Console.ReadLine()?.Trim();
        var phoneRegex = new Regex(@"^\d{9}$");
        
        if (string.IsNullOrEmpty(phoneNumber) || !phoneRegex.IsMatch(phoneNumber))
        {
            Console.WriteLine("!!! Improper phone number");
            return ReadValidPhoneNumber(prompt);
        }
        
        return phoneNumber;
    }
}

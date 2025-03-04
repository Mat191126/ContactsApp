using System.Text.RegularExpressions;
using ContactAppProject.models;

namespace ContactAppProject.services.impl;

public class ContactService : IContactService
{
    private readonly IJsonService _jsonService;
    private readonly List<Contact> _contacts = new();

    public ContactService(IJsonService jsonService)
    {
        this._jsonService = jsonService;
    }

    public void AddNewContact()
    {
        Console.WriteLine("\n=== Add new contact ===");

        string firstName = ReadNonEmptyInput("Enter first name:");
        string lastName = ReadNonEmptyInput("Enter last name:");
        string email = ReadValidEmail("Enter email:");
        string phoneNumber = ReadValidPhoneNumber("Enter Phone number:");

        RefreshContactList();
        _contacts.Add(new Contact(firstName, lastName, email, phoneNumber));
        _jsonService.SaveToFile(_contacts);
        Console.WriteLine("New contact added");
    }

    public void ShowContacts()
    {
        RefreshContactList();
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
        RefreshContactList();
        Console.WriteLine("\n=== Search contacts ===");
        string searchName = ReadNonEmptyInput("Enter first name:");

        var foundContact = _contacts
            .FindAll(contact => contact.FirstName.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundContact.Count == 0)
        {
            Console.WriteLine("No contacts found");
            return;
        }

        Console.WriteLine("\nFound matching contact(s):");
        TablePrinter.PrintContacts(foundContact);
    }

    public void RemoveContact()
    {
        Console.WriteLine("\n=== Remove contact ===");

        string firstName = ReadNonEmptyInput("Enter first name:");
        string lastName = ReadNonEmptyInput("Enter last name:");

        var foundContacts = _contacts.Where(contact =>
            contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
            contact.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)
        ).ToList();

        if (foundContacts.Count == 0)
        {
            Console.WriteLine("No contacts found with this name.");
            return;
        }

        if (foundContacts.Count == 1)
        {
            _contacts.Remove(foundContacts.First());
            _jsonService.SaveToFile(_contacts);
            Console.WriteLine("Contact removed successfully.");
            return;
        }

        Console.WriteLine("There is more people with this data:");
        TablePrinter.PrintContacts(foundContacts);

        string additionalData = ReadNonEmptyInput("Enter email or phone number to identify the person:");

        if (additionalData.Contains("@"))
        {
            var contactToRemove =
                foundContacts.FirstOrDefault(c => c.Email.Equals(additionalData, StringComparison.OrdinalIgnoreCase));
            if (contactToRemove != null)
            {
                _contacts.Remove(contactToRemove);
                _jsonService.SaveToFile(_contacts);
                Console.WriteLine("Contact removed successfully.");
            }
            else
            {
                Console.WriteLine("No contact found with the provided email.");
            }
        }
        else
        {
            var contactToRemove = foundContacts.FirstOrDefault(c => c.PhoneNumber.Equals(additionalData));
            if (contactToRemove != null)
            {
                _contacts.Remove(contactToRemove);
                _jsonService.SaveToFile(_contacts);
                Console.WriteLine("Contact removed successfully.");
            }
            else
            {
                Console.WriteLine("No contact found with the provided phone number.");
            }
        }
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

    private void RefreshContactList()
    {
        _contacts.Clear();
        _contacts.AddRange(_jsonService.ReadFromFile()!);
    }
}
using ContactAppProject.models;

namespace ContactAppProject.services;

public class ContactService
{
    List<Contact> contacts = new List<Contact>();
    
    public void AddNewContact()
    {
        Console.WriteLine("\n=== Add new contact ===");
        Console.WriteLine("Enter first name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter last name:");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter email:");
        string email = Console.ReadLine();
        Console.WriteLine("Enter Phone number:");
        string phoneNumber = Console.ReadLine();
        contacts.Add(new Contact(firstName, lastName, email, phoneNumber));
        Console.WriteLine("New contact added");
    }

    public void ShowContacts()
    {
        Console.WriteLine("\n=== All contacts list ===");
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found");
            return;
        }

        TablePrinter.PrintContacts(contacts);
    }

    public void SearchContact()
    {
        Console.WriteLine("\n=== Search contacts ===");
        Console.WriteLine("Enter first name:");
        string searchName = Console.ReadLine();
        var foundContact = contacts.FindAll(contact => contact.FirstName.Contains(searchName)).ToList();

        if (foundContact.Count == 0)
        {
            Console.WriteLine("No contacts found");
            return;
        }

        Console.WriteLine("\nFound matching contact(s):");
        TablePrinter.PrintContacts(foundContact);
    }
}
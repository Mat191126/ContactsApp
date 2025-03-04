using ContactAppProject;

class Program
{
    static void Main(string[] args)
    {
        List<Contact> contacts = new List<Contact>();
        string userInput;
        Console.WriteLine("< Welcome to the Contact App! >");

        do
        {
            Console.WriteLine("\nEnter option number:");
            Console.WriteLine("1 - add new contact");
            Console.WriteLine("2 - show all contacts");
            Console.WriteLine("3 - search by name");
            Console.WriteLine("4 - exit");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    MoveAndClear();
                    AddNewContact(contacts);
                    break;
                case "2":
                    MoveAndClear();
                    ShowContacts(contacts);
                    break;
                case "3":
                    MoveAndClear();
                    SearchContact(contacts);
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    MoveAndClear();
                    Console.WriteLine("Invalid option.");
                    break;
                
            }
            
        } while (userInput != "4");
    }

    private static void AddNewContact(List<Contact> contacts)
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

    private static void ShowContacts(List<Contact> contacts)
    {
        Console.WriteLine("\n=== All contacts list ===");
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found");
            return;
        }

        TablePrinter.PrintContacts(contacts);
    }

    private static void SearchContact(List<Contact> contacts)
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
    
    private static void MoveAndClear() {
        Console.WriteLine("\n \n \n \n \n \n");
        Console.Clear();
    }
}
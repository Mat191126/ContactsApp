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
                    AddNewContact(contacts);
                    break;
                case "2":
                    ShowContacts(contacts);
                    break;
                case "3":
                    SearchContact(contacts);
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
                
            }
            
        } while (userInput != "4");
    }

    private static void AddNewContact(List<Contact> contacts)
    {
        Console.WriteLine("\n=== Add new contact ===");
        Console.WriteLine("Enter first name:");
        string FirstName = Console.ReadLine();
        Console.WriteLine("Enter last name:");
        string LastName = Console.ReadLine();
        Console.WriteLine("Enter email:");
        string Email = Console.ReadLine();
        Console.WriteLine("Enter Phone number:");
        string PhoneNumber = Console.ReadLine();
        contacts.Add(new Contact(FirstName, LastName, Email, PhoneNumber));
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

        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    private static void SearchContact(List<Contact> contacts)
    {
        
    }
}
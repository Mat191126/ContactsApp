using ContactAppProject.services;
using ContactAppProject.services.impl;

namespace ContactAppProject;
class Program
{
    private static void Main(string[] args)
    {
        string userInput;
        IContactService contactService = new ContactService(new JsonService());
        Console.WriteLine("< Welcome to the Contact App! >");
        
        do
        {
            Console.WriteLine("\nEnter option number:");
            Console.WriteLine("1 - show all contacts");
            Console.WriteLine("2 - add new contact");
            Console.WriteLine("3 - delete contact");
            Console.WriteLine("4 - search by name");
            Console.WriteLine("5 - exit");
            userInput = Console.ReadLine()!;

            switch (userInput)
            {
                case "1":
                    MoveAndClear();
                    contactService.ShowContacts();
                    break;
                case "2":
                    MoveAndClear();
                    contactService.AddNewContact();
                    break;
                case "3":
                    MoveAndClear();
                    contactService.RemoveContact();
                    break;
                case "4":
                    MoveAndClear();
                    contactService.SearchContact();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    MoveAndClear();
                    Console.WriteLine("Invalid option.");
                    break;
                
            }
            
        } while (userInput != "4");
    }
    
    private static void MoveAndClear() {
        Console.WriteLine("\n \n \n \n \n \n");
        Console.Clear();
    }
}
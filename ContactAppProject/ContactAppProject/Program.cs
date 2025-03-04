using ContactAppProject.services;
using ContactAppProject.services.impl;

namespace ContactAppProject;
class Program
{
    private static void Main(string[] args)
    {
        string userInput;
        IContactService contactService = new ContactService();
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
                    contactService.AddNewContact();
                    break;
                case "2":
                    MoveAndClear();
                    contactService.ShowContacts();
                    break;
                case "3":
                    MoveAndClear();
                    contactService.SearchContact();
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
    
    private static void MoveAndClear() {
        Console.WriteLine("\n \n \n \n \n \n");
        Console.Clear();
    }
}
using ContactAppProject.models;

namespace ContactAppProject;

using System;
using System.Collections.Generic;
using System.Linq;

public class TablePrinter
{
    public static void PrintContacts(List<Contact> contacts)
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts to display.");
            return;
        }
        
        string[] headers = { "First Name", "Last Name", "Email", "Phone Number" };

        int[] columnWidths = new int[4];
        columnWidths[0] = Math.Max(headers[0].Length, contacts.Max(c => c.FirstName.Length));
        columnWidths[1] = Math.Max(headers[1].Length, contacts.Max(c => c.LastName.Length));
        columnWidths[2] = Math.Max(headers[2].Length, contacts.Max(c => c.Email.Length));
        columnWidths[3] = Math.Max(headers[3].Length, contacts.Max(c => c.PhoneNumber.Length));

        string separator = "+" + string.Join("+", columnWidths.Select(w => new string('-', w + 2))) + "+";

        Console.WriteLine(separator);
        Console.WriteLine("| " + headers[0].PadRight(columnWidths[0]) + " | "
                          + headers[1].PadRight(columnWidths[1]) + " | "
                          + headers[2].PadRight(columnWidths[2]) + " | "
                          + headers[3].PadRight(columnWidths[3]) + " |");
        Console.WriteLine(separator);

        foreach (var contact in contacts)
        {
            Console.WriteLine("| " + contact.FirstName.PadRight(columnWidths[0]) + " | "
                              + contact.LastName.PadRight(columnWidths[1]) + " | "
                              + contact.Email.PadRight(columnWidths[2]) + " | "
                              + contact.PhoneNumber.PadRight(columnWidths[3]) + " |");
        }

        Console.WriteLine(separator);
    }
}
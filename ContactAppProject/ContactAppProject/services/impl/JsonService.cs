using System.Text.Json;
using ContactAppProject.models;

namespace ContactAppProject.services.impl;

public class JsonService : IJsonService
{
    private static readonly string FilePath = GetFilePath();

    public void SaveToFile(List<Contact> contacts)
    {
        var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions  { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    public List<Contact>? ReadFromFile()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Contact>>(json);
        }

        return new List<Contact>();
    }
    
    private static string GetFilePath()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        
        // solution for Rider environment
        if (baseDirectory.Contains(@"\bin\Debug\net9.0"))
        {
            baseDirectory = baseDirectory.Replace(@"\bin\Debug\net9.0", string.Empty);
        }

        return Path.Combine(baseDirectory, "data", "contacts.json");
    }
}
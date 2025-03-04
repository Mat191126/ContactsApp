using ContactAppProject.models;

namespace ContactAppProject.services;

public interface IJsonService
{
    void SaveToFile(List<Contact> contacts);
    List<Contact>? ReadFromFile();
}
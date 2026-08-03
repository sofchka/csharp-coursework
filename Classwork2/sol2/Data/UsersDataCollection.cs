using Classwork2.Model;
namespace Classwork2.Data;

public class UsersDataCollection
{
    private readonly CsvProcessing _csv = new CsvProcessing();
    public List<User> Users { get; }

    public UsersDataCollection(string filename)
    {
        Users = _csv.ReadData(filename);
    }

    public void UsersDataSave(string filename)
    {
        _csv.WriteData(filename, Users);
        Console.WriteLine("\nYour File is ready: " + filename);
    }
}
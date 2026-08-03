using Classwork2.Csv;

namespace Classwork2.Model;

public class UsersDataCollection
{
    private readonly CsvProcessing _csv = new CsvProcessing();
    public List<User> Users { get; }

    public UsersDataCollection(string filename)
    {
        Users = _csv.ReadData(filename);
    }
}
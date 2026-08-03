using Classwork2.Model;

namespace Classwork2.Csv;

public class CsvProcessing
{
    public List<User> ReadData(string fileName)
    {
        var userCollection = new List<User>()
        {
            new User("Syuzi", new DateTime(2020, 1, 1)),
            new User("Sofi", new DateTime(2030, 5, 5))
        };

        return userCollection;

    }
    
    public void WriteData(string fileName)
    {
        
    }
}
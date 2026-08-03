using Classwork2.Model;

namespace Classwork2.Csv;

public class CsvProcessing
{
    public List<User> ReadData(string fileName)
    {
        List<User> users = new(); // list is flexible (for adding (array no)
        foreach (string line in File.ReadLines(fileName))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;
            
            string[] fields = line.Split(',');
            
            if (fields.Length < 3 || string.IsNullOrWhiteSpace(fields[0]))
                continue;
            users.Add(new User(fields[0], fields[1], fields[2]));
        }

        return users;
    }
    
    public void WriteData(string fileName, List<User> users)
    {
        using StreamWriter writer = new StreamWriter(fileName);

        foreach (User user in users)
        {
            writer.WriteLine($"{user.Name},{user.BirthDate:dd.MM.yyyy},{user.Status}");
        }
    }
}
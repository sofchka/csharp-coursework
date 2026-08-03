using Classwork2.Model;

namespace Classwork2.Csv;

public class CsvProcessing
{
    public List<User> ReadData(string fileName)
    {
        List<User> listofUsers = new List<User>(); // list is flexible (for adding (array no)
        foreach (var line in File.ReadLines(fileName))
        {
            if (line == "")
                continue;
            string[] fields = line.Split(',');
            if (fields[0] == "")
                continue;
            if (fields.Length >= 3)
            {
                User newUser = new User(fields[0], fields[1], fields[2]);
                listofUsers.Add(newUser);
            }
        }

        return listofUsers;
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
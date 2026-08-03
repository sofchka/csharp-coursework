namespace Classwork2.Model;

public class User
{
    public string Name { get; set; }
    public string Status { get; set; }
    public DateTime BirthDate { get; set; }
    

    public User(string name, String birthDate, string status)
    {
        Name = name;
        Status = status;
        if (!DateTime.TryParse(birthDate, out DateTime date))
        {
            throw new ArgumentException("Invalid birth date");
        }

        BirthDate = date;
    }
}
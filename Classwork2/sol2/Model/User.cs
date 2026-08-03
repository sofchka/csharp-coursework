namespace Classwork2.Model;

public class User
{
    public string Name { get; set; } = "";
    public DateTime BirthDate { get; set; }

    public User(string name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
    }
}
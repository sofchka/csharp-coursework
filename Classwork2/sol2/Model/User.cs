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
        string[] dateFields = [];
        if (birthDate.Length > 3)
        {
            switch (birthDate[2])
            {
                case ':':
                    dateFields = birthDate.Split(':');
                    break;
                case '|':
                    dateFields = birthDate.Split('|');
                    break;
                case '/':
                    dateFields = birthDate.Split('/');
                    break;
                case '.':
                    dateFields = birthDate.Split('.');
                    break;
                default:
                    dateFields = new[] { "01", "01", "01" };
                    break;
            }
        }
        if (dateFields.Length >= 3 &&
            int.TryParse(dateFields[0], out int day) &&
            int.TryParse(dateFields[1], out int month) &&
            int.TryParse(dateFields[2], out int year))
        {
            try
            {
                BirthDate = new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(year);
                Console.WriteLine(month);
                Console.WriteLine(day);
                
                Console.WriteLine("Not Valid Date Input.");
            }
        }
        else
        {
            Console.WriteLine("Not valid");
        }
    }
}
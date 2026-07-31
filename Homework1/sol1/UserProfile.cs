namespace Homework1;

public class UserProfile
{
    private string _name;
    private int _age;
    private string _favoriteColor;
    private int _height;

    public UserProfile()
    {
        _name = "";
        _favoriteColor = "";
    }
    
    public void ReadInfo()
    {
        Console.WriteLine("Enter your Name: ...");
        _name = Console.ReadLine() ?? ""; // if input is null take ""
        
        Console.WriteLine("Enter your Age: ...");
        while (!int.TryParse(Console.ReadLine(), out _age)) //false if not a number
            Console.WriteLine("Enter your Valid Age: ...");
        
        Console.WriteLine("Enter your Favorite color: ...");
        _favoriteColor = Console.ReadLine() ?? "";
        // _favoriteColor = Console.ReadLine()!; //null-forgiving operator
        
        Console.WriteLine("Enter your Height in cm: ...");
        while (!int.TryParse(Console.ReadLine(), out _height))
            Console.WriteLine("Enter your Valid Height: ...");
        //_height = Convert.ToInt16(Console.ReadLine());
    }

    public void InfoLogging()
    {
        Console.WriteLine("--------------------\nPROFILE\nName: " + _name + "\nAge: " 
                          + _age + "\nFavorite Color: " + _favoriteColor + "\nHeight: " + _height 
                          + " cm\n--------------------");
    }
}
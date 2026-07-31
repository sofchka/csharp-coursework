namespace sol2;

public class Program
{
    static void Main()
    {
        MacOsFactory macbook = new MacOsFactory();
        var macButton = macbook.CreateButton();
        var macCheckBox = macbook.CreateCheckBox();
        
        Console.WriteLine(macButton.A);
        Console.WriteLine(macCheckBox.A);
        
        WindowsFactory laptop = new WindowsFactory();
        var winButton = laptop.CreateButton();
        var winCheckBox = laptop.CreateCheckBox();
        
        Console.WriteLine(winButton.A);
        Console.WriteLine(winCheckBox.A);
    }
}
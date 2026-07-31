using Calculator;

public class Program
{
    static void Main()
    {
        var coffeeHouse = new Store();
        Console.WriteLine("Our Menu\n1) Sev Kofe\n2) Tea\n3) Cappuccino\n4) Dolce Gusto\n  ...Enter Coffee Name");
        var input = Console.ReadLine();
        var order = coffeeHouse.Create(input!);
        Console.WriteLine("Answer!");
        Console.WriteLine(order);
    }  
}

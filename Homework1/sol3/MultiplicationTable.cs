namespace sol3;

public class MultiplicationTable
{
    private int _num;
    
    public void ReadInfo()
    {
        Console.WriteLine("Enter Your Number: ...");
        while (!int.TryParse(Console.ReadLine(), out _num))
            Console.WriteLine("Enter Valid Number: ...");
    }

    public void PrintTable()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(_num + " x " + i + " = " + (i * _num));
        }
    }
}
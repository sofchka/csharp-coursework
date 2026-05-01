using System;
using Task2_BigNumbers;

class Program
{
    static void Main()
    {
        int a = int.MaxValue;
        Console.WriteLine(unchecked(a + 1));

        long b = long.MaxValue;
        Console.WriteLine(unchecked(b + 1));

        Console.WriteLine();

        Console.WriteLine(BigNumCalculator.Add("9999", "1"));          // 10000
        Console.WriteLine(BigNumCalculator.Subtract("10000", "1"));   // 9999
        Console.WriteLine(BigNumCalculator.Multiply("123", "456"));   // 56088

        Console.WriteLine();

        Console.WriteLine(BigNumCalculator.Add("-50", "20"));         // -30
        Console.WriteLine(BigNumCalculator.Subtract("5", "10"));      // -5
        Console.WriteLine(BigNumCalculator.Multiply("-12", "-3"));    // 36

        Console.WriteLine();

        Console.WriteLine(BigNumCalculator.Add("abc", "5"));          // 5
        Console.WriteLine(BigNumCalculator.Multiply("", "100"));      // 0
    }
}
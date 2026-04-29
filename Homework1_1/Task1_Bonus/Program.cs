using System;
using Task1_Bonus;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== Bonus — IEEE 754 double =====\n");

        double number = 12.375;

        string bits = DoubleBitWizard.ToBits(number);

        Console.WriteLine($"Original double: {number}");
        Console.WriteLine($"64-bit bits:     {bits}");

        Console.WriteLine();

        string prettyBits = DoubleBitWizard.ToBits(number, pretty: true);

        Console.WriteLine("Pretty format:");
        Console.WriteLine(prettyBits);

        Console.WriteLine();

        double backToDouble = DoubleBitWizard.FromBits(bits);

        Console.WriteLine($"Back to double:  {backToDouble}");

        Console.WriteLine();

        double negativeNumber = -12.375;

        string negativeBits = DoubleBitWizard.ToBits(negativeNumber, pretty: true);
        double backNegative = DoubleBitWizard.FromBits(negativeBits);

        Console.WriteLine("Negative number test:");
        Console.WriteLine($"Original double: {negativeNumber}");
        Console.WriteLine($"Pretty bits:     {negativeBits}");
        Console.WriteLine($"Back to double:  {backNegative}");
    }
}
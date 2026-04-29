using System;
using Task1_Converter;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== Task 1 — IEEE 754 float =====\n");

        string bits = FloatBitWizard.ToBits(12.375f);
        Console.WriteLine($"12.375f bits:   {bits}");

        string prettyBits = FloatBitWizard.ToBits(12.375f, pretty: true);
        Console.WriteLine($"12.375f pretty: {prettyBits}");

        float backToFloat = FloatBitWizard.FromBits(bits);
        Console.WriteLine($"Back to float:  {backToFloat}");
    }
}
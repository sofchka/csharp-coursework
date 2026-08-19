using System.ComponentModel;

namespace Math;
using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
            throw new Exception("Wrong Argument wrong usage");
        string operation = "";
        double a1 = 0;
        double a2 = 0;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--add":
                    operation = "add";
                    break;

                case "--mult":
                    operation = "mult";
                    break;

                case "--sub":
                    operation = "sub";
                    break;

                case "--div":
                    operation = "div";
                    break;

                case "--a1":
                    a1 = double.Parse(args[++i]);
                    break;

                case "--a2":
                    a2 = double.Parse(args[++i]);
                    break;
            }
        }

        double result = operation switch
        {
            "add" => a1 + a2,
            "mult" => a1 * a2,
            "sub" => a1 - a2,
            "div" => a1 / a2,
            _ => throw new ArgumentException("Unknown operation")
        };

        Console.WriteLine(result);
    }
}

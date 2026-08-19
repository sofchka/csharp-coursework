namespace MathMultiThreading;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        ProcessStartInfo start = new ProcessStartInfo()
        {
            FileName = "/Users/sofi/alo123/Homework3/math/bin/Debug/net10.0/math",
            Arguments = "--add --a1 12 --a2 13",
            UseShellExecute = false,
            WorkingDirectory = Environment.CurrentDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        Process process = new Process()
        {
            StartInfo = start
        };

        process.Start();
        var output = process.StandardOutput.ReadToEnd();
        var outputerr = process.StandardError.ReadToEnd();

        Console.WriteLine(output);
        Console.WriteLine(outputerr);
    }
}
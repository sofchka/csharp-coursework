class Program
{
    static void Main()
    {
        FileHandler argument = new FileHandler();
        argument.Dispose();
        argument.Dispose();
        
        using (FileHandler arg = new FileHandler())
        {
            Console.WriteLine("==================== LOG =================");
        }
    }
}


public class FileHandler : IDisposable // vor usingi het ashxati
{
    public void Dispose()
    {
        Console.WriteLine("========= Logger disposed ==========="); // 1th
    }
    // 2nd dispose log after 
}
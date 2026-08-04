namespace Homework2;

class Program
{
    static void Main()
    {
        var request = new HttpRequestBuilder()
            .WithMethod("GET")
            .WithUrl("https://google.com")
            .WithTimeout(30)
            .Build();

        Console.WriteLine(request.Method);
    }
}
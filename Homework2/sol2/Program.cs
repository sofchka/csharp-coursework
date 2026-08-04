namespace sol2;

class Program
{
    static void Main()
    {
        var request = new HttpRequestBuilder()
            .WithMethod("POST")
            .WithUrl("https://api.example.com/login")
            .AddHeader("Set-Cookie", "user=John")
            .AddHeader("Set-Cookie", "session=abc123")
            .AddHeader("Content-Type", "application/json")
            .AddQueryParameter("version", "2")
            .WithBody("{ \"name\": \"John\" }")
            .WithTimeout(30)
            .WithAuthentication("token123")
            .Build();


        Console.WriteLine($"Method: {request.Method}");
        Console.WriteLine($"URL: {request.Url}");

        Console.WriteLine("\nHeaders:");
        foreach (var header in request.Headers)
        {
            Console.WriteLine($"{header.Key}:");

            foreach (var value in header.Value)
            {
                Console.WriteLine($"  - {value}");
            }
        }

        Console.WriteLine("\nQuery Parameters:");
        foreach (var query in request.QueryParameters)
        {
            Console.WriteLine($"{query.Key}:");

            foreach (var value in query.Value)
            {
                Console.WriteLine($"  - {value}");
            }
        }

        Console.WriteLine($"\nTimeout: {request.Timeout}");
        Console.WriteLine($"Token: {request.AuthenticationToken}");
    }
}
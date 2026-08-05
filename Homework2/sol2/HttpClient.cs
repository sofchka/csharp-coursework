namespace sol2;

public class HttpClient
{
    public void Send(HttpRequest request)
    {
        Console.WriteLine($"Method: {request.Method}");
        Console.Write("URL: ");
        Console.Write(request.Url);

        if (request.QueryParameters.Count > 0)
        {
            Console.Write("?");
            bool first = true;
            foreach (var query in request.QueryParameters)
            {
                if (!first)
                    Console.Write("&"); // https://api.example.com/users?page=2&limit=10 ....

                Console.Write($"{query.Key}={query.Value}");
                first = false;
            }
        }
        Console.WriteLine("\nHeaders:");

        foreach (var header in request.Headers)
        {
            foreach (var value in header.Value)
            {
                Console.WriteLine($"{header.Key}: {value}");
            }
        }

        Console.WriteLine($"\nTimeout: {request.Timeout}");

        if (!string.IsNullOrWhiteSpace(request.AuthenticationToken))
            Console.WriteLine($"Authentication: {request.AuthenticationToken}");
        else
            Console.WriteLine("Authentication: None");
    }
}
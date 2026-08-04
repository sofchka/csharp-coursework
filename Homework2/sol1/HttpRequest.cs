namespace Homework2;

public class HttpRequest
{
    public string Method { get; }
    public string Url { get; }
    public IReadOnlyDictionary<string, string> Headers { get; }
    public IReadOnlyDictionary<string, string> QueryParameters { get; }
    public string Body { get; }
    public int Timeout { get; }
    public string AuthenticationToken { get; }

    public HttpRequest(
        string method,
        string url,
        Dictionary<string, string> headers,
        Dictionary<string, string> queries,
        string body,
        string token,
        int seconds)
    {
        Method = method;
        Url = url;
        Body = body;
        AuthenticationToken = token;
        Timeout = seconds;

        // defensive copies for immutability
        Headers = new Dictionary<string, string>(headers);
        QueryParameters = new Dictionary<string, string>(queries);
    }
}

// karar liner
// private readonly string _method;
// public string Method => _method; // Method returns the private _method's value
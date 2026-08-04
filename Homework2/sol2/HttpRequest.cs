namespace sol2;

public class HttpRequest
{
    public string Method { get; }
    public string Url { get; }
    public IReadOnlyDictionary<string, List<string>> Headers { get; }
    public IReadOnlyDictionary<string, string> QueryParameters { get; }
    public string Body { get; }
    public int Timeout { get; }
    public string AuthenticationToken { get; }

    public HttpRequest(
        string method,
        string url,
        Dictionary<string, List<string>> headers,
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
        Headers = headers;
        QueryParameters = queries;
    }
}
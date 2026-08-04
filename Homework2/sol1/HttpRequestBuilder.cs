namespace Homework2;

public class HttpRequestBuilder
{
    private string _method = "";
    private string _url = "";
    private string _body = "";
    private string _token = "";
    private Dictionary<string, string> _headers = new Dictionary<string, string>();
    private Dictionary<string, string> _queries = new Dictionary<string, string>();
    private int _timeoutSeconds;
    
    public HttpRequestBuilder WithMethod(string method)
    {
        this._method = method;
        return this;
    }

    public HttpRequestBuilder WithUrl(string url)
    {
        this._url = url;
        return this;
    }

    public HttpRequestBuilder AddHeader(string key, string value)
    {
        if (_headers.ContainsKey(key))
            throw new ArgumentException("Duplicate header key");
        
        this._headers.Add(key, value);
        
        return this;
    }

    public HttpRequestBuilder AddQueryParameter(string key, string value)
    {
        if (_queries.ContainsKey(key))
            throw new ArgumentException("Duplicate query key");
        
        this._queries.Add(key, value);
        
        return this;
    }

    public HttpRequestBuilder WithBody(string body)
    {
        this._body = body;
        return this;
    }

    public HttpRequestBuilder WithTimeout(int seconds)
    {
        this._timeoutSeconds = seconds;
        return this;
    }

    public HttpRequestBuilder WithAuthentication(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Authentication token cannot be empty");
        this._token = token;
        return this;
    }

    public HttpRequest Build()
    {
        string[] allowedMethods = ["GET", "POST", "PUT", "DELETE"];
        
        _method = _method.Trim().ToUpper();
        if (!allowedMethods.Contains(_method))
            throw new ArgumentException("Not allowed method!");
        
        if (string.IsNullOrWhiteSpace(_url))
            throw new ArgumentException("URL is required");
        
        if (_timeoutSeconds <= 0)
            throw new ArgumentException("Timeout must be greater than zero!");

        if (_method == "GET" && !string.IsNullOrEmpty(_body))
            throw new InvalidOperationException("GET requests cannot contain a body.!");
        
        Console.WriteLine("Build Ended Successfully");
        return new HttpRequest(_method, _url, 
            new Dictionary<string,string>(_headers), // we make new because _headers is a reference and can be changed
            new Dictionary<string,string>(_queries), // our task was immutable so need a copy of header
            _body, _token, _timeoutSeconds);
    }
}
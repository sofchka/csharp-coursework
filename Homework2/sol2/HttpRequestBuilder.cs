namespace sol2;

public class HttpRequestBuilder : IHttpRequestBuilder
{
    private string _method = "";
    private string _url = "";
    private string _body = "";
    private string _token = "";
    private Dictionary<string, List<string>> _headers = new();
    private Dictionary<string, string> _queries = new();
    private int _timeoutSeconds;
    
    public IHttpRequestBuilder WithMethod(string method)
    {
        this._method = method;
        return this;
    }

    public IHttpRequestBuilder WithUrl(string url)
    {
        this._url = url;
        return this;
    }

    public IHttpRequestBuilder AddHeader(string key, string value)
    {
        if (_headers.ContainsKey(key))
        {
            _headers[key].Add(value);
            return this;
        }

        _headers.Add(key, [value]);
        
        return this;
    }

    public IHttpRequestBuilder AddQueryParameter(string key, string value)
    {
        if (_queries.ContainsKey(key))
            throw new ArgumentException("Duplicate query key");
        
        this._queries.Add(key, value);
        
        return this;
    }

    public IHttpRequestBuilder WithBody(string body)
    {
        this._body = body;
        return this;
    }

    public IHttpRequestBuilder WithTimeout(int seconds)
    {
        this._timeoutSeconds = seconds;
        return this;
    }

    public IHttpRequestBuilder WithAuthentication(string token)
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
            new Dictionary<string, List<string>>(_headers),
            new Dictionary<string,string>(_queries),
            _body, _token, _timeoutSeconds);
    }
    
    public IHttpRequestBuilder Reset()
    {
        _method = "";
        _url = "";
        _body = "";
        _token = "";
        _timeoutSeconds = 0;

        _headers.Clear();
        _queries.Clear();

        return this;
    }
}
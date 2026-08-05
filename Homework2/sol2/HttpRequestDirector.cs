namespace sol2;

public class HttpRequestDirector
{
    private readonly IHttpRequestBuilder _builder;

    public HttpRequestDirector()
    {
        _builder = new HttpRequestBuilder();
    }

    public HttpRequest CreateLoginRequest()
    {
        return _builder
            .Reset()
            .WithMethod("POST")
            .WithUrl("login_url")
            .AddHeader("Type", "json")
            .WithBody("login, password")
            .WithTimeout(30)
            .Build();
    }

    public HttpRequest CreateHealthCheckRequest()
    {
        return _builder
            .Reset()
            .WithMethod("GET")
            .WithUrl("health_check_url")
            .WithTimeout(5)
            .Build();
    }
}
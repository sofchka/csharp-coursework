namespace sol2;

public interface IHttpRequestBuilder
{
    IHttpRequestBuilder WithMethod(string method);

    IHttpRequestBuilder WithUrl(string url);

    IHttpRequestBuilder AddHeader(
        string key,
        string value);

    IHttpRequestBuilder AddQueryParameter(
        string key,
        string value);

    IHttpRequestBuilder WithBody(string body);

    IHttpRequestBuilder WithTimeout(int seconds);

    IHttpRequestBuilder WithAuthentication(string token);

    HttpRequest Build();

    IHttpRequestBuilder Reset();
}
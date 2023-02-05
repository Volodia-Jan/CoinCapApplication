namespace CoinAppClient;

/// <summary>
/// Provides a class for sending HTTP requests and receiving HTTP responses
/// </summary>
internal class CoinCapApiService
{
    private readonly HttpClient _http;

    public CoinCapApiService()
    {
        _http = new HttpClient();
    }

    /// <summary>
    /// Sedns HTTP GET request to the given URL
    /// </summary>
    /// <param name="url">URL to request</param>
    /// <returns>Response message as HttpResponseMessage object</returns>
    /// <exception cref="ArgumentNullException">If given <paramref name="url"/> is null</exception>
    /// <exception cref="ArgumentException">if request was unsuccessful</exception>
    public Task<HttpResponseMessage> GetRequest(string? url)
    {
        if (string.IsNullOrEmpty(url?.Trim()))
            throw new ArgumentNullException(nameof(url));

        return GetRequestAsync(url);

        async Task<HttpResponseMessage> GetRequestAsync(string urlAddress)
        {
            var response = await _http.GetAsync(urlAddress);
            if (response is null)
                throw new ArgumentException($"Bad request to url:{urlAddress}");

            return response;
        }
    }
}

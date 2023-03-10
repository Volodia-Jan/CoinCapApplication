using CoinAppClient.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CoinAppClient;
public class CoinCapService
{
    private readonly CoinCapApiService _apiService;
    private const string _baseAddress = "https://api.coincap.io/v2/";

    public CoinCapService()
    {
        _apiService = new CoinCapApiService();
    }

    public async Task<List<ApiMarkets>> GetApiMarkets()
    {
        var response = await _apiService.GetRequest(_baseAddress + "markets");
        var apiMarkets = await GetApiData<List<ApiMarkets>>(response);

        return apiMarkets is null ? new List<ApiMarkets>() : apiMarkets;
    }

    public async Task<List<ApiExchange>> GetApiExchanges()
    {
        var response = await _apiService.GetRequest(_baseAddress + "exchanges");
        var apiExchanges = await GetApiData<List<ApiExchange>>(response);

        return apiExchanges is null ? new List<ApiExchange>() : apiExchanges;
    }

    public async Task<List<ApiAsset>> GetApiAssets()
    {
        var response = await _apiService.GetRequest(_baseAddress + "assets");
        var apiExchanges = await GetApiData<List<ApiAsset>>(response);

        return apiExchanges is null ? new List<ApiAsset>() : apiExchanges;
    }

    public Task<ApiAsset> GetAssetById(string? id)
    {
        if (string.IsNullOrEmpty(id?.Trim()))
            throw new ArgumentNullException(nameof(id));

        return GetAssetByIdAsync(id);

        async Task<ApiAsset> GetAssetByIdAsync(string assetId)
        {
            var response = await _apiService.GetRequest(_baseAddress + $"assets/{assetId}");
            var apiAsset = await GetApiData<ApiAsset>(response);

            return apiAsset is null ? new ApiAsset() : apiAsset;
        }
    }


    /// <summary>
    /// Converts data from HTTP response into given type parameter <typeparamref name="M"/>
    /// </summary>
    /// <typeparam name="M">Type to convert data</typeparam>
    /// <param name="responseMessage">HTTP response</param>
    /// <returns>Converted data if the parsing was successful, otherwise null</returns>
    private async Task<M?> GetApiData<M>(HttpResponseMessage responseMessage) where M: class
    {
        string stringResponse = await responseMessage.Content.ReadAsStringAsync();
        try
        {
            var JsonArray = JsonNode.Parse(stringResponse)?["data"];
            var model = JsonArray.Deserialize<M>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return model;
        }
        catch
        {
            return null;
        }
    }
}

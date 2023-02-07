using CoinAppClient;
using CoinAppClient.Models;
using System.Threading.Tasks;

namespace CoinCapApplication.ViewModels;
internal class CurrencyViewModel : BaseViewModel
{
    private readonly CoinCapService _coinCap;
    private ApiAsset _asset;

    public ApiAsset Asset
    {
        get => _asset;
        private set
        {
            _asset = value;
            OnPropertyChanged(nameof(Asset));
        }
    }

    public CurrencyViewModel(string currencyId)
    {
        _coinCap = new CoinCapService();
        _asset = new ApiAsset();
        Task.Run(() => LoadData(currencyId));
    }

    private async Task LoadData(string currencyId)
    {
        Asset = await _coinCap.GetAssetById(currencyId);
    }
}

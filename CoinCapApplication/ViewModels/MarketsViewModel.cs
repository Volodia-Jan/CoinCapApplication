using CoinAppClient;
using CoinAppClient.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CoinCapApplication.ViewModels;
internal class MarketsViewModel : BaseViewModel
{
    private readonly CoinCapService _coinCap;
    private ObservableCollection<ApiExchange> _exchanges;

    public ObservableCollection<ApiExchange> Exchanges
    {
        get => _exchanges;
        private set { 
            _exchanges = value;
            OnPropertyChanged(nameof(Exchanges));
        }
    }

    private ObservableCollection<ApiMarkets> _selectedMarket;
    public ObservableCollection<ApiMarkets> SelectedMarket
    {
        get => _selectedMarket;
        set
        {
            _selectedMarket = value;
            OnPropertyChanged(nameof(SelectedMarket));
        }
    }

    private ObservableCollection<ApiMarkets> _markets;
    public ObservableCollection<ApiMarkets> Markets
    {
        get => _markets;
        private set
        {
            _markets = value;
            OnPropertyChanged(nameof(Markets));
        }
    }

    public MarketsViewModel()
    {
        _coinCap = new CoinCapService();
        _exchanges = new ObservableCollection<ApiExchange>();
        _selectedMarket = new ObservableCollection<ApiMarkets>();
        _markets = new ObservableCollection<ApiMarkets>();
        LoadData().Wait();
    }

    private async Task LoadData()
    {
        var apiExchanges = await _coinCap.GetApiExchanges();
        var apiMarkets = await _coinCap.GetApiMarkets();
        Exchanges = new ObservableCollection<ApiExchange>(apiExchanges);
        Markets = new ObservableCollection<ApiMarkets>(apiMarkets);
    }
}

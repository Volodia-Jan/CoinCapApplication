using CoinAppClient;
using CoinAppClient.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CoinCapApplication.ViewModels;
internal class AssetsViewModel : BaseViewModel
{
    private readonly CoinCapService _coinCap;
    private ObservableCollection<ApiAsset> _assets;
    
    public ObservableCollection<ApiAsset> Assets
    {
        get => _assets;
        private set
        {
            _assets = value;
            OnPropertyChanged(nameof(Assets));
        }
    }

    public ObservableCollection<ApiAsset> _selectedAssets;

    public ObservableCollection<ApiAsset> SelectedAssets
    {
        get => _selectedAssets;
        set
        {
            _selectedAssets = value;
            OnPropertyChanged(nameof(SelectedAssets));
        }
    }

    public AssetsViewModel()
    {
        _coinCap = new CoinCapService();
        _assets = new ObservableCollection<ApiAsset>();
        _selectedAssets = new ObservableCollection<ApiAsset>();
        Task.Run(() => LoadData());
    }

    private async Task LoadData()
    {
        var assetsList = await _coinCap.GetApiAssets();
        Assets = new ObservableCollection<ApiAsset>(assetsList);
        SelectedAssets = Assets;
    }
}

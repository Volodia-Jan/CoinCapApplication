using CoinAppClient;
using CoinAppClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapApplication.ViewModels;
internal class AssetsViewModel : BaseViewModel
{
    private readonly CoinCapService _coinCap;
    private ObservableCollection<ApiAsset> _assets;
    
    public ObservableCollection<ApiAsset> Assets
    {
        get => _assets;
        set
        {
            _assets = value;
            OnPropertyChanged(nameof(Assets));
        }
    }

    public AssetsViewModel()
    {
        _coinCap = new CoinCapService();
        LoadData();
    }

    private async Task LoadData()
    {
        var assetsList = await _coinCap.GetApiAssets();
        Assets = new ObservableCollection<ApiAsset>(assetsList);
    }
}

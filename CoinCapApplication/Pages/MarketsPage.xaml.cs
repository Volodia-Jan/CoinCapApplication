using CoinAppClient.Models;
using CoinCapApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoinCapApplication.Pages;
/// <summary>
/// Interaction logic for MarketsPage.xaml
/// </summary>
public partial class MarketsPage : Page
{
    public MarketsPage()
    {
        InitializeComponent();
        DataContext = new MarketsViewModel();
    }

    private void MarketInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MarketInfo.SelectedItem.GetType() != typeof(ApiExchange)) return;
        var exchange = (ApiExchange)MarketInfo.SelectedItem;
        var viewModel = (MarketsViewModel)DataContext;

        var orderedMarkets = viewModel.Markets
            .Where(market => market.ExchangeId == exchange.ExchangeId)
            .OrderByDescending(market => market.VolumeUsd24Hr);

        viewModel.SelectedMarket = new ObservableCollection<ApiMarkets>(orderedMarkets);
    }

    private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        NavigationService.Navigate(new Uri($"/CurrencyPage.xaml?currencyName={BaseSymbol}", UriKind.Relative));
    }
}

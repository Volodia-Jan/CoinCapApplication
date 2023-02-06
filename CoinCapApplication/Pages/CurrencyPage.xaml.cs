using CoinCapApplication.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CoinCapApplication.Pages;
/// <summary>
/// Interaction logic for CurrencyPage.xaml
/// </summary>
public partial class CurrencyPage : Page
{
    public CurrencyPage(string assetId)
    {
        InitializeComponent();
        DataContext = new CurrencyViewModel(assetId);
    }

    private void GoBack_ButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}

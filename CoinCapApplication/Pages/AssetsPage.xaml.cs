using CoinAppClient.Models;
using CoinCapApplication.ViewModels;
using System;
using System.Collections.Generic;
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
/// Interaction logic for AssetsPage.xaml
/// </summary>
public partial class AssetsPage : Page
{
    public AssetsPage()
    {
        InitializeComponent();
        DataContext = new AssetsViewModel();
    }

    private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (AssetsGrid.SelectedItem.GetType() == typeof(ApiAsset))
        {
            var assets = (ApiAsset)AssetsGrid.SelectedItem;
            var currencyPage = new CurrencyPage(assets.Id);
            NavigationService.Navigate(currencyPage);
        }
        else
        {
            MessageBox.Show("Something went wrong. Try to pick another currency");
        }
    }
}

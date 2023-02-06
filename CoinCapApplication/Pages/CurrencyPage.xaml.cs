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

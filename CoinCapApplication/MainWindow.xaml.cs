using CoinCapApplication.Pages;
using System.Windows;

namespace CoinCapApplication;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        PageFrame.Content = new MarketsPage();
    }

    private void MarketsPageNavigation(object sender, RoutedEventArgs e)
    {
        PageFrame.Content = new MarketsPage();
    }

    private void AssetsPageNavigation(object sender, RoutedEventArgs e)
    {
        PageFrame.Content = new AssetsPage();
    }
}

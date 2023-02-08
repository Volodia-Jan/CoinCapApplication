using CoinCapApplication.Pages;
using System.Windows;
using System.Windows.Input;

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

    private void MarketsPageNavigation(object sender, MouseButtonEventArgs e)
    {
        PageFrame.Content = new MarketsPage();
    }

    private void AssetsPageNavigation(object sender, MouseButtonEventArgs e)
    {
        PageFrame.Content = new AssetsPage();
    }

    private void CloseBtnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}

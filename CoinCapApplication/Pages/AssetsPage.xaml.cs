using CoinAppClient.Models;
using CoinCapApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

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
            var asset = (ApiAsset)AssetsGrid.SelectedItem;
            if (asset.Id is null)
            {
                MessageBox.Show("Currency Id is null.");
                return;
            }
            var currencyPage = new CurrencyPage(asset.Id);
            NavigationService.Navigate(currencyPage);
        }
        else MessageBox.Show("Something went wrong. Try to pick another currency");
    }

    private void SearchBtn_Click(object sender, RoutedEventArgs e)
    {
        var searchString = SearchStringTextBox.Text.Trim();
        var viewModel = DataContext as AssetsViewModel;
        if (viewModel is null)
        {
            MessageBox.Show("Something went wrong");
            return;
        }
        if (string.IsNullOrEmpty(searchString))
        {
            viewModel.SelectedAssets = viewModel.Assets;
        }
        else
        {
            searchString = searchString.ToLower();
            var searchBy = AssetsSearchBy.SelectedValue as TextBlock;
            if (searchBy is null) return;
            switch (searchBy.Text.ToLower())
            {
                case "id":
                    viewModel.SelectedAssets = GetMatchingAssets(viewModel.Assets.ToList(), 
                        asset => asset.Id != null && asset.Id.ToLower().Contains(searchString));
                    break;
                case "name":
                    viewModel.SelectedAssets = GetMatchingAssets(viewModel.Assets.ToList(),
                        asset => asset.Name != null && asset.Name.ToLower().Contains(searchString));
                    break;
            }
        }
    }

    private void ClearBtn_Click(object sender, RoutedEventArgs e)
    {
        SearchStringTextBox.Text = string.Empty;
        var viewModel = DataContext as AssetsViewModel;
        if (viewModel is null)
        {
            MessageBox.Show("Something went wrong");
            return;
        }
        viewModel.SelectedAssets = viewModel.Assets;
    }

    /// <summary>
    /// Filters given list by given predicate
    /// </summary>
    /// <param name="assetsList">List for filtering</param>
    /// <param name="predicate">Predicate that used for filtering</param>
    /// <returns>Filtered list</returns>
    private ObservableCollection<ApiAsset> GetMatchingAssets(List<ApiAsset> assetsList, Func<ApiAsset, bool> predicate) {
        var mathingAssets = assetsList.Where(predicate).ToList();

        return new ObservableCollection<ApiAsset>(mathingAssets);
    }

}

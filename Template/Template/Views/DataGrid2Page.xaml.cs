using Helper;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using SalesManagerCore;
using Template.Core.Models;
using Template.ViewModels;
using Windows.Storage.Pickers;
using Windows.System.Diagnostics;
using Windows.UI.Core;

namespace Template.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class DataGrid2Page : Page
{
    public DataGrid2ViewModel ViewModel
    {
        get; set;
    }

    public DataGrid2Page()
    {
        ViewModel = App.GetService<DataGrid2ViewModel>();
        InitializeComponent();
    }
    public void ReloadData()
    {
        ViewModel.Source.Clear();
        foreach (var item in Data.statistics.SalesManager.Products.Values)
        {
            ViewModel.Source.Add(item);
        }
    }
    private void ADD_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var listview = ViewModel.Source.ToList();
        SortItem.SortProductsByID(listview, true);
        ViewModel.Source.Clear();
        foreach (var item in listview)
        {
            ViewModel.Source.Add(item);
        }

        var count = 0;
        var donecheck = true;
        foreach (var item in ViewModel.Source)
        {
            count = item.Id + 1;
            if (!ViewModel.Source.Any(i => i.Id == count))
            {
                donecheck = true;
                break;
            }
            else
            {
                donecheck = false;
            }
        }

        if (donecheck)
        {
            ViewModel.Source.Add(new Core.Models.Product() { Id = count });
        }
        else
        {
            ViewModel.Source.Add(new Core.Models.Product() { Id = 0 });
        }
    }

    private void EditDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {

        var current = LastSelected;

        if (!string.IsNullOrWhiteSpace(EditNameTextBox.Text))
        {
            Data.statistics.SalesManager.Products[current].Name = EditNameTextBox.Text;
        }
        if (!string.IsNullOrWhiteSpace(EditCategoryTextBox.Text))
        {
            Data.statistics.SalesManager.Products[current].Category = EditCategoryTextBox.Text;
        }
        if (!string.IsNullOrWhiteSpace(EditPriceTextBox.Text))
        {
            Data.statistics.SalesManager.Products[current].Price = float.Parse(EditPriceTextBox.Text);
        }
        if (!string.IsNullOrWhiteSpace(EditStockTextBox.Text))
        {
            Data.statistics.SalesManager.Products[current].Stock = int.Parse(EditStockTextBox.Text);
        }

        ReloadData();
    }

    private void EditDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {

    }
    private int LastSelected = 0;
    private async void Edit_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (tablegridlist.SelectedIndex == -1) return;

        LastSelected = ViewModel.Source[tablegridlist.SelectedIndex].Id;

        Save();

        await EditDialog.ShowAsync();
    }

    private void SaveClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Save();
    }

    private void Save()
    {
        Data.Save(ViewModel.Source.ToList());
        ReloadData();
    }

    private void DeleteClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (tablegridlist.SelectedIndex == -1) return;
        ViewModel.Source.RemoveAt(tablegridlist.SelectedIndex);
    }
    private void MenuFlyoutItem_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var listview = ViewModel.Source.ToList();
        SortItem.SortProductsByID(listview, true);
        ViewModel.Source.Clear();
        foreach (var item in listview)
        {
            ViewModel.Source.Add(item);
        }
    }

    private void MenuFlyoutItem_Click_1(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var listview = ViewModel.Source.ToList();
        SortItem.SortProductsByID(listview, false);
        ViewModel.Source.Clear();
        foreach (var item in listview)
        {
            ViewModel.Source.Add(item);
        }
    }

    private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            var text = sender.Text;
            var textsuggest = new List<string>();

            textsuggest.Add("------Searched by ID------");
            var id = Search.SearchProductsID(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
            if (id.Count > 0)
            {
                textsuggest.AddRange(id);
            }
            else
            {
                textsuggest.Add("No results found");
            }

            textsuggest.Add("------Searched by Name------");
            var name = Search.SearchProductsByName(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
            if (name.Count > 0)
            {
                textsuggest.AddRange(name);
            }
            else
            {
                textsuggest.Add("No results found");
            }
            textsuggest.Add("------Searched by Category------");
            var cate = Search.SearchProductsByCategory(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
            if (cate.Count > 0)
            {
                textsuggest.AddRange(cate);
            }
            else
            {
                textsuggest.Add("No results found");
            }


            sender.ItemsSource = textsuggest;
        }
    }

    private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {

    }

    private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {

    }

    private async void OpenClick(object sender, RoutedEventArgs e)
    {
        var window = new Microsoft.UI.Xaml.Window();
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
        var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
        filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
        filePicker.FileTypeFilter.Add(".json");
        WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);
        var file = await filePicker.PickSingleFileAsync();

        if (file != null)
        {
            Data.productsPath = file.Path;
            foreach (var item in Data.ReadProductsFromJson(Data.productsPath))
            {
                Data.statistics.SalesManager.AddProduct((Product)item);
            }
        }

        ReloadData();
    }
}

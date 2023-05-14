using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SalesManagerCore;
using Template.Core.Models;
using Template.ViewModels;
using Windows.Storage;
using WinRT.Interop;
using Helper;
using Windows.Storage.Pickers;
using Windows.UI.Core;

namespace Template.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class DataGridPage : Page
{
    public DataGridViewModel ViewModel
    {
        get; set;
    }

    public DataGridPage()
    {
        ViewModel = App.GetService<DataGridViewModel>();
        InitializeComponent();
    }
    public void ReloadData()
    {
        ViewModel.Source.Clear();
        foreach (var item in Data.statistics.SalesManager.Customers.Values)
        {
            ViewModel.Source.Add(item);
        }
    }
    private void MenuFlyoutItem_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var listview = ViewModel.Source.ToList();
        SortItem.SortCustomersByID(listview, true);
        ViewModel.Source.Clear();
        foreach (var item in listview)
        {
            ViewModel.Source.Add(item);
        }
    }

    private void MenuFlyoutItem_Click_1(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var listview = ViewModel.Source.ToList();
        SortItem.SortCustomersByID(listview, false);
        ViewModel.Source.Clear();
        foreach (var item in listview)
        {
            ViewModel.Source.Add(item);
        }
    }

    private void ADD_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var listview = ViewModel.Source.ToList();
        SortItem.SortCustomersByID(listview, true);
        ViewModel.Source.Clear();
        foreach (var item in listview)
        {
            ViewModel.Source.Add(item);
        }
        var count = 0;
        var donecheck = true;
        foreach (var item in ViewModel.Source)
        {
            count = item.CustomerId + 1;
            if (!ViewModel.Source.Any(i => i.CustomerId == count))
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
            ViewModel.Source.Add(new Core.Models.Customer() { CustomerId = count });
        }
        else
        {
            ViewModel.Source.Add(new Core.Models.Customer() { CustomerId = 0 });
        }
    }

    private void EditDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        var current = LastSelected;

        if (!string.IsNullOrWhiteSpace(EditNameTextBox.Text))
        {
            Data.statistics.SalesManager.Customers[current].Name = EditNameTextBox.Text;
        }
        if (!string.IsNullOrWhiteSpace(EditEmailTextBox.Text))
        {
            Data.statistics.SalesManager.Customers[current].Email = EditEmailTextBox.Text;
        }
        if (!string.IsNullOrWhiteSpace(EditPhoneTextBox.Text))
        {
            Data.statistics.SalesManager.Customers[current].PhoneNumber = EditPhoneTextBox.Text;
        }
        if (!string.IsNullOrWhiteSpace(EditOrderTextBox.Text))
        {
            if (EditOrderTextBox.Text.Contains(","))
            {
                var orderlist = EditOrderTextBox.Text.Split(',');
                foreach (var item in orderlist)
                {
                    int orderid = 0;
                    if (int.TryParse(item, out orderid))
                    {
                        if (Data.statistics.SalesManager.Orders.ContainsKey(orderid))
                        {
                            Data.statistics.SalesManager.Orders[orderid].Customer = Data.statistics.SalesManager.Customers[current];
                        }
                    }
                }
            }
            else
            {
                int orderid = 0;
                if (int.TryParse(EditOrderTextBox.Text, out orderid))
                {
                    if (Data.statistics.SalesManager.Orders.ContainsKey(orderid))
                    {
                        Data.statistics.SalesManager.Orders[orderid].Customer = Data.statistics.SalesManager.Customers[current];
                    }
                }
            }
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

        LastSelected = ViewModel.Source[tablegridlist.SelectedIndex].CustomerId;

        Save();

        await EditDialog.ShowAsync();
    }

    private void DeleteClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (tablegridlist.SelectedIndex == -1) return;
        ViewModel.Source.RemoveAt(tablegridlist.SelectedIndex);
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

    private void MenuFlyoutItem_ClickxD(object sender, RoutedEventArgs e)
    {
        
    }

    private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            var text = sender.Text;
            var textsuggest = new List<string>();

            textsuggest.Add("------Searched by ID------");
            var id = Search.SearchCustomersByID(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
            if (id.Count > 0)
            {
                textsuggest.AddRange(id);
            }
            else
            {
                textsuggest.Add("No results found");
            }

            textsuggest.Add("------Searched by Name------");
            var name = Search.SearchCustomersByName(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
            if (name.Count > 0)
            {
                textsuggest.AddRange(name);
            }
            else
            {
                textsuggest.Add("No results found");
            }
            textsuggest.Add("------Searched by Email------");
            var cate = Search.SearchCustomersByEmail(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
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
            Data.customersPath = file.Path;
            foreach (var item in Data.ReadCustomersFromJson(Data.customersPath))
            {
                Data.statistics.SalesManager.AddCustomer((Customer)item);
            }
        }

        ReloadData();
    }
}

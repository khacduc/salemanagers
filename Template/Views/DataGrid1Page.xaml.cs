using Helper;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SalesManagerCore;
using Template.Core.Models;
using Template.ViewModels;
using Windows.Storage.Pickers;
using Windows.UI.Core;

namespace Template.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class DataGrid1Page : Page
{
    public DataGrid1ViewModel ViewModel
    {
        get; set;
    }

    public DataGrid1Page()
    {
        ViewModel = App.GetService<DataGrid1ViewModel>();
        InitializeComponent();
    }
    public void ReloadData()
    {
        ViewModel.Source.Clear();
        foreach (var item in Data.statistics.SalesManager.Orders.Values)
        {
            ViewModel.Source.Add(item);
        }
    }

    private void ADD_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var listview = ViewModel.Source.ToList();
        SortItem.SortOrdersByID(listview, true);
        ViewModel.Source.Clear();
        foreach (var item in listview)
        {
            ViewModel.Source.Add(item);
        }

        var count = 0;
        var donecheck = true;
        foreach (var item in ViewModel.Source)
        {
            count = item.OrderId + 1;
            if (!ViewModel.Source.Any(i => i.OrderId == count))
            {
                donecheck = true;
                break;
            }
            else
            {
                donecheck = false;
            }
        }

        if(donecheck)
        {
            ViewModel.Source.Add(new Core.Models.Order() { OrderId = count });
        }
        else
        {
            ViewModel.Source.Add(new Core.Models.Order() { OrderId = 0 });
        }
    }
    private void EditDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        var current = LastSelected;

        if (!string.IsNullOrWhiteSpace(EditNameTextBox.Text))
        {
            Data.statistics.SalesManager.Orders[current].Name = EditNameTextBox.Text;
        }
        if (!string.IsNullOrWhiteSpace(EditCustomerTextBox.Text))
        {
            int customerid = int.Parse(EditCustomerTextBox.Text);
            if (!string.IsNullOrWhiteSpace(EditCustomerTextBox.Text) && Data.statistics.SalesManager.Customers.ContainsKey(customerid))
            {
                Data.statistics.SalesManager.Orders[current].Customer = Data.statistics.SalesManager.Customers[customerid];
            }
        }
           
        if (EditDateTextBox.SelectedDate.HasValue)
        {
            Data.statistics.SalesManager.Orders[current].OrderDate = EditDateTextBox.Date.DateTime;
        }

        if (EditItemTextBox.Text.Contains(",") && EditCountTextBox.Text.Contains(","))
        {
            var orderlist = EditItemTextBox.Text.Split(',');
            var countlist = EditCountTextBox.Text.Split(',');

            if (countlist.Length == orderlist.Length)
            {
                for (int i = 0; i < orderlist.Length; i++)
                {
                    int id = 0;
                    int count = 0;
                    if (int.TryParse(orderlist[i], out id))
                    {
                        if (int.TryParse(countlist[i], out count))
                        {
                            if (Data.statistics.SalesManager.Products.ContainsKey(id))
                            {
                                Data.statistics.SalesManager.Orders[current].OrderItems.Add(new Core.Models.OrderItem() { Product = Data.statistics.SalesManager.Products[id], Quantity = count });
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if(!EditItemTextBox.Text.Contains(",") && !EditCountTextBox.Text.Contains(","))
            {
                int id = 0;
                int count = 0;
                if (int.TryParse(EditItemTextBox.Text, out id))
                {
                    if (int.TryParse(EditCountTextBox.Text, out count))
                    {
                        if (Data.statistics.SalesManager.Products.ContainsKey(id))
                        {
                            Data.statistics.SalesManager.Orders[current].OrderItems.Add(new Core.Models.OrderItem() { Product = Data.statistics.SalesManager.Products[id], Quantity = count });
                        }
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

        LastSelected = ViewModel.Source[tablegridlist.SelectedIndex].OrderId;

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
        if(tablegridlist.SelectedIndex == -1) return;

        ViewModel.Source.RemoveAt(tablegridlist.SelectedIndex);
    }
    private void MenuFlyoutItem_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var listview = ViewModel.Source.ToList();
        SortItem.SortOrdersByID(listview, true);
        ViewModel.Source.Clear();
        foreach (var item in listview)
        {
            ViewModel.Source.Add(item);
        }
    }

    private void MenuFlyoutItem_Click_1(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var listview = ViewModel.Source.ToList();
        SortItem.SortOrdersByID(listview, false);
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
            var id = Search.SearchOrdersByID(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
            if (id.Count > 0)
            {
                textsuggest.AddRange(id);
            }
            else
            {
                textsuggest.Add("No results found");
            }

            textsuggest.Add("------Searched by Customer ID------");
            var id2 = Search.SearchOrdersByCustomerID(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
            if (id2.Count > 0)
            {
                textsuggest.AddRange(id2);
            }
            else
            {
                textsuggest.Add("No results found");
            }


            textsuggest.Add("------Searched by Name------");
            var name = Search.SearchOrdersByName(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
            if (name.Count > 0)
            {
                textsuggest.AddRange(name);
            }
            else
            {
                textsuggest.Add("No results found");
            }

            textsuggest.Add("------Searched by Customer Name------");
            var name2 = Search.SearchOrdersByCustomerName(ViewModel.Source.ToList(), text).Select(s => s.tostring).ToList();
            if (name2.Count > 0)
            {
                textsuggest.AddRange(name2);
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
            Data.ordersPath = file.Path;
            foreach (var item in Data.ReadOrdersFromJson(Data.ordersPath))
            {
                Data.statistics.SalesManager.CreateOrder((Order)item);
            }
        }

        ReloadData();
    }
}

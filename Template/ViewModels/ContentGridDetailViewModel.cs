using CommunityToolkit.Mvvm.ComponentModel;

using Template.Contracts.ViewModels;
using Template.Core.Contracts.Services;
using Template.Core.Models;

namespace Template.ViewModels;

public class ContentGridDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly IOrder _sampleDataService;
    private Order? _item;

    public Order? Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }

    public ContentGridDetailViewModel(IOrder sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is int orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderId == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}

using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Template.Contracts.Services;
using Template.Contracts.ViewModels;
using Template.Core.Contracts.Services;
using Template.Core.Models;

namespace Template.ViewModels;

public class ContentGridViewModel : ObservableRecipient, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly IOrder _sampleDataService;

    public ICommand ItemClickCommand
    {
        get;
    }

    public ObservableCollection<Order> Source { get; } = new ObservableCollection<Order>();

    public ContentGridViewModel(INavigationService navigationService, IOrder sampleDataService)
    {
        _navigationService = navigationService;
        _sampleDataService = sampleDataService;

        ItemClickCommand = new RelayCommand<Order>(OnItemClick);
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetContentGridDataAsync();
        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    private void OnItemClick(Order? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(ContentGridDetailViewModel).FullName!, clickedItem.OrderId);
        }
    }
}

using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Template.Contracts.ViewModels;
using Template.Core.Contracts.Services;
using Template.Core.Models;

namespace Template.ViewModels;

public class DataGrid2ViewModel : ObservableRecipient, INavigationAware
{
    private readonly IProduct _sampleDataService;

    public ObservableCollection<Product> Source { get; } = new ObservableCollection<Product>();

    public DataGrid2ViewModel(IProduct sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetGridDataAsync();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}

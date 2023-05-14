using Microsoft.UI.Xaml.Controls;
using SalesManagerCore;
using Template.ViewModels;

namespace Template.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
        this.DataContext = Data.statistics;
    }
}

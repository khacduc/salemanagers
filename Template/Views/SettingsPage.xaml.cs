using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;

using Template.ViewModels;
using Windows.Foundation;
using Helper;

namespace Template.Views;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
    }

    private void themeMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (themeMode.SelectedIndex)
        {
            case 0:
                ViewModel._themeSelectorService.SetThemeAsync(ElementTheme.Light);
                break;
            case 1:
                ViewModel._themeSelectorService.SetThemeAsync(ElementTheme.Dark);
                break;
            default:
                ViewModel._themeSelectorService.SetThemeAsync(ElementTheme.Default);
                break;
        }

        
    }
}

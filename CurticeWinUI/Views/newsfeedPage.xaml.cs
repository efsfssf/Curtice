using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class newsfeedPage : Page
{
    public newsfeedViewModel ViewModel
    {
        get;
    }

    public newsfeedPage()
    {
        ViewModel = App.GetService<newsfeedViewModel>();
        InitializeComponent();
    }
}

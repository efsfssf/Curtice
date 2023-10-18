using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class FriendsPage : Page
{
    public FriendsViewModel ViewModel
    {
        get;
    }

    public FriendsPage()
    {
        ViewModel = App.GetService<FriendsViewModel>();
        InitializeComponent();
    }
}

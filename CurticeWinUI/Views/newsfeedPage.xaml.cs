using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class NewsfeedPage : Page
{
    public NewsfeedViewModel ViewModel
    {
        get;
    }

    public NewsfeedPage()
    {
        ViewModel = App.GetService<NewsfeedViewModel>();
        InitializeComponent();
    }
}

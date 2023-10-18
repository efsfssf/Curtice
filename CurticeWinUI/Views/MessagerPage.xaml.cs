using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class MessagerPage : Page
{
    public MessagerViewModel ViewModel
    {
        get;
    }

    public MessagerPage()
    {
        ViewModel = App.GetService<MessagerViewModel>();
        InitializeComponent();
    }
}

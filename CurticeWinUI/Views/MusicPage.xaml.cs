using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class MusicPage : Page
{
    public MusicViewModel ViewModel
    {
        get;
    }

    public MusicPage()
    {
        ViewModel = App.GetService<MusicViewModel>();
        InitializeComponent();
    }
}

using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class VideosPage : Page
{
    public VideosViewModel ViewModel
    {
        get;
    }

    public VideosPage()
    {
        ViewModel = App.GetService<VideosViewModel>();
        InitializeComponent();
    }
}

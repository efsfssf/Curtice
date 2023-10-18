using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class PhotosPage : Page
{
    public PhotosViewModel ViewModel
    {
        get;
    }

    public PhotosPage()
    {
        ViewModel = App.GetService<PhotosViewModel>();
        InitializeComponent();
    }
}

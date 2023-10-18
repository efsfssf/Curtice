using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class BookmarksPage : Page
{
    public BookmarksViewModel ViewModel
    {
        get;
    }

    public BookmarksPage()
    {
        ViewModel = App.GetService<BookmarksViewModel>();
        InitializeComponent();
    }
}

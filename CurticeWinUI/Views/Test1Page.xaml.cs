using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class Test1Page : Page
{
    public Test1ViewModel ViewModel
    {
        get;
    }

    public Test1Page()
    {
        ViewModel = App.GetService<Test1ViewModel>();
        InitializeComponent();
    }
}

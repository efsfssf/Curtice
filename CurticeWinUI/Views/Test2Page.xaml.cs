using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class Test2Page : Page
{
    public Test2ViewModel ViewModel
    {
        get;
    }

    public Test2Page()
    {
        ViewModel = App.GetService<Test2ViewModel>();
        InitializeComponent();
    }
}

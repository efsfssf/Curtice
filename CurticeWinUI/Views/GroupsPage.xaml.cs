using CurticeWinUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Views;

public sealed partial class GroupsPage : Page
{
    public GroupsViewModel ViewModel
    {
        get;
    }

    public GroupsPage()
    {
        ViewModel = App.GetService<GroupsViewModel>();
        InitializeComponent();
    }
}

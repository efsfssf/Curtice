using CurticeWinUI.Models;
using CurticeWinUI.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Windows.ApplicationModel.DataTransfer;

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
        this.DataContext = ViewModel;
    }

    private void ListView_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        ListView listView = (ListView)sender;
        var originalSource = (FrameworkElement)e.OriginalSource;
        var rightClickedItem = (Dialog)originalSource.DataContext;

        // Вызов команды копирования
        //ViewModel.CopyChatIDCommand.Execute(rightClickedItem.ChatID);

        ViewModel.RightClickedDialog = rightClickedItem;

        // Показ контекстного меню
        allContactsMenuFlyout.ShowAt(listView, e.GetPosition(listView));
    }







}

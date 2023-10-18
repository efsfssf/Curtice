using CommunityToolkit.Mvvm.ComponentModel;

using CurticeWinUI.Contracts.Services;
using CurticeWinUI.ViewModels;
using CurticeWinUI.Views;

using Microsoft.UI.Xaml.Controls;

namespace CurticeWinUI.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<newsfeedViewModel, newsfeedPage>();
        Configure<MessagerViewModel, MessagerPage>();
        Configure<GroupsViewModel, GroupsPage>();
        Configure<MusicViewModel, MusicPage>();
        Configure<FriendsViewModel, FriendsPage>();
        Configure<PhotosViewModel, PhotosPage>();
        Configure<VideosViewModel, VideosPage>();
        Configure<BookmarksViewModel, BookmarksPage>();
        Configure<NotificationsViewModel, NotificationsPage>();
        Configure<Test1ViewModel, Test1Page>();
        Configure<Test2ViewModel, Test2Page>();
        Configure<SettingsViewModel, SettingsPage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.ContainsValue(type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}

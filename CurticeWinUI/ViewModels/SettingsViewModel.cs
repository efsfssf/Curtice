using System.Reflection;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using CurticeWinUI.Contracts.Services;
using CurticeWinUI.Helpers;
using CurticeWinUI.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel;

namespace CurticeWinUI.ViewModels;

public partial class SettingsViewModel : ObservableRecipient
{
    
    private readonly IThemeSelectorService _themeSelectorService;
    private readonly ILanguageService _languageService;

    [ObservableProperty]
    private string _selectedLanguage;

    private string _selectedLanguageCombo;

    public string SelectedLanguageCombo
    {
        get
        {
            return _selectedLanguageCombo;
        }
        set
        {
            _selectedLanguageCombo = value;
            // Выполняйте команду при изменении выбранного элемента
            SwitchLanguageCommand.Execute(SelectedLanguageCombo);
        }
    }

    [ObservableProperty]
    private IEnumerable<string> _availableLanguages;


    [ObservableProperty]
    private ElementTheme _elementTheme;

    [ObservableProperty]
    private string _versionDescription;

    public ICommand SwitchThemeCommand
    {
        get;
    }
    private readonly ILocalSettingsService _localSettingsService;
    public ICommand SwitchLanguageCommand
    {
        get;
    }

    public SettingsViewModel(IThemeSelectorService themeSelectorService, ILocalSettingsService localSettingsService, ILanguageService languageService)
    {
        _themeSelectorService = themeSelectorService;
        _localSettingsService = localSettingsService;
        _languageService = languageService;
        SelectedPage = StartupPage;
        _elementTheme = _themeSelectorService.Theme;
        _versionDescription = GetVersionDescription();

        SetStartupPageCommand = new RelayCommand<string>(async (pageKey) => {
            if (pageKey == null)
            {
                throw new ArgumentNullException(nameof(pageKey));
            }
            await SetStartupPageAsync(pageKey);
        });

        SwitchThemeCommand = new RelayCommand<ElementTheme>(
            async (param) =>
            {
                if (ElementTheme != param)
                {
                    ElementTheme = param;
                    await _themeSelectorService.SetThemeAsync(param);
                }
            });

        SwitchLanguageCommand = new RelayCommand<string>(
            async (param) =>
            {
                if (_selectedLanguage != param)
                {
                    _selectedLanguage = param;
                    await _languageService.SetCurrentLanguageAsync(param);
                }
            });
    }


    private static string GetVersionDescription()
    {
        Version version;

        if (RuntimeHelper.IsMSIX)
        {
            var packageVersion = Package.Current.Id.Version;

            version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        }
        else
        {
            version = Assembly.GetExecutingAssembly().GetName().Version!;
        }

        return $"{"AppDisplayName".GetLocalized()} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }

    public ICommand SetStartupPageCommand
    {
        get;
    }

    private string _startupPage = default!;
    public string StartupPage
    {
        get => _startupPage;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("_startupPage is required.");
            }
            SetProperty(ref _startupPage, value);
        }
    }

    private string _selectedPage = default!;
    public string SelectedPage
    {
        get => _selectedPage;
        set
        {
            
            SetProperty(ref _selectedPage, value);
        }
    }

    private readonly Dictionary<string, string> _pageKeys = new()
    {
        { "SettingsPage", "CurticeWinUI.ViewModels.SettingsViewModel" },
        { "NewsfeedPage", "CurticeWinUI.ViewModels.NewsfeedViewModel" }
        // добавьте здесь другие страницы
    };

    public async Task InitializeAsync()
    {
        var startupViewModelName = await _localSettingsService.GetStartupPageAsync();
        foreach (var kvp in _pageKeys)
        {
            if (kvp.Value == startupViewModelName)
            {
                SelectedPage = kvp.Key;
                break;
            }
        }

        _availableLanguages = await _languageService.GetAvailableLanguagesAsync();

        _selectedLanguage = await _languageService.GetCurrentLanguageAsync();
    }


    private async Task SetStartupPageAsync(string pageKey)
    {

        if (_pageKeys.TryGetValue(pageKey, out var viewModelName))
        {
            StartupPage = viewModelName;
            SelectedPage = pageKey; // Обновите выбранную страницу
            await _localSettingsService.SetStartupPageAsync(viewModelName);
        }
    }

    



}

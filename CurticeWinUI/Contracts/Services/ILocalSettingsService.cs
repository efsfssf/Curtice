namespace CurticeWinUI.Contracts.Services;

public interface ILocalSettingsService
{
    Task<T?> ReadSettingAsync<T>(string key);

    Task SaveSettingAsync<T>(string key, T value);

    Task<string> GetStartupPageAsync();
    Task SetStartupPageAsync(string pageKey);
}

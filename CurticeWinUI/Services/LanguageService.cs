using CurticeWinUI.Contracts.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Globalization;

namespace CurticeWinUI.Services;

public class LanguageService : ILanguageService
{
    public Task<IEnumerable<string>> GetAvailableLanguagesAsync()
    {
        var languages = ApplicationLanguages.ManifestLanguages.ToList();
        languages.Add("System");
        return Task.FromResult(languages.AsEnumerable());
    }

    public Task<string> GetCurrentLanguageAsync()
    {
        return Task.FromResult(ApplicationLanguages.PrimaryLanguageOverride == "" ? "System" : ApplicationLanguages.PrimaryLanguageOverride);
    }

    public Task SetCurrentLanguageAsync(string language)
    {
        if (language == "System")
            language = "";
        ApplicationLanguages.PrimaryLanguageOverride = language;
        return Task.CompletedTask;
    }
}

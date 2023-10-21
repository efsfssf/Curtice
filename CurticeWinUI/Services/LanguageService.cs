using CurticeWinUI.Contracts.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Globalization;

namespace CurticeWinUI.Services
{
    public class LanguageService : ILanguageService
    {
        public Task<IEnumerable<string>> GetAvailableLanguagesAsync()
        {
            return Task.FromResult(ApplicationLanguages.ManifestLanguages.AsEnumerable());
        }

        public Task<string> GetCurrentLanguageAsync()
        {
            return Task.FromResult(ApplicationLanguages.PrimaryLanguageOverride);
        }

        public Task SetCurrentLanguageAsync(string language)
        {
            ApplicationLanguages.PrimaryLanguageOverride = language;
            return Task.CompletedTask;
        }
    }
}

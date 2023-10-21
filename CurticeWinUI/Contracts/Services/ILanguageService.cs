using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurticeWinUI.Contracts.Services;

public interface ILanguageService
{
    Task<IEnumerable<string>> GetAvailableLanguagesAsync();
    Task<string> GetCurrentLanguageAsync();
    Task SetCurrentLanguageAsync(string language);
}


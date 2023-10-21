using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using Windows.ApplicationModel.Resources;

namespace CurticeWinUI.Helpers;
internal class PageKeyToResourceStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var pageKey = (string)value;
        return ResourceLoader.GetForViewIndependentUse().GetString(pageKey);

    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        // Вызывается в случае, если установлен TwoWay вместо OneWay
        throw new NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;

namespace CurticeWinUI.Models;

public class MessageItem
{
    public string MsgText
    {
        get; set;
    }
    public DateTime MsgDateTime
    {
        get; set;
    }
    public required SolidColorBrush BgColor
    {
        get; set;
    }
    public HorizontalAlignment MsgAlignment
    {
        get; set;
    }
}

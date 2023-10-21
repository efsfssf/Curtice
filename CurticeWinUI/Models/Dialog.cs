using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;

namespace CurticeWinUI.Models;

public class Dialog
{
    public string? Avatar
    {
        get; set;
    }
    public string? Name
    {
        get; set;
    }
    public string? LastMessage
    {
        get; set;
    }
    public string? LastMessageTime
    {
        get; set;
    }
    public int UnreadCount
    {
        get; set;
    }
}


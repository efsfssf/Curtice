using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurticeWinUI.Models;

public class Message
{
    public string? Avatar
    {
        get; set;
    }
    public string? SenderName
    {
        get; set;
    }
    public DateTime Timestamp
    {
        get; set;
    }
    public string? Text
    {
        get; set;
    }
}


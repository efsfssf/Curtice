using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;

namespace CurticeWinUI.Models;

public class AttachmentPhotosObject
{
    private string title = "";
    private ImageSource imageLocation = default!;
    private int likes = 0;

    public string Title
    {
        get => title;
        set => title = value;
    }

    public ImageSource ImageLocation
    {
        get => imageLocation;
        set => imageLocation = value;
    }

    public int Likes
    {
        get => likes;
        set => likes = value;
    }
}

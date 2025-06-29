﻿using CommunityToolkit.Mvvm.ComponentModel;
using CurticeWinUI.Models;
using CurticeWinUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics.CodeAnalysis;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.ApplicationModel.DataTransfer;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;
using Microsoft.UI;
using System.Diagnostics;

namespace CurticeWinUI.ViewModels;

public class MessagerViewModel : ObservableRecipient
{
    #region Conversation Screen Header Properties
    private string _contactName = "One moment please🥱";
    public string ContactName
    {
        get => _contactName;
        set
        {
            if (_contactName != value)
            {
                _contactName = value;
                OnPropertyChanged(nameof(ContactName));
            }
        }
    }
    private string _avatar = "";
    public string Avatar
    {
        get => _avatar;
        set
        {
            if (_avatar != value)
            {
                _avatar = value;
                OnPropertyChanged(nameof(Avatar));
            }
        }
    }

    private string _last_seen = "Test Online";
    public string LastSeen
    {
        get => _last_seen;
        set
        {
            if (_last_seen != value)
            {
                _last_seen = value;
                OnPropertyChanged(nameof(LastSeen));
            }
        }
    }
    #endregion

    #region Dialogs Properties
    private ObservableCollection<Dialog> dialogs = default!;
    [NotNull]
    public ObservableCollection<Dialog> Dialogs
    {
        get => dialogs;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("dialogs is required.");
            }
            SetProperty(ref dialogs, value);
        }
    }

    private Dialog selectedDialog = default!;
    [NotNull]
    public Dialog? SelectedDialog
    {
        get => selectedDialog;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("selectedDialog is required.");
            }
            SetProperty(ref selectedDialog, value);
            Debug.WriteLine($"Selected dialog changed: {value.Name}, {value.Avatar}");
            ContactName = value.Name ?? "DELETED";
            Avatar = value.Avatar ?? "";
            OnPropertyChanged(nameof(ContactName));
        }
    }

    private string selectedDialogText = default!;
    [NotNull]
    public string SelectedDialogText
    {
        get => selectedDialogText;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("selectedDialogText is required.");
            }
            SetProperty(ref selectedDialogText, value);
        }
    }

    private ObservableCollection<DialogListElement> selectedDialogMessages = default!;
    [NotNull]
    public ObservableCollection<DialogListElement> SelectedDialogMessages
    {
        get => selectedDialogMessages;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("selectedDialogMessages is required.");
            }
            SetProperty(ref selectedDialogMessages, value);
        }
    }

    public ICommand AttachCommand
    {
        get;
    }
    public ICommand SendCommand
    {
        get;
    }

    public ICommand CopyChatIDCommand
    {
        get;
    }
    private Dialog? rightClickedDialog = default!;
    public Dialog? RightClickedDialog
    {
        get => rightClickedDialog;
        set => SetProperty(ref rightClickedDialog, value);
    }

    #endregion

    #region MessagesBody
    public ObservableCollection<MessageItem> MessagesList
    {
        get; set;
    }

    protected string messageText = "";
    public string MessageText
    {
        get => messageText;
        set
        {
            messageText = value;
            OnPropertyChanged(nameof(MessageText));
        }
    }


    #endregion

    #region Dialog Info
    private ObservableCollection<AttachmentPhotosObject> photoItem;

    public ObservableCollection<AttachmentPhotosObject> PhotoItems
    {
        get => photoItem;
        set
        {
            photoItem = value;
            OnPropertyChanged("PhotoItem");
        }
    }

    #endregion
    public MessagerViewModel()
    {
        MessagesList = new ObservableCollection<MessageItem>
            {
                new MessageItem
                {
                    MsgText = "Привет",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightBlue),
                    MsgAlignment = HorizontalAlignment.Left
                },
                new MessageItem
                {
                    MsgText = "Привет",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightGreen),
                    MsgAlignment = HorizontalAlignment.Right
                },
                new MessageItem
                {
                    MsgText = "Как дела?",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightBlue),
                    MsgAlignment = HorizontalAlignment.Left
                },
                new MessageItem
                {
                    MsgText = "Нормально",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightGreen),
                    MsgAlignment = HorizontalAlignment.Right
                },
                new MessageItem
                {
                    MsgText = "Супер",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightGreen),
                    MsgAlignment = HorizontalAlignment.Right
                },
                new MessageItem
                {
                    MsgText = "Что делаешь?",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightBlue),
                    MsgAlignment = HorizontalAlignment.Left
                },
                new MessageItem
                {
                    MsgText = "Да так...",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightGreen),
                    MsgAlignment = HorizontalAlignment.Right
                },
                new MessageItem
                {
                    MsgText = "Ничего",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightGreen),
                    MsgAlignment = HorizontalAlignment.Right
                },
                new MessageItem
                {
                    MsgText = "А ты?",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightGreen),
                    MsgAlignment = HorizontalAlignment.Right
                },
                new MessageItem
                {
                    MsgText = "жду нового мессенджера",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightBlue),
                    MsgAlignment = HorizontalAlignment.Left
                },
                new MessageItem
                {
                    MsgText = "Какого?",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightGreen),
                    MsgAlignment = HorizontalAlignment.Right
                },
                new MessageItem
                {
                    MsgText = "Конечно же Curtice!",
                    MsgDateTime = DateTime.Now,
                    BgColor = new SolidColorBrush(Colors.LightBlue),
                    MsgAlignment = HorizontalAlignment.Left
                }
            };

        CopyChatIDCommand = new RelayCommand<string>((pageKey) =>
        {
            if (pageKey == null)
            {
                throw new ArgumentNullException(nameof(pageKey));
            }
            OnCopyChatID(pageKey);
        });

        PhotoItems = new ObservableCollection<AttachmentPhotosObject>
        {
            new AttachmentPhotosObject { Title = "Item 1", ImageLocation = new BitmapImage(new Uri("ms-appx:///Assets/avatar1.png")), Likes = 10 },
            new AttachmentPhotosObject { Title = "Item 2", ImageLocation = new BitmapImage(new Uri("ms-appx:///Assets/avatar1.png")), Likes = 20 },
        };

        // Инициализация команд и коллекций
        AttachCommand = new RelayCommand(OnAttach);
        SendCommand = new RelayCommand(OnSend);

        // Загрузка диалогов и сообщений
        LoadDialogs();
    }

    #region Dialogs Methods

    private void OnCopyChatID(string chatId)
    {
        if (!string.IsNullOrEmpty(chatId))
        {
            var dataPackage = new DataPackage();
            dataPackage.SetText(chatId);
            Clipboard.SetContent(dataPackage);
        }
    }




    private void LoadDialogs()
    {
        // Загрузка диалогов из сервиса или другого источника данных
        // Пример заполнения диалогов для теста
        Dialogs = new ObservableCollection<Dialog>
        {
            new Dialog
            {
                Avatar = "https://sun70-1.userapi.com/impf/3OhLINnHeUU5AcPrUWIRnlROMVsENVk-ooAkiQ/fmc4r1Gy1No.jpg?quality=96&as=50x50,100x100,200x200,400x400&sign=89312ba8d72343853abcc9465bd06b6e&u=K0aS-GTXBoWnULSQ827F4s5OaR9sZwX42fh0C9XAAIg&cs=200x200",
                Name = "Паша Корчевников",
                LastMessage = "Привет. Как дела?",
                LastMessageTime = "2 часа назад",
                UnreadCount = 0,
                ChatID = "1"
            },
            new Dialog
            {
                Avatar = "https://sun70-1.userapi.com/impf/3OhLINnHeUU5AcPrUWIRnlROMVsENVk-ooAkiQ/fmc4r1Gy1No.jpg?quality=96&as=50x50,100x100,200x200,400x400&sign=89312ba8d72343853abcc9465bd06b6e&u=K0aS-GTXBoWnULSQ827F4s5OaR9sZwX42fh0C9XAAIg&cs=200x200",
                Name = "Маша Наумова",
                LastMessage = "Когда гулять?",
                LastMessageTime = "Только что",
                UnreadCount = 0,
                ChatID = "2"
            }
        };
    }

    #endregion

    private void OnAttach()
    {
        // Обработка прикрепления файла
    }

    private void OnSend()
    {
        // Обработка отправки сообщения
    }
}

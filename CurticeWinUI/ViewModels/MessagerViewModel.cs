using CommunityToolkit.Mvvm.ComponentModel;
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

namespace CurticeWinUI.ViewModels;

public class MessagerViewModel : ObservableRecipient
{
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

    private ObservableCollection<Message> selectedDialogMessages = default!;
    [NotNull]
    public ObservableCollection<Message> SelectedDialogMessages
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

    public MessagerViewModel()
    {
        // Инициализация команд и коллекций
        AttachCommand = new RelayCommand(OnAttach);
        SendCommand = new RelayCommand(OnSend);

        // Загрузка диалогов и сообщений
        LoadDialogs();
    }

    private void LoadDialogs()
    {
        // Загрузка диалогов из сервиса или другого источника данных
        // Пример заполнения диалогов для теста
        Dialogs = new ObservableCollection<Dialog>
        {
            new Dialog
            {
                Avatar = "avatar1.png",
                Name = "Паша Корчевников",
                LastMessage = "Привет. Как дела?",
                UnreadCount = 0
            },
            new Dialog
            {
                Avatar = "avatar2.png",
                Name = "Маша Наумова",
                LastMessage = "Когда гулять?",
                UnreadCount = 0
            }
        };
    }

    private void OnAttach()
    {
        // Обработка прикрепления файла
    }

    private void OnSend()
    {
        // Обработка отправки сообщения
    }
}

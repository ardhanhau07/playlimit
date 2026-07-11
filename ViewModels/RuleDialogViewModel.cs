using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.IO;
using PlayLimit.Models;
using PlayLimit.Services;

namespace PlayLimit.ViewModels;

public partial class RuleDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private string name = "";

    [ObservableProperty]
    private string exePath = "";

    [ObservableProperty]
    private string processName = "";

    [ObservableProperty]
    private int timeLimit = 120;

    [ObservableProperty]
    private bool enabled = true;

    [RelayCommand]
    private void Browse()
    {
        OpenFileDialog dialog = new();

        dialog.Filter = "Executable (*.exe)|*.exe";

        if (dialog.ShowDialog() == true)
        {
            ExePath = dialog.FileName;

            Name = Path.GetFileNameWithoutExtension(dialog.FileName);

            ProcessName = Path.GetFileNameWithoutExtension(dialog.FileName);
        }
    }
    [RelayCommand]
    private void Save()
    {
        var rule = new AppRule
        {
            Name = Name,
            ExePath = ExePath,
            ProcessName = ProcessName,
            TimeLimit = TimeLimit,
            Enabled = Enabled
        };

        DatabaseService.AddRule(rule);

        RequestClose?.Invoke();
    }

    public event Action? RequestClose;
}
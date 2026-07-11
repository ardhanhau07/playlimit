using System.Windows;
using PlayLimit.ViewModels;

namespace PlayLimit.Views;

public partial class RuleDialog : Window
{
    public RuleDialog()
    {
        InitializeComponent();
        var vm = new RuleDialogViewModel();

        vm.RequestClose += () =>
        {
            DialogResult = true;
            Close();
        };

        DataContext = vm;
    }
}
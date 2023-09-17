using System.Windows.Controls;

using DXG7Cal.Contracts.Views;
using DXG7Cal.ViewModels;

using MahApps.Metro.Controls;

namespace DXG7Cal.Views;

public partial class ShellWindow : MetroWindow, IShellWindow
{
    public ShellWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public Frame GetNavigationFrame()
        => shellFrame;

    public void ShowWindow()
        => Show();

    public void CloseWindow()
        => Close();
}

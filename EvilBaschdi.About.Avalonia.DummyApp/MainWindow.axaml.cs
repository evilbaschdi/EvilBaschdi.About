using Avalonia.Controls;
using Avalonia.Interactivity;
using EvilBaschdi.About.Avalonia.Models;
using EvilBaschdi.About.Core;
using EvilBaschdi.Core.Avalonia;

namespace EvilBaschdi.About.Avalonia.DummyApp;

/// <inheritdoc />
public partial class MainWindow : Window
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <inheritdoc />
    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        IHandleOsDependentTitleBar handleOsDependentTitleBar = new HandleOsDependentTitleBar();
        handleOsDependentTitleBar.RunFor((this, HeaderPanel, MainPanel));
    }

    // ReSharper disable UnusedParameter.Local
    private void AboutClick(object? sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        ICurrentAssembly currentAssembly = new CurrentAssembly();
        IAboutContent aboutContent = new AboutContent(currentAssembly);
        IAboutViewModelExtended aboutModel = new AboutViewModelExtended(aboutContent);
        var aboutWindow = new AboutWindow
                          {
                              DataContext = aboutModel
                          };
        aboutWindow.ShowDialog(this);
    }
}
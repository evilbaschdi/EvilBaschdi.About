using Avalonia.Controls;
using Avalonia.Interactivity;
using EvilBaschdi.About.Avalonia.Models;
using EvilBaschdi.Core.Avalonia;

namespace EvilBaschdi.About.Avalonia.DummyApp;

/// <inheritdoc />
public partial class MainWindow : Window
{
    private readonly IHandleOsDependentTitleBar _handleOsDependentTitleBar;

    /// <summary>
    ///     Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        _handleOsDependentTitleBar = new HandleOsDependentTitleBar();
    }

    /// <inheritdoc />
    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);

        _handleOsDependentTitleBar.RunFor(this);
    }

    // ReSharper disable UnusedParameter.Local
    // ReSharper disable once UnusedMember.Local
    private void AboutClick(object? sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        ICurrentAssembly currentAssembly = new CurrentAssembly();
        IAboutContent aboutContent = new AboutContent(currentAssembly);
        IAboutViewModelExtended aboutModel = new AboutViewModelExtended(aboutContent);
        IApplicationLayout applicationLayout = new ApplicationLayout();

        var aboutWindow = new AboutWindow(aboutModel, applicationLayout, _handleOsDependentTitleBar);
        aboutWindow.ShowDialog(this);
    }
}
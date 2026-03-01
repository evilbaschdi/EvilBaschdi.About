using Avalonia.Controls;
using Avalonia.Interactivity;
using EvilBaschdi.Core.Avalonia;

namespace EvilBaschdi.About.Avalonia.DummyApp;

/// <inheritdoc />
public partial class MainWindow : Window
{
    private IHandleOsDependentTitleBar _handleOsDependentTitleBar;

    /// <summary>
    ///     Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        ApplyLayout();
    }

    private void ApplyLayout()
    {
        _handleOsDependentTitleBar = ApplicationServices.GetRequiredService<IHandleOsDependentTitleBar>();
        _handleOsDependentTitleBar?.RunFor(this);

        var applicationLayout = ApplicationServices.GetRequiredService<IApplicationLayout>();
        applicationLayout?.RunFor((this, true, false));
    }

    // ReSharper disable UnusedParameter.Local
    // ReSharper disable once UnusedMember.Local
    private void AboutClick(object sender, RoutedEventArgs e)
        // ReSharper restore UnusedParameter.Local
    {
        var aboutWindow = ApplicationServices.GetRequiredService<AboutWindow>();
        aboutWindow.ShowDialog(this);
    }
}
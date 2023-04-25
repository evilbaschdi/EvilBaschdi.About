using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using EvilBaschdi.About.Avalonia.Models;
using EvilBaschdi.Core.Avalonia;

namespace EvilBaschdi.About.Avalonia;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public partial class AboutWindow : Window
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public AboutWindow([NotNull] IAboutViewModelExtended aboutViewModel,
                       [NotNull] IApplicationLayout applicationLayout,
                       [NotNull] IHandleOsDependentTitleBar handleOsDependentTitleBar)
    {
        ArgumentNullException.ThrowIfNull(aboutViewModel);
        ArgumentNullException.ThrowIfNull(applicationLayout);
        ArgumentNullException.ThrowIfNull(handleOsDependentTitleBar);

        InitializeComponent();

        handleOsDependentTitleBar.RunFor(this);
        applicationLayout.RunFor((this, true, false));

        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
        if (mainWindow != null)
        {
            Icon = mainWindow.Icon;
        }

        DataContext = aboutViewModel;
    }
}
using Avalonia.Controls;
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
                       [NotNull] IHandleOsDependentTitleBar handleOsDependentTitleBar,
                       [NotNull] IMainWindowByApplicationLifetime mainWindowByApplicationLifetime)
    {
        ArgumentNullException.ThrowIfNull(aboutViewModel);
        ArgumentNullException.ThrowIfNull(applicationLayout);
        ArgumentNullException.ThrowIfNull(handleOsDependentTitleBar);
        ArgumentNullException.ThrowIfNull(mainWindowByApplicationLifetime);

        InitializeComponent();

        handleOsDependentTitleBar.RunFor(this);
        applicationLayout.RunFor((this, true, false));

        var mainWindow = mainWindowByApplicationLifetime.Value;
        if (mainWindow != null)
        {
            Icon = mainWindow.Icon;
        }

        DataContext = aboutViewModel;
    }
}
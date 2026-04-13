using EvilBaschdi.About.Avalonia.Models;
using EvilBaschdi.Core.Avalonia.Layout;
using EvilBaschdi.Core.Avalonia.Lifetime;
using FluentAvalonia.UI.Windowing;

namespace EvilBaschdi.About.Avalonia;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public partial class AboutWindow : FAAppWindow
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

        if (mainWindowByApplicationLifetime.Value is FAAppWindow mainWindow)
        {
            Icon = mainWindow.Icon;
        }

        DataContext = aboutViewModel;
    }
}
using Avalonia.Controls;
using EvilBaschdi.About.Avalonia.Models;
using EvilBaschdi.Core.Avalonia.Controls;
using EvilBaschdi.Core.Avalonia.Lifetime;
using EvilBaschdi.Core.Avalonia.Themes;
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
                       [NotNull] IMainWindowByApplicationLifetime mainWindowByApplicationLifetime)
    {
        ArgumentNullException.ThrowIfNull(aboutViewModel);
        ArgumentNullException.ThrowIfNull(mainWindowByApplicationLifetime);

        InitializeComponent();

        ThemeEngine.ApplyThemeToWindow(this, false);

        if (mainWindowByApplicationLifetime.Value is FAAppWindow mainWindow)
        {
            Icon = mainWindow.Icon;
            var titleBarControlParent = mainWindow.FindNameScope()?.Find<TitleBarControl>("TitleBarControl");
            var titleBarControl = this.FindNameScope()?.Find<TitleBarControl>("TitleBarControl");
            titleBarControl?.Icon = titleBarControlParent?.Icon;
        }

        DataContext = aboutViewModel;
    }
}
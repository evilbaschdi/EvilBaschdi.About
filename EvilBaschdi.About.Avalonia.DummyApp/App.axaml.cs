using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EvilBaschdi.About.Avalonia.DummyApp.ViewModels;
using EvilBaschdi.Core.Avalonia.DependencyInjection;
using EvilBaschdi.Core.Avalonia.Layout;

namespace EvilBaschdi.About.Avalonia.DummyApp;

/// <inheritdoc />
public class App : Application
{
    /// <inheritdoc />
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <inheritdoc />
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new MainWindow
                             {
                                 DataContext = ApplicationServices.GetRequiredService<MainWindowViewModel>()
                             };

            var handleOsDependentTitleBar = ApplicationServices.GetRequiredService<IHandleOsDependentTitleBar>();
            handleOsDependentTitleBar?.RunFor(mainWindow);

            var applicationLayout = ApplicationServices.GetRequiredService<IApplicationLayout>();
            applicationLayout?.RunFor((mainWindow, true, false));

            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
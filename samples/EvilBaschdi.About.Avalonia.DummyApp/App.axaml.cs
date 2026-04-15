using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EvilBaschdi.About.Avalonia.DummyApp.ViewModels;
using EvilBaschdi.Core.Avalonia.Behaviors;
using EvilBaschdi.Core.Avalonia.DependencyInjection;
using EvilBaschdi.Core.Avalonia.Layout;
using Microsoft.Extensions.DependencyInjection;

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

            mainWindow.Opened += (sender, _) =>
                                 {
                                     if (sender is not Window window)
                                     {
                                         return;
                                     }

                                     var windowOpenedBehavior = ApplicationServices.ServiceProvider?.GetRequiredService<IWindowOpenedBehavior>();
                                     windowOpenedBehavior?.OnWindowOpened(window);
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
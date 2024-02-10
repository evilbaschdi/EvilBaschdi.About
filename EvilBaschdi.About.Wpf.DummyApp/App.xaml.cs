using System.Windows;
using EvilBaschdi.DependencyInjection;

namespace EvilBaschdi.About.Wpf.DummyApp;

/// <inheritdoc />
/// <summary>
///     Interaction logic for App.xaml
/// </summary>
// ReSharper disable once RedundantExtendsListEntry
public partial class App : Application
{
    private readonly IHandleAppExit _handleAppExit;

    /// <inheritdoc />
    public App()
    {
        IHostInstance hostInstance = new HostInstance();
        IConfigureDelegateForConfigureServices configureDelegateForConfigureServices = new ConfigureDelegateForConfigureServices();
        IConfigureServicesByHostBuilderAndConfigureDelegate configureServicesByHostBuilderAndConfigureDelegate =
            new ConfigureServicesByHostBuilderAndConfigureDelegate(hostInstance, configureDelegateForConfigureServices);

        ServiceProvider = configureServicesByHostBuilderAndConfigureDelegate.Value;

        _handleAppExit = new HandleAppExit(hostInstance);
    }

    /// <summary>
    ///     ServiceProvider for DependencyInjection
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceProvider ServiceProvider { get; set; }

    /// <inheritdoc />
    protected override async void OnExit([NotNull] ExitEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);

        await _handleAppExit.Value();

        base.OnExit(e);
    }
}
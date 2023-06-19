using EvilBaschdi.About.Core.DependencyInjection;
using EvilBaschdi.About.Wpf.DependencyInjection;
using EvilBaschdi.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EvilBaschdi.About.Wpf.DummyApp;

/// <inheritdoc />
public class ConfigureDelegateForConfigureServices : IConfigureDelegateForConfigureServices
{
    /// <inheritdoc />
    public void RunFor([NotNull] HostBuilderContext _, IServiceCollection serviceCollection)
    {
        ArgumentNullException.ThrowIfNull(_);
        ArgumentNullException.ThrowIfNull(serviceCollection);

        IConfigureAboutServices configureAboutServices = new ConfigureAboutServices();
        configureAboutServices.RunFor(serviceCollection);

        serviceCollection.AddTransient(typeof(MainWindow));
    }
}
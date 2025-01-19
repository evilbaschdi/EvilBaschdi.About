using System.Reflection;
using EvilBaschdi.About.Terminal.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.About.Terminal.DummyApp;

/// <inheritdoc />
public class Startup : IStartup
{
    /// <inheritdoc />
    public IServiceProvider Value
    {
        get
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddAboutServices();

            serviceCollection.AddSingleton<ICurrentAssembly, CurrentAssembly>(_ => new CurrentAssembly(Assembly.GetExecutingAssembly()));

            return serviceCollection.BuildServiceProvider();
        }
    }
}
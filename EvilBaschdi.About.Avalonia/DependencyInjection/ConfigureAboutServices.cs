using EvilBaschdi.About.Avalonia.Models;
using EvilBaschdi.About.Avalonia.Models.Internal;
using EvilBaschdi.Core.Avalonia;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EvilBaschdi.About.Avalonia.DependencyInjection;

/// <summary />
public static class ConfigureAboutServices
{
    /// <summary />
    public static void AddAboutServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IAboutContent, AboutContent>();
        services.AddSingleton<IAboutViewModelExtended, AboutViewModelExtended>();

        services.AddSingleton<IAboutWindowReactiveCommand, AboutWindowReactiveCommand>();

        services.TryAddSingleton<IApplicationLayout, ApplicationLayout>();
        services.TryAddSingleton<ICurrentAssembly, CurrentAssembly>();
        services.TryAddSingleton<IHandleOsDependentTitleBar, HandleOsDependentTitleBar>();
        services.TryAddSingleton<IMainWindowByApplicationLifetime, MainWindowByApplicationLifetime>();

        services.AddTransient<AboutWindow>();
    }
}
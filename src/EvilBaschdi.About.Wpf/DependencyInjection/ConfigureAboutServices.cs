using EvilBaschdi.Core.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EvilBaschdi.About.Wpf.DependencyInjection;

/// <summary />
public static class ConfigureAboutServices
{
    /// <summary />
    public static void AddAboutServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IAboutContent, AboutContent>();
        services.AddSingleton<IAboutViewModel, AboutViewModel>();

        services.TryAddSingleton<IApplicationLayout, ApplicationLayout>();
        services.TryAddSingleton<IApplyMicaBrush, ApplyMicaBrush>();
        services.TryAddSingleton<ICurrentAssembly, CurrentAssembly>();

        services.AddTransient(typeof(AboutWindow));
    }
}
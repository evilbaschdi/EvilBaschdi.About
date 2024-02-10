using EvilBaschdi.About.Core.DependencyInjection;
using EvilBaschdi.Core.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EvilBaschdi.About.Wpf.DependencyInjection;

/// <inheritdoc />
public class ConfigureAboutServices : IConfigureAboutServices
{
    /// <inheritdoc />
    public void RunFor([NotNull] IServiceCollection services)
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
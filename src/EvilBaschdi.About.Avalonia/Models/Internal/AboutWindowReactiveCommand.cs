using EvilBaschdi.Core.Avalonia.DependencyInjection;
using EvilBaschdi.Core.Avalonia.Lifetime;
using EvilBaschdi.Core.Avalonia.Mvvm.Command;

namespace EvilBaschdi.About.Avalonia.Models.Internal;

/// <inheritdoc cref="IAboutWindowReactiveCommand" />
/// <inheritdoc cref="ReactiveCommandRxVoidTask" />
public class AboutWindowReactiveCommand(
    [NotNull] IMainWindowByApplicationLifetime mainWindowByApplicationLifetime) : ReactiveCommandRxVoidTask, IAboutWindowReactiveCommand
{
    private readonly IMainWindowByApplicationLifetime _mainWindowByApplicationLifetime =
        mainWindowByApplicationLifetime ?? throw new ArgumentNullException(nameof(mainWindowByApplicationLifetime));

    /// <inheritdoc />
    public override async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var aboutWindow = ApplicationServices.GetRequiredService<AboutWindow>();
        var mainWindow = _mainWindowByApplicationLifetime.Value;
        if (mainWindow is not null)
        {
            await aboutWindow.ShowDialog(mainWindow);
        }
    }
}
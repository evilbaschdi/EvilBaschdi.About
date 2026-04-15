using System.Reactive;
using EvilBaschdi.About.Avalonia.Models.Internal;
using ReactiveUI;

namespace EvilBaschdi.About.Avalonia.DummyApp.ViewModels;

/// <summary>
/// </summary>
public class MainWindowViewModel
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="aboutWindowReactiveCommand"></param>
    public MainWindowViewModel(
        IAboutWindowReactiveCommand aboutWindowReactiveCommand)
    {
        AboutWindowCommand = aboutWindowReactiveCommand.Command;
    }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public ReactiveCommand<Unit, Unit> AboutWindowCommand { get; set; }
}
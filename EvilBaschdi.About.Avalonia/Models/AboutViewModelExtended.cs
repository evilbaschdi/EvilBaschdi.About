using System.Reactive;
using Avalonia.Media.Imaging;
using EvilBaschdi.About.Avalonia.Models.Internal;
using ReactiveUI;

namespace EvilBaschdi.About.Avalonia.Models;

/// <summary>
/// </summary>
// ReSharper disable once UnusedType.Global
public class AboutViewModelExtended : AboutViewModel, IAboutViewModelExtended
{
    private readonly AboutModel _aboutModel;

    /// <summary>
    /// </summary>
    /// <param name="aboutContent"></param>
    /// <param name="aboutWindowReactiveCommand"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public AboutViewModelExtended(
        IAboutContent aboutContent,
        IAboutWindowReactiveCommand aboutWindowReactiveCommand)
        : base(aboutContent)
    {
        _aboutModel = aboutContent.Value;
        AboutWindowCommand = aboutWindowReactiveCommand.Command;
    }

    /// <summary>
    /// </summary>
    public Bitmap LogoSource => new(_aboutModel.LogoSourcePath);

    /// <summary>
    /// </summary>
    // ReSharper disable UnusedAutoPropertyAccessor.Global
    public ReactiveCommand<Unit, Unit> AboutWindowCommand { get; set; }

    // ReSharper restore UnusedMember.Global
}
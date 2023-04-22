using Avalonia.Media.Imaging;

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
    /// <exception cref="ArgumentNullException"></exception>
    public AboutViewModelExtended(IAboutContent aboutContent)
        : base(aboutContent)
    {
        var innerAboutContent = aboutContent ?? throw new ArgumentNullException(nameof(aboutContent));
        _aboutModel = innerAboutContent.Value;
    }

    /// <summary>
    /// </summary>
    public Bitmap LogoSource => new(_aboutModel.LogoSourcePath);

    // ReSharper restore UnusedMember.Global
}
namespace EvilBaschdi.About.Core.Models;

/// <inheritdoc />
public class AboutViewModel : IAboutViewModel
{
    private readonly AboutModel _aboutModel;

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="aboutContent"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public AboutViewModel([NotNull] IAboutContent aboutContent)
    {
        var innerAboutContent = aboutContent ?? throw new ArgumentNullException(nameof(aboutContent));
        _aboutModel = innerAboutContent.Value;
    }

    /// <summary>
    /// </summary>
    // ReSharper disable UnusedMember.Global
    public string ApplicationTitle => _aboutModel.ApplicationTitle;

    /// <summary>
    /// </summary>
    public string Company => $"Company / Authors: {_aboutModel.Company}";

    /// <summary>
    /// </summary>
    public string Copyright => $"{_aboutModel.Copyright}";

    /// <summary>
    /// </summary>
    public string Description => _aboutModel.Description;

    /// <summary>
    /// </summary>
    public string LogoSourcePath => _aboutModel.LogoSourcePath;

    /// <summary>
    /// </summary>
    public string ReferencedAssemblies => _aboutModel.ReferencedAssemblies;

    /// <summary>
    /// </summary>
    public string Runtime => $"CLR: {_aboutModel.Runtime}";

    /// <summary>
    /// </summary>
    public string Version => $"Version: {_aboutModel.Version}";
    // ReSharper restore UnusedMember.Global
}
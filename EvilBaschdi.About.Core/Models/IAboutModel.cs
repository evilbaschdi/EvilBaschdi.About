namespace EvilBaschdi.About.Core.Models;

/// <summary>
/// </summary>
public interface IAboutModel
{
    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    string ApplicationTitle { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    string Company { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    string Copyright { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    string Description { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    string LogoSourcePath { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    string ReferencedAssemblies { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    string Runtime { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    string Version { get; }
}
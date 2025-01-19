using System.Reflection;

namespace EvilBaschdi.About.Terminal;

/// <inheritdoc />
public class CurrentAssembly(
    [NotNull] Assembly assembly) : ICurrentAssembly
{
    /// <inheritdoc />
    public Assembly Value { get; } = assembly ?? throw new ArgumentNullException(nameof(assembly));
}
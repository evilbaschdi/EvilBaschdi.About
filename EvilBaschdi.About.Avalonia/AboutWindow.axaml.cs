using Avalonia.Controls;
using EvilBaschdi.About.Avalonia.Models;
using EvilBaschdi.Core.Avalonia;

namespace EvilBaschdi.About.Avalonia;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public partial class AboutWindow : Window
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public AboutWindow([NotNull] IAboutViewModelExtended aboutViewModel)
    {
        InitializeComponent();

        IHandleOsDependentTitleBar handleOsDependentTitleBar = new HandleOsDependentTitleBar();
        handleOsDependentTitleBar.RunFor((this, HeaderPanel, MainPanel, AcrylicBorder));

        DataContext = aboutViewModel ?? throw new ArgumentNullException(nameof(aboutViewModel));
    }
}
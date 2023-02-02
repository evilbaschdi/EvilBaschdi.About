using Avalonia.Controls;
using EvilBaschdi.Core.Avalonia;

namespace EvilBaschdi.About.Avalonia;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public partial class AboutWindow : Window
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public AboutWindow()
    {
        InitializeComponent();

        IHandleOsDependentTitleBar handleOsDependentTitleBar = new HandleOsDependentTitleBar();
        handleOsDependentTitleBar.RunFor((this, HeaderPanel, MainPanel));
    }
}
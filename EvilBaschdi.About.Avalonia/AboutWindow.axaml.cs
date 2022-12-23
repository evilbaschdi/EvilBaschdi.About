using Avalonia.Controls;
using EvilBaschdi.Avalonia.Core;

namespace EvilBaschdi.About.Avalonia;

/// <inheritdoc />
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
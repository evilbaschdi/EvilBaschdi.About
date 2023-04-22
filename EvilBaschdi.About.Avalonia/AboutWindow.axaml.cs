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
    public AboutWindow([NotNull] IAboutViewModelExtended aboutViewModel,
                       [NotNull] IApplicationLayout applicationLayout,
                       [NotNull] IHandleOsDependentTitleBar handleOsDependentTitleBar)
    {
        ArgumentNullException.ThrowIfNull(aboutViewModel);
        ArgumentNullException.ThrowIfNull(applicationLayout);
        ArgumentNullException.ThrowIfNull(handleOsDependentTitleBar);

        InitializeComponent();

        handleOsDependentTitleBar.RunFor(this);
        applicationLayout.RunFor((this, true, false));

        DataContext = aboutViewModel;
    }
}
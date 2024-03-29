﻿using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using EvilBaschdi.Core.Wpf;

namespace EvilBaschdi.About.Wpf;

/// <summary>
///     Interaction logic for AboutWindow.xaml
/// </summary>
// ReSharper disable once UnusedType.Global
public partial class AboutWindow
{
    private readonly IApplyMicaBrush _applyMicaBrush;

    /// <exception cref="ArgumentNullException"></exception>
    /// <inheritdoc />
    public AboutWindow([NotNull] IAboutViewModel aboutViewModel,
                       [NotNull] IApplicationLayout applicationLayout,
                       [NotNull] IApplyMicaBrush applyMicaBrush)
    {
        ArgumentNullException.ThrowIfNull(aboutViewModel);
        ArgumentNullException.ThrowIfNull(applicationLayout);
        ArgumentNullException.ThrowIfNull(applyMicaBrush);
        _applyMicaBrush = applyMicaBrush;

        InitializeComponent();

        applicationLayout.RunFor((this, true, false));

        Loaded += AboutWindowLoaded;
        DataContext = aboutViewModel;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private void WindowContentRendered([NotNull] object sender, [NotNull] EventArgs e)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(e);
        _applyMicaBrush.RunFor((HwndSource)sender, this);
    }

    private void AboutWindowLoaded([NotNull] object sender, [NotNull] RoutedEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(e);
        // Get PresentationSource
        var presentationSource = PresentationSource.FromVisual((Visual)sender);

        // Subscribe to PresentationSource's ContentRendered event
        if (presentationSource != null)
        {
            presentationSource.ContentRendered += WindowContentRendered;
        }
    }
}
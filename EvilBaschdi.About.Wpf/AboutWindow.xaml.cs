using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using EvilBaschdi.About.Core.Models;
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
    public AboutWindow(IAboutViewModel aboutViewModel, [NotNull] IApplyMicaBrush applyMicaBrush)
    {
        if (aboutViewModel == null)
        {
            throw new ArgumentNullException(nameof(aboutViewModel));
        }

        _applyMicaBrush = applyMicaBrush ?? throw new ArgumentNullException(nameof(applyMicaBrush));

        InitializeComponent();

        Loaded += AboutWindowLoaded;
        DataContext = aboutViewModel;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private void WindowContentRendered(object sender, EventArgs e)
    {
        _applyMicaBrush.RunFor((HwndSource)sender);
    }

    private void AboutWindowLoaded(object sender, RoutedEventArgs e)
    {
        // Get PresentationSource
        var presentationSource = PresentationSource.FromVisual((Visual)sender);

        // Subscribe to PresentationSource's ContentRendered event
        if (presentationSource != null)
        {
            presentationSource.ContentRendered += WindowContentRendered;
        }
    }
}
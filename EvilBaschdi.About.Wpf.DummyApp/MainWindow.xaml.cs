using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using EvilBaschdi.Core.Wpf;
using Microsoft.Extensions.DependencyInjection;

namespace EvilBaschdi.About.Wpf.DummyApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    /// <summary>
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        Loaded += MainWindowLoaded;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private void WindowContentRendered(object sender, EventArgs e)
    {
        var applyMicaBrush = new ApplyMicaBrush();
        applyMicaBrush.RunFor((HwndSource)sender, this);
    }

    private void MainWindowLoaded(object sender, RoutedEventArgs e)
    {
        // Get PresentationSource
        var presentationSource = PresentationSource.FromVisual((Visual)sender);

        // Subscribe to PresentationSource's ContentRendered event
        if (presentationSource != null)
        {
            presentationSource.ContentRendered += WindowContentRendered;
        }
    }

    private void AboutClick(object sender, RoutedEventArgs e)
    {
        var aboutWindow = App.ServiceProvider.GetRequiredService<AboutWindow>();
        aboutWindow.ShowDialog();
    }
}
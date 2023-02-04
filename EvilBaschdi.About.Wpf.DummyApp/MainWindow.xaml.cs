using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using EvilBaschdi.About.Core;
using EvilBaschdi.About.Core.Models;
using EvilBaschdi.Core.Wpf;

namespace EvilBaschdi.About.Wpf.DummyApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private IApplyMicaBrush _applyMicaBrush;

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
        _applyMicaBrush = new ApplyMicaBrush();
        _applyMicaBrush.RunFor((HwndSource)sender);
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
        ICurrentAssembly currentAssembly = new CurrentAssembly();
        IAboutContent aboutContent = new AboutContent(currentAssembly);
        IAboutViewModel aboutViewModel = new AboutViewModel(aboutContent);
        var aboutWindow = new AboutWindow(aboutViewModel, _applyMicaBrush);
        aboutWindow.ShowDialog();
    }
}
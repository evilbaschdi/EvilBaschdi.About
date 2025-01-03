using Spectre.Console;

namespace EvilBaschdi.About.Terminal;

/// <inheritdoc />
public class WriteAboutTable(
    [NotNull] IAboutViewModel aboutViewModel) : IWriteAboutTable
{
    private readonly IAboutViewModel _aboutViewModel = aboutViewModel ?? throw new ArgumentNullException(nameof(aboutViewModel));

    /// <inheritdoc />
    public void Run()
    {
        var aboutTable = new Table()
                         .Title("About")
                         .Centered()
                         .Border(TableBorder.Square)
                         .BorderColor(Color.GreenYellow)
                         .AddColumn(new("[u]Property[/]"))
                         .AddColumn(new("[u]Value[/]"));

        aboutTable.AddRow("[white]ApplicationTitle[/]", $"[white]{_aboutViewModel.ApplicationTitle}[/]");
        aboutTable.AddRow("[white]Version[/]", $"[white]{_aboutViewModel.Version}[/]");
        aboutTable.AddRow("[white]Runtime[/]", $"[white]{_aboutViewModel.Runtime}[/]");
        aboutTable.AddRow("[white]Copyright[/]", $"[white]{_aboutViewModel.Copyright}[/]");
        aboutTable.AddRow("[white]Description[/]", $"[white]{_aboutViewModel.Description}[/]");

        AnsiConsole.Write(aboutTable);
    }
}
using Spectre.Console;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class routePrint
{
    public void RouteInfoOutput(RouteFinalInfo route)
    {
        var table = new Table();
        table.Title("Route Info");
        table.Width(150);

        table.AddColumn(new TableColumn("Start Location").Centered());
        table.AddColumn(new TableColumn("CheckPoints").Centered());
        table.AddColumn(new TableColumn("Stop Location").Centered());
        table.AddColumn(new TableColumn("Distance").Centered());

        table.AddRow(
            route.Start,
            string.Join(" - ", route.CheckPoints),
            route.Stop,
            $"{route.TotalDistanceKm:F2} km"
        );

        AnsiConsole.Write(table);
    }
}

using Intermediate_Oppgave_3_Drone_Race.Classes;
using Spectre.Console;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class routePrint
{
    RouteFinalInfo route = RouteInfo.Route();

    public void RouteInfoOutput()
    {
        RouteFinalInfo route = RouteInfo.Route();

        var table = new Table();
        table.Title("Route Info");
        table.Width(150);

        table.AddColumn(new TableColumn("Start Location").Centered());
        table.AddColumn(new TableColumn("CheckPoints").Centered());
        table.AddColumn(new TableColumn("Stop Location").Centered());
        table.AddColumn(new TableColumn("Distance").Centered());

        table.AddRow(
            new Text(route.Start),
            new Text(string.Join(" - ", route.CheckPoints)),
            new Text(route.Stop),
            new Text($"{route.TotalDistanceKm:F2} km")
        );

        AnsiConsole.Write(table);
        Console.ReadKey();
    }
}

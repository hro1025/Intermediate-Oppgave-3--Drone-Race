using System.Text.Json;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class RouteInfo
{
    static readonly Random random = new();

    public void Route()
    {
        List<int> checkPointPosition = new();

        for (int i = 0; i < 10; i++)
        {
            int checkPoint = random.Next(0, 40);

            if (!checkPointPosition.Contains(checkPoint))
            {
                checkPointPosition.Add(checkPoint);
            }
            else
            {
                i--;
            }
        }

        int startPosition = random.Next(0, 40);
        int stopPosition = random.Next(0, 40);

        string jsonString = File.ReadAllText("Data/CheckPointData.json");

        var data = JsonSerializer.Deserialize<CheckPointInfo.CapitalsData>(jsonString);

        var startLocation = data.Capitals.FirstOrDefault(c => c.Id == startPosition);

        var stopLocation = data.Capitals.FirstOrDefault(c => c.Id == stopPosition);

        var checkPointLocation = data
            .Capitals.Where(c => checkPointPosition.Contains(c.Id))
            .ToList();

        var table = new Table();
        table.Title("Route Info");
        table.Width(150);

        table.AddColumn(new TableColumn("Start Location").Centered());
        table.AddColumn(new TableColumn("CheckPoints").Centered());
        table.AddColumn(new TableColumn("Stop Location").Centered());

        table.AddRow(
            new Text(startLocation.Name),
            new Text(string.Join(" - ", checkPointLocation.Select(c => c.Name))),
            new Text(stopLocation.Name)
        );

        AnsiConsole.Write(table);
        Console.ReadKey();
    }
}

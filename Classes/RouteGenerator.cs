using System.Text.Json;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class RouteGenerator
{
    static readonly Random random = new();

    public List<int> checkPointPosition = new();

    public void Route()
    {
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

        var data = JsonSerializer.Deserialize<JsonData.CapitalsData>(jsonString);

        var startLocation = data.Capitals.FirstOrDefault(c => c.Id == startPosition);

        var stopLocation = data.Capitals.FirstOrDefault(c => c.Id == stopPosition);

        var checkPointLocation = data
            .Capitals.Where(c => checkPointPosition.Contains(c.Id))
            .ToList();

        return new RouteResult
        {
            StartId = startLocation,
            StopId = stopLocation,
            CheckpointsId = checkPointLocation,
        };
    }
}

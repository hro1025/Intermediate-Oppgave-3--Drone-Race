using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Intermediate_Oppgave_3_Drone_Race.Models;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class RouteInfo
{
    public static void Route()
    {
        List<int> checkPointPositions = new();

        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            int checkPoint = random.Next(0, 40);

            if (!checkPointPositions.Contains(checkPoint))
                checkPointPositions.Add(checkPoint);
            else
                i--;
        }

        int startPosition = random.Next(0, 40);
        int stopPosition = random.Next(0, 40);

        string jsonString = File.ReadAllText("Data/Data.json");
        var data = JsonSerializer.Deserialize<GetSetData.CapitalsData>(jsonString);

        var startLocation = data.Capitals.FirstOrDefault(c => c.Id == startPosition);
        var stopLocation = data.Capitals.FirstOrDefault(c => c.Id == stopPosition);

        var checkPoints = checkPointLocations.Select(c => c.Name).ToList();

        double totalDistance = 0;

        totalDistance += data.DistanceMatrix[startLocation.Id][checkPointLocations[0].Id];

        for (int i = 0; i < checkPointLocations.Count - 1; i++)
        {
            totalDistance += data.DistanceMatrix[checkPointLocations[i].Id][
                checkPointLocations[i + 1].Id
            ];
        }

        totalDistance += data.DistanceMatrix[checkPointLocations[^1].Id][stopLocation.Id];

        var Start = startLocation?.Name ?? "Unknown";
        var checkPoints = checkPointLocations.Name;
        var Stop = stopLocation?.Name ?? "Unknown";

        var km = totalDistance;
    }
}

public class RouteFinalInfo
{
    public string Start { get; set; } = "";
    public List<string> CheckPoints { get; set; } = new();
    public string Stop { get; set; } = "";
    public double TotalDistanceKm { get; set; }
}

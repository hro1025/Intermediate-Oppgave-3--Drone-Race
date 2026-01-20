using System.Text.Json;
using Intermediate_Oppgave_3_Drone_Race.Models;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class RouteInfo
{
    public static RouteFinalInfo Route()
    {
        Random random = new();

        int startId = random.Next(0, 40);
        int stopId = random.Next(0, 40);

        List<int> checkPointIds = new();
        while (checkPointIds.Count < 5)
        {
            int id = random.Next(0, 40);
            if (id != startId && id != stopId && !checkPointIds.Contains(id))
                checkPointIds.Add(id);
        }

        string jsonString = File.ReadAllText("Data/Data.json");
        var data = JsonSerializer.Deserialize<GetSetData.CapitalsData>(jsonString)!;

        var start = data.Capitals.First(c => c.Id == startId);
        var stop = data.Capitals.First(c => c.Id == stopId);

        double totalKm =
            data.DistanceMatrix[startId][checkPointIds[0]]
            + checkPointIds
                .Zip(checkPointIds.Skip(1), (from, to) => data.DistanceMatrix[from][to])
                .Sum()
            + data.DistanceMatrix[checkPointIds[^1]][stopId];

        return new RouteFinalInfo
        {
            Start = start.Name,
            Stop = stop.Name,
            CheckPoints = checkPointIds
                .Select(id => data.Capitals.First(c => c.Id == id).Name)
                .ToList(),
            TotalDistanceKm = totalKm,
        };
    }
}

public class RouteFinalInfo
{
    public string Start { get; set; } = "";
    public List<string> CheckPoints { get; set; } = new();
    public string Stop { get; set; } = "";
    public double TotalDistanceKm { get; set; }
}

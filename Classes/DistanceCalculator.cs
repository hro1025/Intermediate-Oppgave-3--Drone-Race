using System.CodeDom.Compiler;
using System.Diagnostics;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class DistanceCalculator
{
    RouteGenerator generator = new RouteGenerator();
    RouteResult route = generator.Route();

    public void Distance()
    {
        var fullRouteId = new List<int>();
        fullRouteId.Add(route.StartId);
        fullRouteId.AddRange(route.CheckpointId);
        fullRouteId.Add(route.StopId);

        Console.WriteLine(fullRouteId);
    }
}

using System.Transactions;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class DroneInfo
{
    public void ThreadDrone(RouteFinalInfo route)
    {
        var drone1 = new Thread(() => FlyRoute(route, "Drone 1"));
        var drone2 = new Thread(() => FlyRoute(route, "Drone 2"));

        drone1.Start();
        drone2.Start();

        drone1.Join();
        drone2.Join();
    }

    public void FlyRoute(RouteFinalInfo route, string droneName)
    {
        Console.WriteLine($"{droneName} Departing from {route.Start}");

        foreach (var location in route.CheckPoints)
        {
            Console.WriteLine($"{droneName} flying over {location}");
            Thread.Sleep(1000);
        }

        Console.WriteLine($"{droneName} finished route at {route.Stop}");
    }
}

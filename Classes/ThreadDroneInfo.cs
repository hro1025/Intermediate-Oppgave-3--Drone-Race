using System.Transactions;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class ThreadDroneInfo
{
    public void ThreadDrone(RouteFinalInfo route)
    {
        var threadDrone1 = new Thread(() => FlyRoute(route, "Drone 1"));
        var threadDrone2 = new Thread(() => FlyRoute(route, "Drone 2"));

        threadDrone1.Start();
        threadDrone2.Start();

        threadDrone1.Join();
        threadDrone2.Join();
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

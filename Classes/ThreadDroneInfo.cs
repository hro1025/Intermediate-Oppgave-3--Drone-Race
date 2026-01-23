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
        Random random = new Random();

        Console.WriteLine($"{droneName} Departing from {route.Start}");
        Thread.Sleep(1000);

        foreach (var location in route.CheckPoints)
        {
            int delay = random.Next(100, 500);
            Thread.Sleep(delay);
            Console.WriteLine($"{droneName} flying over {location, -25} {delay, 5} ms");
        }
        Thread.Sleep(1000);
        Console.WriteLine($"{droneName} landed at {route.Stop}");
    }
}

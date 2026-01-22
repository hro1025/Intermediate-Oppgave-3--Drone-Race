using System.Diagnostics.Metrics;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class TaskDroneInfo
{
    public async Task TaskDrone(RouteFinalInfo route)
    {
        var masterTsc = new TaskCompletionSource();

        var taskDrone1 = Task.Run(() => TaskDroneRoute(route, "Drone 1"));

        var taskDrone2 = Task.Run(() => TaskDroneRoute(route, "Drone 2"));

        await Task.WhenAll(taskDrone1, taskDrone2);

        masterTsc.SetResult();
    }

    public static Task TaskDroneRoute(RouteFinalInfo route, string droneName)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"{droneName} Departing from {route.Start}");

            foreach (var location in route.CheckPoints)
            {
                Console.WriteLine($"{droneName} flying over {location}");
                Thread.Sleep(1000);
            }

            Console.WriteLine($"{droneName} finished route at {route.Stop}");
        });
    }
}

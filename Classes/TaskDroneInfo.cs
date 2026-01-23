using System.Diagnostics.Metrics;
using Microsoft.VisualBasic;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class TaskDroneInfo
{
    public async Task TaskDrone(RouteFinalInfo route)
    {
        var masterTsc = new TaskCompletionSource();

        var taskDrone1 = Task.Run(() => FlyRoute(route, "Drone 1"));

        var taskDrone2 = Task.Run(() => FlyRoute(route, "Drone 2"));

        await Task.WaitAll(taskDrone1, taskDrone2);

        masterTsc.SetResult();
    }

    public static Task FlyRoute(RouteFinalInfo route, string droneName)
    {
        Random random = new Random();
        return Task.Run(async () =>
        {
            Console.WriteLine($"{droneName} Departing from {route.Start}");
            await Task.Delay(1000);

            foreach (var location in route.CheckPoints)
            {
                int delay = random.Next(100, 500);
                await Task.Delay(delay);

                Console.WriteLine($"{droneName} flying over {location, -25} {delay, 5} ms");
            }

            await Task.Delay(1000);
            Console.WriteLine($"{droneName} landed at {route.Stop}");
        });
    }
}

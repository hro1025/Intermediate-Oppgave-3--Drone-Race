using System.Diagnostics.Metrics;
using Microsoft.VisualBasic;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class TaskDroneInfo
{
    public async Task TaskDrone(RouteFinalInfo route)
    {
        Random random = new Random();

        var masterTcs = new TaskCompletionSource<bool>();

        var taskDrone1 = Task.Run(() => FlyRoute(route, "Drone 1"));
        var taskDrone2 = Task.Run(() => FlyRoute(route, "Drone 2"));

        bool crashHappens = random.Next(0, 2) == 1;

        if (crashHappens)
        {
            int crashedDrone = random.Next(1, 3); // 1 or 2

            if (crashedDrone == 1)
            {
                masterTcs.SetException(new Exception("Drone 1 crashed"));
            }
            else
            {
                masterTcs.SetException(new Exception("Drone 2 crashed"));
            }
        }
        else
        {
            _ = Task.WhenAll(taskDrone1, taskDrone2)
                .ContinueWith(t =>
                {
                    if (t.IsFaulted)
                        masterTcs.SetException(t.Exception!);
                    else
                        masterTcs.SetResult(true);
                });
        }
        await masterTcs.Task;
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

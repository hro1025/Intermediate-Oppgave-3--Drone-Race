using System.Collections;
using Intermediate_Oppgave_3_Drone_Race.Classes;
using Spectre.Console;

namespace Intermediate_Oppgave_3_Drone_Race;

class Program
{
    static async Task Main(string[] args)
    {
        var print = new routePrint();
        var threadDroneInfo = new ThreadDroneInfo();
        var taskDroneInfo = new TaskDroneInfo();

        while (true)
        {
            Console.Clear();

            var operation = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Choose your Operation[/]")
                    .AddChoices("Thread + Join", "Task and TaskCompletionSource", "Exit")
            );

            switch (operation)
            {
                case "Thread + Join":
                {
                    Console.Clear();

                    var route = RouteInfo.Route();
                    print.RouteInfoOutput(route);

                    Console.WriteLine("\nPress any key to start drones...");
                    Console.ReadKey();

                    threadDroneInfo.ThreadDrone(route);

                    Console.WriteLine("\nAll drones have finished the route.");
                    Console.ReadKey();
                    break;
                }
                case "Task and TaskCompletionSource":
                {
                    Console.Clear();
                    var route = RouteInfo.Route();
                    print.RouteInfoOutput(route);

                    Console.WriteLine("\nPress any key to start drones...");
                    Console.ReadKey();

                    await taskDroneInfo.TaskDrone(route);

                    Console.WriteLine("\nAll drones have finished the route.");
                    Console.ReadKey();
                    break;
                }

                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

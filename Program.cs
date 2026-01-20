using Intermediate_Oppgave_3_Drone_Race.Classes;
using Spectre.Console;

namespace Intermediate_Oppgave_3_Drone_Race;

class Program
{
    static void Main(string[] args)
    {
        var print = new routePrint();
        var droneInfo = new DroneInfo();

        while (true)
        {
            Console.Clear();

            var operation = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Choose your Operation[/]")
                    .AddChoices("Thread + Join", "Exit")
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

                    droneInfo.ThreadDrone(route);

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

using System.Collections;
using System.Runtime.CompilerServices;

namespace Intermediate_Oppgave_3_Drone_Race;

class Program
{
    static void Main(string[] args)
    {
        var controlTower = new ControlTower();

        var t1 = new Thread(controlTower.Fly);
        t1.Start();
        var t2 = new Thread(controlTower.Fly);
        t2.Start();

        t1.Join();
        t2.Join();

        while (true)
        {
            // create the selection menu
            Console.WriteLine();
            var operation = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold]Choose your Operation[/]?")
                    .AddChoices(
                        new[] { "Thread + Join", "Task + CompletionSource", "Async/Await", "Exit" }
                    )
            );

            switch (operation)
            {
                case "Thead + Join":

                    break;

                case "Task + CompletionSource":

                    break;

                case "Async/Await":

                    break;

                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

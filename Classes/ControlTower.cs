namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class ControlTower
{
    public void Fly()
    {
        var random = new Random();
        var randomNumber = random.Next(1, 101);

        Console.WriteLine("Start flying");

        for (int i = 0; i < randomNumber; i++)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("Finished flying");
    }
}

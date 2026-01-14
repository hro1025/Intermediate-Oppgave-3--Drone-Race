using System.Security.Cryptography.X509Certificates;

namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class RouteInfo
{
    private static readonly Random random = new();

    public void Route()
    {
        List<int> checkPointPosition = new();

        for (int i = 0; i < 10; i++)
        {
            int checkPoint = random.Next(0, 40);

            if (!checkPointPosition.Contains(checkPoint))
            {
                checkPointPosition.Add(checkPoint);
            }
            else
            {
                i--;
            }
        }

        int startPosition = random.Next(0, 40);
        int stopPosition = random.Next(0, 40);

        Console.Write($"{startPosition} - ");

        foreach (var cp in checkPointPosition)
        {
            Console.Write($"{cp} ");
        }

        Console.WriteLine($"- {stopPosition}");
    }
}

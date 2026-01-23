namespace Intermediate_Oppgave_3_Drone_Race.Classes;

public class DelayGenerator
{
    public static async Task RandomDelayAsync(int minMilliseconds, int maxMilliseconds)
    {
        Random random = new Random();
        int delay = random.Next(minMilliseconds, maxMilliseconds);
        await Task.Delay(delay);
    }
}

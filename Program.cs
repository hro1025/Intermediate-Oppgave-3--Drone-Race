namespace Intermediate_Oppgave_3__Drone_Race;

class Program
{
    static void Main(string[] args)
    {
        var controlTower = new ControlTower();
        var t1 = new Thread(controlTower.Fly);
        var t2 = new Thread(controlTower.Fly);
        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }
}

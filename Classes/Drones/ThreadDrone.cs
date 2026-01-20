// using System.Diagnostics;

// namespace Intermediate_Oppgave_3_Drone_Race.Classes;

// public class DroneInfo
// {
//     public void ThreadDrone()
//     {
//         var route = RouteInfo.Route();

//         Console.WriteLine("Route generated:");
//         Console.WriteLine($"Start: {route.Start}");
//         Console.WriteLine($"Stop: {route.Stop}");
//         Console.WriteLine($"Total distance: {route.TotalDistanceKm:F2} km");

//         Console.WriteLine("Press Enter to start the delivery");
//         Console.ReadKey();

//         var drone1 = new Thread(() => FlyRoute(route, "Drone 1"));
//         var drone2 = new Thread(() => FlyRoute(route, "Drone 2"));

//         drone1.Start();
//         drone2.Start();

//         drone1.Join();
//         drone2.Join();
//     }
// }

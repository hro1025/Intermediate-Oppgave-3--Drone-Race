using Intermediate_Oppgave_3_Drone_Race.Classes;

namespace Intermediate_Oppgave_3_Drone_Race.Models;

public class GetSetData
{
    public class CapitalsData
    {
        public MetaData Meta { get; set; } = null!;
        public List<CapitalInfo> Capitals { get; set; } = null!;
        public List<List<double>> DistanceMatrix { get; set; } = null!;
    }

    public class MetaData
    {
        public string DistanceUnit { get; set; } = null!;
    }

    public class CapitalInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}

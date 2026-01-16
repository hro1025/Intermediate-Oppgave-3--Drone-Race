public class JsonData
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

    public class RouteResult
    {
        public int StartId { get; set; }
        public int StopId { get; set; }
        public List<int> CheckpointIds { get; set; } = new();
    }
}

using System.Text.Json.Serialization;

public class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Feature>? Features { get; set; }

    public string GetMagnitud()
    {
        if (Features == null || Features.Count == 0)
        {
            return "No earthquakes found.";
        }

        double maxMag = Features
            .Where(f => f.Properties?.Mag != null)
            .Select(f => f.Properties!.Mag!.Value)
            .DefaultIfEmpty(0)
            .Max();

        return $"Max magnitude: {maxMag}";
    }
}

public class Feature
{
    [JsonPropertyName("properties")]
    public EarthquakeProperties? Properties { get; set; }
}

public class EarthquakeProperties
{
    [JsonPropertyName("mag")]
    public double? Mag { get; set; }

    [JsonPropertyName("place")]
    public string? Place { get; set; }
}
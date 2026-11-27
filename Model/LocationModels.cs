namespace PurduePasta.Model;

public sealed class DeliveryLocation
{
    public string Name { get; init; } = string.Empty;
    public string Neighborhood { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string Emoji { get; init; } = "📍";
    public string Eta { get; init; } = string.Empty;
    public bool IsFeatured { get; init; }
}

namespace BikeAuctionIntegration.Domain;

public class Tax
{
    public required string Type { get; set; }
    public double Percentage { get; set; }
}
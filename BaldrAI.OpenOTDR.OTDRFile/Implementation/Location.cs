namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class LocationConfig(double? longitudeSF = null, double? latitudeSF = null)
{
    private double LongitudeSF = longitudeSF ?? 1000000.0;
    private double LatitudeSF = latitudeSF ?? 1000000.0;

    // These are best-guesses based on the max-value of an `int32` and the required max-values for longitude and latitude.
}

public class Location
{
    public LocationData Data { get; }
    public LocationConfig Config;

    public string LocationNumber
    {
        get => Data.LocationNumber;
        set => Data.LocationNumber = value;
    }

    public uint LocationDistance
    {
        get => Data.LocationDistance;
        set => Data.LocationDistance = value;
    }

    public short LocationDrift
    {
        get => Data.LocationDrift;
        set => Data.LocationDrift = value;
    }

    public ushort EventNumber
    {
        get => Data.EventNumber;
        set => Data.EventNumber = value;
    }

    public int Longitude
    {
        get => Data.Longitude;
        set => Data.Longitude = value;
    }

    public int Latitude
    {
        get => Data.Latitude;
        set => Data.Latitude = value;
    }

    public string CableIDEnteringLocation
    {
        get => Data.CableIDEnteringLocation;
        set => Data.CableIDEnteringLocation = value;
    }

    public string FiberIDEnteringLocation
    {
        get => Data.FiberIDEnteringLocation;
        set => Data.FiberIDEnteringLocation = value;
    }

    public string CableIDExitingLocation
    {
        get => Data.CableIDExitingLocation;
        set => Data.CableIDExitingLocation = value;
    }

    public string FiberIDExitingLocation
    {
        get => Data.FiberIDExitingLocation;
        set => Data.FiberIDExitingLocation = value;
    }

    public string Comment
    {
        get => Data.Comment;
        set => Data.Comment = value;
    }

    public Location(Span<byte> data, ref int offset, LocationConfig? config = null)
    {
        Data = new LocationData(data, ref offset);
        Config = config ?? new LocationConfig();
    }

    public Location(LocationData data, LocationConfig? config = null)
    {
        Data = data;
        Config = config ?? new LocationConfig();
    }
}
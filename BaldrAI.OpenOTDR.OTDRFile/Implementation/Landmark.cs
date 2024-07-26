namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class LandmarkConfig(double? longitudeSF = null, double? latitudeSF = null)
{
    public double LongitudeSF = longitudeSF ?? 1000000.0;
    public double LatitudeSF = latitudeSF ?? 1000000.0;

    // These are best-guesses based on the max-value of an `int32` and the required max-values for longitude and latitude.
}

public class Landmark
{
    public LandmarkData Data { get; }
    public LandmarkConfig Config;

    public ushort LandmarkNumber
    {
        get => Data.LandmarkNumber;
        set => Data.LandmarkNumber = value;
    }

    public string Type
    {
        get => Data.Type;
        set => Data.Type = value;
    }

    public int Location
    {
        get => Data.Location;
        set => Data.Location = value;
    }

    public ushort EventNumber
    {
        get => Data.EventNumber;
        set => Data.EventNumber = value;
    }

    public double Longitude
    {
        get => Data.Longitude / Config.LongitudeSF;
        set => Data.Longitude = (int)(value * Config.LongitudeSF);
    }

    public double Latitude
    {
        get => Data.Latitude / Config.LatitudeSF;
        set => Data.Latitude = (int)(value * Config.LatitudeSF);
    }

    public short CorrectionFactor
    {
        get => Data.CorrectionFactor;
        set => Data.CorrectionFactor = value;
    }

    public int SheathMarkerEnteringLandmark
    {
        get => Data.SheathMarkerEnteringLandmark;
        set => Data.SheathMarkerEnteringLandmark = value;
    }

    public int SheathMarkerLeavingLandmark
    {
        get => Data.SheathMarkerLeavingLandmark;
        set => Data.SheathMarkerLeavingLandmark = value;
    }

    public short ModeFieldDiameterLeavingLandmark
    {
        get => Data.ModeFieldDiameterLeavingLandmark;
        set => Data.ModeFieldDiameterLeavingLandmark = value;
    }

    public string Comment
    {
        get => Data.Comment;
        set => Data.Comment = value;
    }

    public Landmark(Span<byte> data, ref int offset, LandmarkConfig? config = null)
    {
        Data = new LandmarkData(data, ref offset);
        Config = config ?? new LandmarkConfig();
    }

    public Landmark(LandmarkData data, LandmarkConfig? config = null)
    {
        Data = data;
        Config = config ?? new LandmarkConfig();
    }
}
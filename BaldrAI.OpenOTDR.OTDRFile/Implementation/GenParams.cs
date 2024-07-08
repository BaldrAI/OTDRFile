namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;


public class GenParamsConfig(double speedOfLightMetresPerNanoSecond = 0.20394044761904762)
{
    public double SpeedOfLightMetresPerNanoSecond = speedOfLightMetresPerNanoSecond; // Through fibre at the given wavelength
}

public class GenParams(Span<byte> data, int format, GenParamsConfig? config = null)
{
    private GenParamsData Data = new(data, format);
    public GenParamsConfig Config = config ?? new GenParamsConfig();

    public string Language
    {
        get => Data.Language;
        set => Data.Language = value;
    }

    public string CableId
    {
        get => Data.CableId;
        set => Data.CableId = value;
    }

    public string FiberId
    {
        get => Data.FiberId;
        set => Data.FiberId = value;
    }

    public ushort FiberType
    {
        get => Data.FiberType;
        set => Data.FiberType = value;
    }
    public ushort Wavelength
    {
        get => Data.Wavelength;
        set => Data.Wavelength = value;
    }

    public string LocationA
    {
        get => Data.LocationA;
        set => Data.LocationA = value;
    }

    public string LocationB
    {
        get => Data.LocationB;
        set => Data.LocationB = value;
    }

    public string CableCode
    {
        get => Data.CableCode;
        set => Data.CableCode = value;
    }

    public string BuildCondition
    {
        get => Data.BuildCondition;
        set => Data.BuildCondition = value;
    }

    public int UserOffset
    {
        get => Data.UserOffset;
        set
        {
            Data.UserOffset = value;
            Data.UserOffsetDistance = (int)Math.Round(value * Config.SpeedOfLightMetresPerNanoSecond);
        }
    }

    public int UserOffsetDistance
    {
        get => Data.UserOffsetDistance;
        set
        {
            Data.UserOffsetDistance = value;
            Data.UserOffset = (int)Math.Round(value / Config.SpeedOfLightMetresPerNanoSecond);
        }
    }

    public string Operator
    {
        get => Data.Operator;
        set => Data.Operator = value;
    }

    public string Comments
    {
        get => Data.Comments;
        set => Data.Comments = value;
    }
}
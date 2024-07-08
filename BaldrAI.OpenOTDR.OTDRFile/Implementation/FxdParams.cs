using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class FxdParamsConfig(
    double wavelengthSf = 10,
    double acquisitionOffsetDistanceSf = 100.0,
    double indexOfRefractionSF = 100000.0,
    double acquisitionRangeDistanceSF = 10.0)
{
    public double WavelengthSF = wavelengthSf;
    public double AcquisitionOffsetDistanceSF = acquisitionOffsetDistanceSf;
    public double AcquisitionRangeDistanceSF = acquisitionRangeDistanceSF;
    public double IndexOfRefractionSF = indexOfRefractionSF;
}

public class FxdParams(Span<byte> data, int format, FxdParamsConfig? config = null)
{
    private FxdParamsData Data = new(data, format);
    public FxdParamsConfig Config = config ?? new FxdParamsConfig();

    public DateTime @DateTime
    {
        get => Data.DateTime;
        set => Data.DateTime = value;
    }

    public string Units
    {
        get => Data.Units;
        set => Data.Units = value;
    }

    public double Wavelength
    {
        get => Data.Wavelength / Config.WavelengthSF;
        set => Data.Wavelength = (ushort)Math.Round(value * Config.WavelengthSF);
    }

    public int AcquisitionOffset
    {
        get => Data.AcquisitionOffset;
        set
        {
            Data.AcquisitionOffset = value;
            Data.AcquisitionOffsetDistance = (int)Math.Round(value / Config.AcquisitionOffsetDistanceSF * (Constants.SpeedOfLightMilliSecs[Units] / IndexOfRefraction));
        }
    }

    public double AcquisitionOffsetDistance
    {
        get => Data.AcquisitionOffsetDistance / Config.AcquisitionOffsetDistanceSF;
        set
        {
            Data.AcquisitionOffsetDistance = (int)(value * Config.AcquisitionOffsetDistanceSF);
            Data.AcquisitionOffset = (int)Math.Round(value * Config.AcquisitionOffsetDistanceSF / (Constants.SpeedOfLightMilliSecs[Units] / IndexOfRefraction));
        }
    }

    public ushort NumberOfTraces
    {
        get => Data.NumberOfTraces;
        set => Data.NumberOfTraces = value;
    }

    public List<ushort> PulseWidth
    {
        get => Data.PulseWidth;
        set => Data.PulseWidth = value;
    }

    public List<uint> SampleSpacing
    {
        get => Data.SampleSpacing;
        set => Data.SampleSpacing = value;
    }

    public List<uint> NumberOfDataPointsInTrace
    {
        get => Data.NumberOfDataPointsInTrace;
        set => Data.NumberOfDataPointsInTrace = value;
    }

    public double IndexOfRefraction
    {
        get => Data.IndexOfRefraction / Config.IndexOfRefractionSF;
        set => Data.IndexOfRefraction = (uint)(value * Config.IndexOfRefractionSF);
    }

    public ushort BackscatteringCoefficient
    {
        get => Data.BackscatteringCoefficient;
        set => Data.BackscatteringCoefficient = value;
    }

    public uint NumberOfAverages
    {
        get => Data.NumberOfAverages;
        set => Data.NumberOfAverages = value;
    }

    public ushort AveragingTime
    {
        get => Data.AveragingTime;
        set => Data.AveragingTime = value;
    }

    public double AcquisitionRange
    {
        get => Data.AcquisitionRange;
        set
        {
            Data.AcquisitionRange = (uint)value;
            Data.AcquisitionRangeDistance = (uint)Math.Round(value * Config.AcquisitionRangeDistanceSF * (Constants.SpeedOfLightMilliSecs["km"] / IndexOfRefraction));
        }
    }

    public double AcquisitionRangeDistance
    {
        get => Data.AcquisitionRangeDistance / Config.AcquisitionRangeDistanceSF;
        set
        {
            Data.AcquisitionRangeDistance = (uint)value;
            Data.AcquisitionRange = (uint)Math.Round(value / Config.AcquisitionRangeDistanceSF / (Constants.SpeedOfLightMilliSecs["km"] / IndexOfRefraction));
        }
    }

    public int FrontPanelOffset
    {
        get => Data.FrontPanelOffset;
        set => Data.FrontPanelOffset = value;
    }

    public ushort NoiseFloorLevel
    {
        get => Data.NoiseFloorLevel;
        set => Data.NoiseFloorLevel = value;
    }

    public short NoiseFloorScalingFactor
    {
        get => Data.NoiseFloorScalingFactor;
        set => Data.NoiseFloorScalingFactor = value;
    }

    public ushort PowerOffsetFirstPoint
    {
        get => Data.PowerOffsetFirstPoint;
        set => Data.PowerOffsetFirstPoint = value;
    }

    public ushort LossThreshold
    {
        get => Data.LossThreshold;
        set => Data.LossThreshold = value;
    }

    public ushort ReflectionThreshold
    {
        get => Data.ReflectionThreshold;
        set => Data.ReflectionThreshold = value;
    }

    public ushort EndOfTransmissionThreshold
    {
        get => Data.EndOfTransmissionThreshold;
        set => Data.EndOfTransmissionThreshold = value;
    }

    public string TraceType
    {
        get => Data.TraceType;
        set => Data.TraceType = value;
    }

    public int X1
    {
        get => Data.X1;
        set => Data.X1 = value;
    }

    public int Y1
    {
        get => Data.Y1;
        set => Data.Y1 = value;
    }

    public int X2
    {
        get => Data.X2;
        set => Data.X2 = value;
    }

    public int Y2
    {
        get => Data.Y2;
        set => Data.Y2 = value;
    }
}
using BaldrAI.OpenOTDR.OTDRFile.DataTypes;
using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;



public class FxdParams(ref OTDRData data)
{
    private FxdParamsData Data = data.FxdParamsRaw;

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
        get => Data.Wavelength / Constants.WavelengthSF;
        set => Data.Wavelength = (ushort)Math.Round(value * Constants.WavelengthSF);
    }

    public int AcquisitionOffset
    {
        get => Data.AcquisitionOffset;
        set
        {
            Data.AcquisitionOffset = value;
            var adjustedSpeedOfLight = Constants.SpeedOfLightMicroSecs[Units] / IndexOfRefraction;
            var distance = value * adjustedSpeedOfLight;
            Data.AcquisitionOffsetDistance = (int)Math.Round(distance);
        }
    }

    public double AcquisitionOffsetDistance
    {
        get => Data.AcquisitionOffsetDistance;
        set
        {
            Data.AcquisitionOffsetDistance = (int)(value);
            Data.AcquisitionOffset = (int)Math.Round(value /
                                                     (Constants.SpeedOfLightMicroSecs[Units] / IndexOfRefraction));
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

    public List<double> SampleSpacing
    {
        get => Data.SampleSpacing.Select(item => item / Constants.SampleSpacingSF).ToList();
        set => Data.SampleSpacing = value.Select(item => (uint)(item * Constants.SampleSpacingSF)).ToList();
    }

    public List<double> Resolution
    {
        get
        {
            var adjustedSpeedOfLight = Constants.SpeedOfLightMicroSecs["km"] / IndexOfRefraction;
            return Data.SampleSpacing.Select(item => (item / Constants.SampleSpacingSF)*adjustedSpeedOfLight).ToList();
        }
    }

    public List<uint> NumberOfDataPointsInTrace
    {
        get => Data.NumberOfDataPointsInTrace;
        set => Data.NumberOfDataPointsInTrace = value;
    }

    public double IndexOfRefraction
    {
        get => Data.IndexOfRefraction / Constants.IndexOfRefractionSF;
        set => Data.IndexOfRefraction = (uint)(value * Constants.IndexOfRefractionSF);
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
        get => Data.AcquisitionRange / Constants.AcquisitionRangeSF;
        set
        {
            Data.AcquisitionRange = (uint)Math.Round(value / Constants.AcquisitionRangeSF);
            var adjustedSpeedOfLight = Constants.SpeedOfLightMicroSecs[Units] / IndexOfRefraction;
            var distance = value * adjustedSpeedOfLight;
            Data.AcquisitionRangeDistance = (uint)Math.Round(distance);
        }
    }

    public double AcquisitionRangeDistance
    {
        get => Data.AcquisitionRangeDistance;
        set
        {
            Data.AcquisitionRangeDistance = (uint)value;
            var adjustedSpeedOfLight = Constants.SpeedOfLightMicroSecs[Units] / IndexOfRefraction;
            var microseconds = value / adjustedSpeedOfLight;
            Data.AcquisitionRange = (uint)Math.Round(microseconds * Constants.AcquisitionRangeSF);
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
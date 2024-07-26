using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile;

public class FxdParamsData
{
    public DateTime @DateTime { get; set; }
    public string Units { get; set; }
    public ushort Wavelength { get; set; }
    public int AcquisitionOffset { get; set; }
    public int AcquisitionOffsetDistance { get; set; }
    public ushort NumberOfTraces { get; set; }
    public List<ushort> PulseWidth { get; set; }
    public List<uint> SampleSpacing { get; set; }
    public List<uint> NumberOfDataPointsInTrace { get; set; }
    public uint IndexOfRefraction { get; set; }
    public ushort BackscatteringCoefficient { get; set; }
    public uint NumberOfAverages { get; set; }
    public ushort AveragingTime { get; set; }
    public uint AcquisitionRange { get; set; }
    public uint AcquisitionRangeDistance { get; set; }
    public int FrontPanelOffset { get; set; }
    public ushort NoiseFloorLevel { get; set; }
    public short NoiseFloorScalingFactor { get; set; }
    public ushort PowerOffsetFirstPoint { get; set; }
    public ushort LossThreshold { get; set; }
    public ushort ReflectionThreshold { get; set; }
    public ushort EndOfTransmissionThreshold { get; set; }
    public string TraceType { get; set; }
    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get; set; }
    public int Y2 { get; set; }


    public FxdParamsData(DateTime dateTime, string units, ushort wavelength, int acquisitionOffset,
        int acquisitionOffsetDistance, ushort numberOfTraces, List<ushort> pulseWidth, List<uint> sampleSpacing,
        List<uint> numberOfDataPointsInTrace, uint indexOfRefraction, ushort backscatteringCoefficient,
        uint numberOfAverages, ushort averagingTime, uint acquisitionRange, uint acquisitionRangeDistance,
        int frontPanelOffset, ushort noiseFloorLevel, short noiseFloorScalingFactor, ushort powerOffsetFirstPoint,
        ushort lossThreshold, ushort reflectionThreshold, ushort endOfTransmissionThreshold, string traceType, int x1,
        int y1, int x2, int y2)
    {
        @DateTime = dateTime;
        Units = units;
        Wavelength = wavelength;
        AcquisitionOffset = acquisitionOffset;
        AcquisitionOffsetDistance = acquisitionOffsetDistance;
        NumberOfTraces = numberOfTraces;
        PulseWidth = pulseWidth;
        SampleSpacing = sampleSpacing;
        NumberOfDataPointsInTrace = numberOfDataPointsInTrace;
        IndexOfRefraction = indexOfRefraction;
        BackscatteringCoefficient = backscatteringCoefficient;
        NumberOfAverages = numberOfAverages;
        AveragingTime = averagingTime;
        AcquisitionRange = acquisitionRange;
        AcquisitionRangeDistance = acquisitionRangeDistance;
        FrontPanelOffset = frontPanelOffset;
        NoiseFloorLevel = noiseFloorLevel;
        NoiseFloorScalingFactor = noiseFloorScalingFactor;
        PowerOffsetFirstPoint = powerOffsetFirstPoint;
        LossThreshold = lossThreshold;
        ReflectionThreshold = reflectionThreshold;
        EndOfTransmissionThreshold = endOfTransmissionThreshold;
        TraceType = traceType;
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }

    public FxdParamsData(Span<byte> data, int format)
    {
        var offset = format switch
        {
            1 => 0,
            2 => data.IndexOf((byte)0) + 1
        };
        @DateTime = data.ReadUIntDateTime(ref offset);
        Units = data.ReadFixedLengthString(ref offset, 2);
        Wavelength = data.ReadUShort(ref offset);
        AcquisitionOffset = data.ReadInt(ref offset);
        AcquisitionOffsetDistance = format switch
        {
            1 => 0,
            2 => data.ReadInt(ref offset)
        };
        NumberOfTraces = data.ReadUShort(ref offset);
        PulseWidth = new List<ushort>();
        SampleSpacing = new List<uint>();
        NumberOfDataPointsInTrace = new List<uint>();
        for (var i = 0; i < NumberOfTraces; i++)
        {
            PulseWidth.Add(data.ReadUShort(ref offset));
            SampleSpacing.Add(data.ReadUInt(ref offset));
            NumberOfDataPointsInTrace.Add(data.ReadUInt(ref offset));
        }

        IndexOfRefraction = data.ReadUInt(ref offset);
        BackscatteringCoefficient = data.ReadUShort(ref offset);
        NumberOfAverages = data.ReadUInt(ref offset);
        AveragingTime = format switch
        {
            1 => 0,
            2 => data.ReadUShort(ref offset)
        };
        AcquisitionRange = data.ReadUInt(ref offset);
        AcquisitionRangeDistance = format switch
        {
            1 => 0,
            2 => data.ReadUInt(ref offset)
        };
        FrontPanelOffset = data.ReadInt(ref offset);
        NoiseFloorLevel = data.ReadUShort(ref offset);
        NoiseFloorScalingFactor = data.ReadShort(ref offset);
        PowerOffsetFirstPoint = data.ReadUShort(ref offset);
        LossThreshold = data.ReadUShort(ref offset);
        ReflectionThreshold = data.ReadUShort(ref offset);
        EndOfTransmissionThreshold = data.ReadUShort(ref offset);
        switch (format)
        {
            case 1:
                TraceType = "ST";
                X1 = 0;
                Y1 = 0;
                X2 = 0;
                Y2 = 0;
                break;
            case 2:
                TraceType = data.ReadFixedLengthString(ref offset, 2);
                X1 = data.ReadInt(ref offset);
                Y1 = data.ReadInt(ref offset);
                X2 = data.ReadInt(ref offset);
                Y2 = data.ReadInt(ref offset);
                break;
        }
    }
}
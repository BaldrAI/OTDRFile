using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile;

public class TraceData
{
    public uint NumberOfDataPoints;
    public ushort ScalingFactor;
    public List<ushort> DataPoints;

    public TraceData(Span<byte> data, ref int offset)
    {
        NumberOfDataPoints = data.ReadUInt(ref offset);
        ScalingFactor = data.ReadUShort(ref offset);
        DataPoints = new();
        for (uint i = 0; i < NumberOfDataPoints; i++)
        {
            DataPoints.Add(data.ReadUShort(ref offset));
        }
    }
}
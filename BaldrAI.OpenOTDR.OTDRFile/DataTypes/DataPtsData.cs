using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile;

public class DataPtsData
{
    public uint NumberOfDataPoints;
    public ushort NumberOfTraces;
    public List<TraceData> Traces;

    public DataPtsData(Span<byte> data, int format)
    {
        var offset = 0;
        switch (format)
        {
            case 1:
                break;
            case 2:
                offset += data.IndexOf((byte)0) + 1;
                break;
            default:
                throw new ArgumentException("unrecognised filetype");
        }

        NumberOfDataPoints = data.ReadUInt(ref offset);
        NumberOfTraces = data.ReadUShort(ref offset);
        Traces = new List<TraceData>();
        for (ushort i = 0; i < NumberOfTraces; i++) Traces.Add(new TraceData(data, ref offset));
    }
}
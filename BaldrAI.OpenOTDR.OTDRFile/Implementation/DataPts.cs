using BaldrAI.OpenOTDR.OTDRFile.DataTypes;
using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class DataPts(ref OTDRData data)
{
    public TraceList Traces = new(ref data.DataPtsRaw.Traces);

    public uint NumberOfDataPoints
    {
        get
        {
            uint num = 0;
            foreach (var trace in Traces) num += trace.NumberOfDataPoints;

            return num;
        }
    }

    public ushort NumberOfTraces => (ushort)Traces.Count;
}
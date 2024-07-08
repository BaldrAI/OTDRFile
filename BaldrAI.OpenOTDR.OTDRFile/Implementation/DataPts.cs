using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class DataPtsConfig(double? decibelsSF = null)
{
    public double DecibelsSF = decibelsSF ?? 0.001;
}

public class DataPts(Span<byte> data, int format, DataPtsConfig? config = null)
{

    public DataPtsData Data = new(data, format);
    private DataPtsConfig Config = config ?? new DataPtsConfig();

    public uint NumberOfDataPoints
    {
        get
        {
            uint num = 0;
            foreach (var trace in Data.Traces)
            {
                num += trace.NumberOfDataPoints;
            }

            return num;
        }
    }

    public ushort NumberOfTraces
    {
        get => (ushort)Data.Traces.Count;
    }

    public TraceList Traces => new(Data.Traces);
}
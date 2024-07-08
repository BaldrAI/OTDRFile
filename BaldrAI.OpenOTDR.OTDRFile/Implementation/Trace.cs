using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;


public class TraceConfig(double? decibelsSF = null)
{
    public double DecibelsSF = decibelsSF ?? 0.001;
}


public class Trace
{
    public TraceData Data;
    private TraceConfig Config;
    public uint NumberOfDataPoints => (uint)Data.DataPoints.Count;
    public double ScalingFactor 
    {
        get => 1.0/Data.ScalingFactor;
        set => Data.ScalingFactor = (ushort)(1/value);
    }
    public DataPointList DataPoints => new(Data.DataPoints, Config);

    public Trace(TraceData data, TraceConfig? config = null)
    {
        Config = config ?? new TraceConfig(ScalingFactor);
        Data = data;
    }
}
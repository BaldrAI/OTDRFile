using BaldrAI.OpenOTDR.OTDRFile.DataTypes;
using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class KeyEventsConfig(double speedOfLightMetresPerNanoSecond = 0.20394044761904762, double decibelsSF = 0.001)
{
    public double SpeedOfLightMetresPerNanoSecond = speedOfLightMetresPerNanoSecond; // Through fibre at the given wavelength
    public double DecibelsSF = decibelsSF;
}

public class KeyEvents(ref OTDRData data)
{
    private KeyEventsData Data = data.KeyEventsRaw;
    private KeyEventsConfig Config = new();

    public ushort NumberOfEvents => (ushort)Data.Events.Count;
    public KeyEventList Events => new(Data.Events);
    public double EndToEndLoss
    {
        get => Data.EndToEndLoss * Config.DecibelsSF;
        set => Data.EndToEndLoss = (int)Math.Round(value / Config.DecibelsSF);
    }
    public int EndToEndLossMarker1
    {
        get => Data.EndToEndLossMarker1;
        set => Data.EndToEndLossMarker1 = value;
    }
    public int EndToEndLossMarker2
    {
        get => Data.EndToEndLossMarker2;
        set => Data.EndToEndLossMarker2 = value;
    }
    public double OpticalReturnLoss
    {
        get => Data.OpticalReturnLoss * Config.DecibelsSF;
        set => Data.OpticalReturnLoss = (ushort)Math.Round(value / Config.DecibelsSF);
    }
    public int OpticalReturnLossMarker1
    {
        get => Data.OpticalReturnLossMarker1;
        set => Data.OpticalReturnLossMarker1 = value;
    }
    public int OpticalReturnLossMarker2
    {
        get => Data.OpticalReturnLossMarker2;
        set => Data.OpticalReturnLossMarker2 = value;
    }
}
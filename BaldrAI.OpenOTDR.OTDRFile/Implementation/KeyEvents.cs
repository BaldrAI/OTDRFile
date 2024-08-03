using System.Reflection.Metadata;
using BaldrAI.OpenOTDR.OTDRFile.DataTypes;
using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;


public class KeyEvents(ref OTDRData data, OTDRFile parent)
{
    private OTDRFile Parent = parent;
    private KeyEventsData Data = data.KeyEventsRaw;

    public ushort NumberOfEvents => (ushort)Data.Events.Count;
    public KeyEventList Events => new(Data.Events, Parent);

    public double EndToEndLoss
    {
        get => Data.EndToEndLoss / Constants.DecibelsSF;
        set => Data.EndToEndLoss = (int)Math.Round(value * Constants.DecibelsSF);
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
        get => Data.OpticalReturnLoss / Constants.DecibelsSF;
        set => Data.OpticalReturnLoss = (ushort)Math.Round(value * Constants.DecibelsSF);
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
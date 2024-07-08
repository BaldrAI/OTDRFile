using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile;

public class KeyEventsData
{
    public ushort NumberOfEvents;
    public List<KeyEventData> Events;
    public int EndToEndLoss;
    public int EndToEndLossMarker1;
    public int EndToEndLossMarker2;
    public ushort OpticalReturnLoss;
    public int OpticalReturnLossMarker1;
    public int OpticalReturnLossMarker2;


    public KeyEventsData(ushort numberOfEvents, List<KeyEventData> events, int endToEndLoss, int endToEndLossMarker1, int endToEndLossMarker2, ushort opticalReturnLoss, int opticalReturnLossMarker1, int opticalReturnLossMarker2)
    {
        NumberOfEvents = numberOfEvents;
        Events = events;
        EndToEndLoss = endToEndLoss;
        EndToEndLossMarker1 = endToEndLossMarker1;
        EndToEndLossMarker2 = endToEndLossMarker2;
        OpticalReturnLoss = opticalReturnLoss;
        OpticalReturnLossMarker1 = opticalReturnLossMarker1;
        OpticalReturnLossMarker2 = opticalReturnLossMarker2;
    }

    public KeyEventsData(Span<byte> data, int format)
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
        NumberOfEvents = data.ReadUShort(ref offset);
        Events = new List<KeyEventData>();
        for (ushort i = 0; i < NumberOfEvents; i++)
        {
            Events.Add(new KeyEventData(data, ref offset, format));
        }
        EndToEndLoss = data.ReadInt(ref offset);
        EndToEndLossMarker1 = data.ReadInt(ref offset);
        EndToEndLossMarker2 = data.ReadInt(ref offset);
        OpticalReturnLoss = data.ReadUShort(ref offset);
        OpticalReturnLossMarker1 = data.ReadInt(ref offset);
        OpticalReturnLossMarker2 = data.ReadInt(ref offset);
    }
}


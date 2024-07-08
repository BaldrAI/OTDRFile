using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class LocParams(Span<byte> data, int format)
{
    private LocParamsData Data = new(data, format);

    public LocationList Locations => new(Data.Locations);
}
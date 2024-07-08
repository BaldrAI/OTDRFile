using BaldrAI.OpenOTDR.OTDRFile.DataTypes;
using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class LocParams(ref OTDRData data)
{
    private LocParamsData Data = data.LocParamsRaw;

    public LocationList Locations => new(Data.Locations);
}
using BaldrAI.OpenOTDR.OTDRFile.DataTypes;
using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class LnkParams(ref OTDRData data)
{
    /*
     * This is a blind adaption from https://github.com/JamesHarrison/otdrs
     */
    private LnkParamsData Data = data.LnkParamsRaw;

    public LandmarkList Landmarks => new(Data.Landmarks);
}
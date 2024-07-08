using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class LnkParams(Span<byte> data, int format)
{
    /*
     * This is a blind adaption from https://github.com/JamesHarrison/otdrs
     */
    private LnkParamsData Data = new(data, format);

    public LandmarkList Landmarks => new(Data.Landmarks);
}
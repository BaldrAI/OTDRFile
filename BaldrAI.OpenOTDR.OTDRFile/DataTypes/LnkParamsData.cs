namespace BaldrAI.OpenOTDR.OTDRFile;

public class LnkParamsData
{
    /*
     * This is a blind adaption from https://github.com/JamesHarrison/otdrs
     */
    public ushort NumberOfLandmarks { get; set; }
    public List<LandmarkData> Landmarks { get; set; }

    public LnkParamsData(Span<byte> data, int format)
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

        for (ushort i = 0; i < NumberOfLandmarks; i++)
        {
            Landmarks.Add(new LandmarkData(data, ref offset));
        }

    }
}


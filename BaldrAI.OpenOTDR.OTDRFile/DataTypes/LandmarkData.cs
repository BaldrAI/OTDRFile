using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile;

public class LandmarkData
{
    /*
     * This is a blind adaption from https://github.com/JamesHarrison/otdrs
     */

    public ushort LandmarkNumber;
    public string Type;
    public int Location;
    public ushort EventNumber;
    public int Longitude;
    public int Latitude;
    public short CorrectionFactor;
    public int SheathMarkerEnteringLandmark;
    public int SheathMarkerLeavingLandmark;
    public short ModeFieldDiameterLeavingLandmark;
    public string Comment;

    public LandmarkData(Span<byte> data, ref int offset)
    {
        LandmarkNumber = data.ReadUShort(ref offset);
        Type = data.ReadFixedLengthString(ref offset, 2);
        Location = data.ReadInt(ref offset);
        EventNumber = data.ReadUShort(ref offset);
        Longitude = data.ReadInt(ref offset);
        Latitude = data.ReadInt(ref offset);
        CorrectionFactor = data.ReadShort(ref offset);
        SheathMarkerEnteringLandmark = data.ReadInt(ref offset);
        SheathMarkerLeavingLandmark = data.ReadInt(ref offset);
        ModeFieldDiameterLeavingLandmark = data.ReadShort(ref offset);
        Comment = data.ReadTerminatedString(ref offset);
    }
}
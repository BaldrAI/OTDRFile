using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile;

public class GenParamsData
{
    public string Language;
    public string CableId;
    public string FiberId;
    public ushort FiberType;
    public ushort Wavelength;
    public string LocationA;
    public string LocationB;
    public string CableCode;
    public string BuildCondition;
    public int UserOffset;
    public int UserOffsetDistance;
    public string Operator;
    public string Comments;

    public GenParamsData(string language = "EN", string cableID = "C/001", string fiberID = "F/001",
        ushort fiberType = 657, ushort wavelength = 1550, string locationA = "A", string locationB = "B",
        string cableCode = "ITU-T G.657", string buildCondition = "BC", int userOffset = 0, int userOffsetDistance = 0,
        string @operator = "User1", string comments = "No Comments")
    {
        Language = language;
        CableId = cableID;
        FiberId = fiberID;
        FiberType = fiberType;
        Wavelength = wavelength;
        LocationA = locationA;
        LocationB = locationB;
        CableCode = cableCode;
        BuildCondition = buildCondition;
        UserOffset = userOffset;
        UserOffsetDistance = userOffsetDistance;
        Operator = @operator;
        Comments = comments;
    }

    public GenParamsData(Span<byte> data, int format)
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

        Language = data.ReadFixedLengthString(ref offset, 2);
        CableId = data.ReadTerminatedString(ref offset).Trim();
        FiberId = data.ReadTerminatedString(ref offset).Trim();
        FiberType = data.ReadUShort(ref offset);
        Wavelength = data.ReadUShort(ref offset);
        LocationA = data.ReadTerminatedString(ref offset).Trim();
        LocationB = data.ReadTerminatedString(ref offset).Trim();
        CableCode = data.ReadTerminatedString(ref offset).Trim();
        BuildCondition = data.ReadFixedLengthString(ref offset, 2);
        UserOffset = data.ReadInt(ref offset);
        UserOffsetDistance = data.ReadInt(ref offset);
        Operator = data.ReadTerminatedString(ref offset).Trim();
        Comments = data.ReadTerminatedString(ref offset).Trim();
    }
}
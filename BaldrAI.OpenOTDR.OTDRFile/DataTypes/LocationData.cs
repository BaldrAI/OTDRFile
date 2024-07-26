using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile;

public class LocationData
{
    public string LocationNumber;
    public uint LocationDistance;
    public short LocationDrift;
    public ushort EventNumber;
    public int Longitude;
    public int Latitude;
    public uint IdealLeadLoss;
    public string CableIDEnteringLocation;
    public string FiberIDEnteringLocation;
    public string CableIDExitingLocation;
    public string FiberIDExitingLocation;
    public string Comment;

    public LocationData(Span<byte> data, ref int offset)
    {
        LocationNumber = data.ReadFixedLengthString(ref offset, 4);
        LocationDistance = data.ReadUInt(ref offset);
        LocationDrift = data.ReadShort(ref offset);
        EventNumber = data.ReadUShort(ref offset);
        Longitude = data.ReadInt(ref offset);
        Latitude = data.ReadInt(ref offset);
        IdealLeadLoss = data.ReadUInt(ref offset);
        CableIDEnteringLocation = data.ReadTerminatedString(ref offset);
        FiberIDEnteringLocation = data.ReadTerminatedString(ref offset);
        CableIDExitingLocation = data.ReadTerminatedString(ref offset);
        FiberIDExitingLocation = data.ReadTerminatedString(ref offset);
        Comment = data.ReadTerminatedString(ref offset);
    }
}
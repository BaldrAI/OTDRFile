namespace BaldrAI.OpenOTDR.OTDRFile;

public class LocParamsData
{
    public ushort NumberOfLocations { get; set; }
    public List<LocationData> Locations { get; set; }

    public LocParamsData(Span<byte> data, int format)
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

        for (ushort i = 0; i < NumberOfLocations; i++) Locations.Add(new LocationData(data, ref offset));
    }
}
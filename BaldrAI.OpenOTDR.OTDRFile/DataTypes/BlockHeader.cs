using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.DataTypes;

internal class BlockHeader
{
    public string Name { get; }
    public double Version { get; }
    public int Offset { get; }
    public int Length { get; }
    public int HeaderLength { get; }
    public BlockHeader(Span<byte> data, int offset)
    {
        var innerOffset = 0;
        Name = data.ReadTerminatedString(ref innerOffset).Trim();
        Version = data.ReadUShort(ref innerOffset) / 100.0;
        Offset = offset;
        Length = (int)data.ReadUInt(ref innerOffset);
        HeaderLength = Name.Length + 7;
    }
}

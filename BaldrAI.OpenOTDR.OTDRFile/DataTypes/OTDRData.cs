using BaldrAI.OpenOTDR.OTDRFile.Implementation;
using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.DataTypes;

public class OTDRData
{
    public double Version;
    public GenParamsData GenParamsRaw;
    public SupParamsData SupParamsRaw;
    public FxdParamsData FxdParamsRaw;
    public KeyEventsData KeyEventsRaw;
    public LnkParamsData LnkParamsRaw;
    public LocParamsData LocParamsRaw;
    public DataPtsData DataPtsRaw;

    public OTDRData(byte[] data)
    {
        var span = data.AsSpan();
        int format;
        int offset;
        if (span[..4].SequenceEqual("Map\0"u8))
        {
            format = 2;
            offset = 4;
        }
        else
        {
            format = 1;
            offset = 0;
        }

        Version = span.ReadUShort(ref offset) / 100.0;
        int nextBlockOffset = (int)span.ReadUInt(ref offset);
        var numBlocks = span.ReadUShort(ref offset);
        var nextBlockInfoStart = offset;
        Dictionary<string, BlockHeader> blockHeaders = new();
        for (var i = 1; i < numBlocks; i++)
        {
            BlockHeader blockRef = new(span[nextBlockInfoStart..], nextBlockOffset);
            blockHeaders.Add(blockRef.Name, blockRef);
            nextBlockInfoStart += blockRef.HeaderLength;
            nextBlockOffset += blockRef.Length;
        }

        foreach (var kvp in blockHeaders)
        {
            switch (kvp.Key)
            {
                case "GenParams":
                    GenParamsRaw = new GenParamsData(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                    break;
                case "SupParams":
                    SupParamsRaw = new SupParamsData(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                    break;
                case "FxdParams":
                    FxdParamsRaw = new FxdParamsData(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                    break;
                case "KeyEvents":
                    KeyEventsRaw = new KeyEventsData(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                    break;
                case "LnkParams":
                    LnkParamsRaw = new LnkParamsData(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                    break;
                case "LocParams":
                    LocParamsRaw = new LocParamsData(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                    break;
                case "DataPts":
                    DataPtsRaw = new DataPtsData(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                    break;
            }
        }
    }
}


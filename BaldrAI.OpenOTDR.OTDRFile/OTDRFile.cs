
using BaldrAI.OpenOTDR.OTDRFile.DataTypes;
using BaldrAI.OpenOTDR.OTDRFile.Implementation;
using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile
{
    // All the code in this file is included in all platforms.
    public class OTDRFile
    {
        public double Version { get; }

        public GenParams GenParams;
        public SupParams SupParams;
        public FxdParams FxdParams;
        public KeyEvents KeyEvents;
        public LnkParams LnkParams;
        public LocParams LocParams;
        public DataPts DataPts;

        public OTDRFile(byte[] data)
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

            foreach (var kvp in blockHeaders) {
                switch (kvp.Key)
                {
                    case "GenParams":
                        GenParams = new GenParams(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                        break;
                    case "SupParams":
                        SupParams = new SupParams(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                        break;
                    case "FxdParams":
                        FxdParams = new FxdParams(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                        break;
                    case "KeyEvents":
                        KeyEvents = new KeyEvents(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                        break;
                    case "LnkParams":
                        LnkParams = new LnkParams(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                        break;
                    case "LocParams":
                        LocParams = new LocParams(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                        break;
                    case "DataPts":
                        DataPts = new DataPts(span[(kvp.Value.Offset)..(kvp.Value.Offset + kvp.Value.Length)], format);
                        break;
                }
            }
        }
    }
}

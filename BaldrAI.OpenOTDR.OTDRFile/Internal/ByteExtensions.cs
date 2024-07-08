using System.Buffers.Binary;
using System.Text;


namespace BaldrAI.OpenOTDR.OTDRFile.Internal;

public static class ByteExtensions
{
    public static ushort ReadUShort(this Span<byte> data, ref int offset)
    {
        offset += 2;
        return BinaryPrimitives.ReadUInt16LittleEndian(data[(offset - 2)..offset]);
    }
    public static short ReadShort(this Span<byte> data, ref int offset)
    {
        offset += 2;
        return BinaryPrimitives.ReadInt16LittleEndian(data[(offset - 2)..offset]);
    }

    public static uint ReadUInt(this Span<byte> data, ref int offset)
    {
        offset += 4;
        return BinaryPrimitives.ReadUInt32LittleEndian(data[(offset - 4)..offset]);
    }

    public static DateTime ReadUIntDateTime(this Span<byte> data, ref int offset)
    {
        var timestamp = data.ReadUInt(ref offset);
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return epoch.AddSeconds(timestamp);
    }

    public static int ReadInt(this Span<byte> data, ref int offset)
    {
        offset += 4;
        return BinaryPrimitives.ReadInt32LittleEndian(data[(offset - 4)..offset]);
    }

    public static string ReadFixedLengthString(this Span<byte> data, ref int offset, int length)
    {
        offset += length;
        return Encoding.UTF8.GetString(data[(offset - length)..offset]);
    }

    public static string ReadTerminatedString(this Span<byte> data, ref int offset)
    {
        var length = data[offset..].IndexOf((byte)0) + 1;
        offset += length;
        return Encoding.UTF8.GetString(data[(offset - length)..(offset - 1)]);
    }

    public static Span<byte> TakeString(this Span<byte> data, out string str, int length)
    {
        str = Encoding.UTF8.GetString(data[..length]);
        return data[length..];
    }
    public static Span<byte> TakeString(this Span<byte> data, out string str)
    {
        var index = data.IndexOf((byte)0);
        str = Encoding.UTF8.GetString(data[..index]);
        return data[(index + 1)..];
    }

    public static Span<byte> TakeUInt(this Span<byte> data, out uint value)
    {
        int offset = 0;
        value = data.ReadUInt(ref offset);
        return data[4..];
    }

    public static Span<byte> TakeInt(this Span<byte> data, out int value)
    {
        int offset = 0;
        value = data.ReadInt(ref offset);
        return data[4..];
    }

    public static Span<byte> TakeUShort(this Span<byte> data, out ushort value)
    {
        int offset = 0;
        value = data.ReadUShort(ref offset);
        return data[2..];
    }

    public static Span<byte> TakeShort(this Span<byte> data, out short value)
    {
        int offset = 0;
        value = data.ReadShort(ref offset);
        return data[2..];
    }

    public static Span<byte> TakeUnixTimestamp(this Span<byte> data, out DateTimeOffset timestamp)
    {
        int offset = 0;
        var unixTimestamp = data.ReadUInt(ref offset);
        timestamp = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
        return data[4..];
    }

}

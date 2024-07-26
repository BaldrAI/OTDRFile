using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile;

public class KeyEventData
{
    public ushort EventNumber;
    public uint TimeOfTravel;
    public short Slope;
    public short Loss;
    public int Reflection;
    public string ReflectionType;
    public string Type;
    public string LandmarkNumber;
    public string LossMeasurementTechnique;
    public uint Location1;
    public uint Location2;
    public uint Location3;
    public uint Location4;
    public uint Location5;
    public string Comment;

    public KeyEventData(ushort eventNumber, uint timeOfTravel, short slope, short loss, int reflection,
        string reflectionType, string type, string landmarkNumber, string lossMeasurementTechnique, uint location1,
        uint location2, uint location3, uint location4, uint location5, string comment)
    {
        EventNumber = eventNumber;
        TimeOfTravel = timeOfTravel;
        Slope = slope;
        Loss = loss;
        Reflection = reflection;
        ReflectionType = reflectionType;
        Type = type;
        LandmarkNumber = landmarkNumber;
        LossMeasurementTechnique = lossMeasurementTechnique;
        Location1 = location1;
        Location2 = location2;
        Location3 = location3;
        Location4 = location4;
        Location5 = location5;
        Comment = comment;
    }

    public KeyEventData(Span<byte> data, ref int offset, int format)
    {
        EventNumber = data.ReadUShort(ref offset);
        TimeOfTravel = data.ReadUInt(ref offset);
        Slope = data.ReadShort(ref offset);
        Loss = data.ReadShort(ref offset);
        Reflection = data.ReadInt(ref offset);
        ReflectionType = data.ReadFixedLengthString(ref offset, 1);
        Type = data.ReadFixedLengthString(ref offset, 1);
        LandmarkNumber = data.ReadFixedLengthString(ref offset, 4);
        LossMeasurementTechnique = data.ReadFixedLengthString(ref offset, 2);
        if (format > 1)
        {
            Location1 = data.ReadUInt(ref offset);
            Location2 = data.ReadUInt(ref offset);
            Location3 = data.ReadUInt(ref offset);
            Location4 = data.ReadUInt(ref offset);
            Location5 = data.ReadUInt(ref offset);
        }
        else
        {
            Location1 = 0;
            Location2 = 0;
            Location3 = 0;
            Location4 = 0;
            Location5 = 0;
        }

        Comment = data.ReadTerminatedString(ref offset);
    }

    public override bool Equals(object o)
    {
        if (o is not KeyEventData comp)
            return false;
        if (comp.EventNumber != EventNumber)
            return false;
        if (comp.TimeOfTravel != TimeOfTravel)
            return false;
        if (comp.Slope != Slope)
            return false;
        if (comp.Loss != Loss)
            return false;
        if (comp.Reflection != Reflection)
            return false;
        if (comp.ReflectionType != ReflectionType)
            return false;
        if (comp.Type != Type)
            return false;
        if (comp.LandmarkNumber != LandmarkNumber)
            return false;
        if (comp.LossMeasurementTechnique != LossMeasurementTechnique)
            return false;
        if (comp.Location1 != Location1)
            return false;
        if (comp.Location2 != Location2)
            return false;
        if (comp.Location3 != Location3)
            return false;
        if (comp.Location4 != Location4)
            return false;
        if (comp.Location5 != Location5)
            return false;
        if (comp.Comment != Comment)
            return false;
        return true;
    }
}
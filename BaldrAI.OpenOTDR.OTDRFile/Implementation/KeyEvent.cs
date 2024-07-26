namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class KeyEventConfig(double speedOfLightMetresPerNanoSecond = 0.20394044761904762, double decibelsSF = 0.001)
{
    public double
        SpeedOfLightMetresPerNanoSecond = speedOfLightMetresPerNanoSecond; // Through fibre at the given wavelength

    public double DecibelsSF = decibelsSF;
}

public class KeyEvent
{
    public KeyEventData Data { get; }
    public KeyEventConfig Config;

    public ushort EventNumber
    {
        get => Data.EventNumber;
        set => Data.EventNumber = value;
    }

    public uint TimeOfTravel
    {
        get => Data.TimeOfTravel;
        set => Data.TimeOfTravel = value;
    }

    public double Distance
    {
        get => Data.TimeOfTravel * Config.SpeedOfLightMetresPerNanoSecond;
        set => Data.TimeOfTravel = (uint)Math.Round(value / Config.SpeedOfLightMetresPerNanoSecond);
    }

    public double Slope
    {
        get => Data.Slope * Config.DecibelsSF;
        set => Data.Slope = (short)Math.Round(value / Config.DecibelsSF);
    }

    public double Loss
    {
        get => Data.Loss * Config.DecibelsSF;
        set => Data.Loss = (short)Math.Round(value / Config.DecibelsSF);
    }

    public double Reflection
    {
        get => Data.Reflection * Config.DecibelsSF;
        set => Data.Reflection = (short)Math.Round(value / Config.DecibelsSF);
    }

    public string ReflectionType
    {
        get => Data.ReflectionType;
        set => Data.ReflectionType = value;
    }

    public string Type
    {
        get => Data.Type;
        set => Data.Type = value;
    }

    public string LandmarkNumber
    {
        get => Data.LandmarkNumber;
        set => Data.LandmarkNumber = value;
    }

    public string LossMeasurementTechnique
    {
        get => Data.LossMeasurementTechnique;
        set => Data.LossMeasurementTechnique = value;
    }

    public double Location1
    {
        get => Data.Location1;
        set => Data.Location1 = (uint)value;
    }

    public double Location2
    {
        get => Data.Location2;
        set => Data.Location2 = (uint)value;
    }

    public double Location3
    {
        get => Data.Location3;
        set => Data.Location3 = (uint)value;
    }

    public double Location4
    {
        get => Data.Location4;
        set => Data.Location4 = (uint)value;
    }

    public double Location5
    {
        get => Data.Location5;
        set => Data.Location5 = (uint)value;
    }

    public string Comment
    {
        get => Data.Comment;
        set => Data.Comment = value;
    }

    public KeyEvent(KeyEventData data, KeyEventConfig? config = null)
    {
        Config = config ?? new KeyEventConfig();
        Data = data;
    }

    public KeyEvent(Span<byte> rawData, ref int offset, int format, KeyEventConfig? config = null)
    {
        Config = config ?? new KeyEventConfig();
        Data = new KeyEventData(rawData, ref offset, format);
    }
}
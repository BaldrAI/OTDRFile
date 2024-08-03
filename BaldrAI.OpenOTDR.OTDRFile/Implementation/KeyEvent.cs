using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;


public class KeyEvent
{
    private OTDRFile Parent;
    public KeyEventData Data { get; }

    private static readonly Dictionary<string, string> _reflectionTypes = new()
    {
        {"0", "Non-Reflective"},
        {"1", "Reflective"},
        {"2", "Saturated"},
    };

    private static readonly Dictionary<string, string> _eventTypes = new()
    {
        {"A", "Added by user"},
        {"M", "Modified by user"},
        {"E", "End of fiber"},
        {"F", "Found by software"},
        {"O", "Out of range"},
        {"D", "Modified end of fiber"},
    };

    private static readonly Dictionary<string, string> _lossTechniques = new()
    {
        {"LS", "Least-Square"},
        {"2P", "Two-Point"},
    };

    public ushort EventNumber
    {
        get => Data.EventNumber;
        set => Data.EventNumber = value;
    }

    public double TimeOfTravel
    {
        get => Data.TimeOfTravel / Constants.TimeOfTravelSF;
        set => Data.TimeOfTravel = (uint)(value * Constants.TimeOfTravelSF);
    }

    public double Distance
    {
        get
        {
            var adjustedSpeedOfLight = Constants.SpeedOfLightMicroSecs[Parent.FxdParams.Units] / Parent.FxdParams.IndexOfRefraction;
            var distance = TimeOfTravel * adjustedSpeedOfLight;
            return distance;
        }
        set
        {
            var adjustedSpeedOfLight = Constants.SpeedOfLightMicroSecs[Parent.FxdParams.Units] / Parent.FxdParams.IndexOfRefraction;
            TimeOfTravel = (uint)Math.Round(value / adjustedSpeedOfLight);
        }
    }

    public double DistanceMeters
    {
        get
        {
            var adjustedSpeedOfLight = Constants.SpeedOfLightMicroSecs[Parent.FxdParams.Units] / Parent.FxdParams.IndexOfRefraction;
            var distance = TimeOfTravel * adjustedSpeedOfLight;
            switch (Parent.FxdParams.Units)
            {
                default:
                case "mt":
                    return distance;
                case "km":
                    return distance * 1000.0;
                case "ft":
                    return distance * 0.3048;
                case "kf":
                    return distance * 304.8;
                case "mi":
                    return distance * 1609.34;
            }
        }
    }

    public double Slope
    {
        get => Data.Slope / Constants.DecibelsSF;
        set => Data.Slope = (short)Math.Round(value * Constants.DecibelsSF);
    }

    public double Loss
    {
        get => Data.Loss / Constants.DecibelsSF;
        set => Data.Loss = (short)Math.Round(value * Constants.DecibelsSF);
    }

    public double Reflection
    {
        get => Data.Reflection / Constants.DecibelsSF;
        set => Data.Reflection = (short)Math.Round(value * Constants.DecibelsSF);
    }

    public string ReflectionType
    {
        get => Data.ReflectionType.ToUpper();
        set => Data.ReflectionType = value.ToUpper();
    }
    public string ReflectionTypeName
    {
        get => _reflectionTypes[ReflectionType];
    }

    public string Type
    {
        get => Data.Type.ToUpper();
        set => Data.Type = value.ToUpper();
    }
    public string TypeName
    {
        get => _eventTypes[Type];
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

    public string LossMeasurementTechniqueName
    {
        get => _lossTechniques[Data.LossMeasurementTechnique];
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

    public KeyEvent(KeyEventData data, OTDRFile parent)
    {
        Parent = parent;
        Data = data;
    }

}
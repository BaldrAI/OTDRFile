namespace BaldrAI.OpenOTDR.OTDRFile;

public static class Constants
{
    public static readonly Dictionary<string, double> SpeedOfLightMicroSecs = new()
    {
        { "km", 0.299792458 },
        { "mt", 299.792458 },
        { "ft", 983.571056 },
        { "kf", 0.983571056 },
        { "mi", 0.186282456 }
    };

    public static double WavelengthSF = 10;

    public static double IndexOfRefractionSF = 100000.0;

    public static double AcquisitionRangeSF = 10000.0; // 100ps into microseconds

    public static double TimeOfTravelSF = 10000.0;
    public static double DecibelsSF = 1000.0;
    public static double SampleSpacingSF = 100000.0;
}
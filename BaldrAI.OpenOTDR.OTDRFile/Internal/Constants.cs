namespace BaldrAI.OpenOTDR.OTDRFile.Internal;

internal static class Constants
{
    public static readonly Dictionary<string, double> SpeedOfLightMilliSecs = new()
    {
        { "km", 0.299792458 },
        { "mt", 299.792458 },
        { "ft", 983.571056 },
        { "kf", 0.983571056 },
        { "mi", 0.186282456 }
    };
}
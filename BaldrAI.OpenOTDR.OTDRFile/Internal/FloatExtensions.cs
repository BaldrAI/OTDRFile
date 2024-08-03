namespace BaldrAI.OpenOTDR.OTDRFile.Internal;

public static class ExtensionMethods
{

    public static float Remap(this float value, float input_start, float input_end, float output_start, float output_end)
    {
        return output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start);
    }

}
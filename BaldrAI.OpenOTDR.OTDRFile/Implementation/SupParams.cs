namespace BaldrAI.OpenOTDR.OTDRFile.Implementation;

public class SupParams(Span<byte> data, int format)
{
    private SupParamsData Data = new(data, format);

    public string SupplierName
    {
        get => Data.SupplierName;
        set => Data.SupplierName = value;
    }
    public string OtdrName
    {
        get => Data.OtdrName;
        set => Data.OtdrName = value;
    }
    public string OtdrSerialNumber
    {
        get => Data.OtdrSerialNumber;
        set => Data.OtdrSerialNumber = value;
    }
    public string ModuleName
    {
        get => Data.ModuleName;
        set => Data.ModuleName = value;
    }
    public string ModuleSerialNumber
    {
        get => Data.ModuleSerialNumber;
        set => Data.ModuleSerialNumber = value;
    }
    public string SoftwareVersion
    {
        get => Data.SoftwareVersion;
        set => Data.SoftwareVersion = value;
    }
    public string Other
    {
        get => Data.Other;
        set => Data.Other = value;
    }
}
using BaldrAI.OpenOTDR.OTDRFile.Internal;

namespace BaldrAI.OpenOTDR.OTDRFile;

public class SupParamsData
{
    public string SupplierName;
    public string OtdrName;
    public string OtdrSerialNumber;
    public string ModuleName;
    public string ModuleSerialNumber;
    public string SoftwareVersion;
    public string Other;

    public SupParamsData(string supplierName = "Supplier", string otdrName = "DeviceName", string otdrSerialNumber = "S00001", string moduleName = "ModuleName", string moduleSerialNumber = "S00002", string softwareVersion = "Build 12345", string other = "")
    {
        SupplierName = supplierName;
        OtdrName = otdrName;
        OtdrSerialNumber = otdrSerialNumber;
        ModuleName = moduleName;
        ModuleSerialNumber = moduleSerialNumber;
        SoftwareVersion = softwareVersion;
        Other = other;
    }

    public SupParamsData(Span<byte> data, int format)
    {
        var offset = 0;
        switch (format)
        {
            case 1:
                break;
            case 2:
                offset += data.IndexOf((byte)0) + 1;
                break;
            default:
                throw new ArgumentException("unrecognised filetype");
        }

        SupplierName = data.ReadTerminatedString(ref offset).Trim();
        OtdrName = data.ReadTerminatedString(ref offset).Trim();
        OtdrSerialNumber = data.ReadTerminatedString(ref offset).Trim();
        ModuleName = data.ReadTerminatedString(ref offset).Trim();
        ModuleSerialNumber = data.ReadTerminatedString(ref offset).Trim();
        SoftwareVersion = data.ReadTerminatedString(ref offset).Trim();
        Other =  data.ReadTerminatedString(ref offset).Trim();
    }
}


using BaldrAI.OpenOTDR.OTDRFile.DataTypes;
using BaldrAI.OpenOTDR.OTDRFile.Implementation;

namespace BaldrAI.OpenOTDR.OTDRFile;

// All the code in this file is included in all platforms.
public class OTDRFile
{
    public double Version { get; }
    public OTDRData Data;

    public GenParams GenParams;
    public SupParams SupParams;
    public FxdParams FxdParams;
    public KeyEvents KeyEvents;
    public LnkParams LnkParams;
    public LocParams LocParams;
    public DataPts DataPts;

    public OTDRFile(byte[] data)
    {
        Data = new OTDRData(data);
        GenParams = new GenParams(ref Data);
        SupParams = new SupParams(ref Data);
        FxdParams = new FxdParams(ref Data);
        KeyEvents = new KeyEvents(ref Data,  this);
        LnkParams = new LnkParams(ref Data);
        LocParams = new LocParams(ref Data);
        DataPts = new DataPts(ref Data);
    }
}
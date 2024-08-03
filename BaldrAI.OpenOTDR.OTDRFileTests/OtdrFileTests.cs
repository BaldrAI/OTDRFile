namespace BaldrAI.OpenOTDR.OTDRFile.Tests;

[TestClass()]
public class OtdrFileTests
{
    internal static byte[] ReadFile(string filePath)
    {
        byte[] b;
        using (var fs = File.Open(filePath, FileMode.Open))
        {
            b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
        }

        return b;
    }

    [TestMethod()]
    public void SORFileTest()
    {
        var data = ReadFile(".\\TestData\\SORFiles\\A-B.1310.500nS.50Km.sor");
        OTDRFile otdrFile = new(data);
        Assert.AreEqual((uint)200000, otdrFile.DataPts.NumberOfDataPoints);
        Assert.AreEqual((ushort)1, otdrFile.DataPts.NumberOfTraces);
        Assert.AreEqual(0.001, otdrFile.DataPts.Traces[0].ScalingFactor);
        Assert.AreEqual(245.1696, otdrFile.FxdParams.AcquisitionRange);
        Assert.AreEqual((ushort)652, otdrFile.GenParams.FiberType);
        Assert.AreEqual((ushort)1310, otdrFile.GenParams.Wavelength);
        Assert.AreEqual(1310, otdrFile.FxdParams.Wavelength);
    }
}
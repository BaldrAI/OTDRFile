using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaldrAI.OpenOTDR.OTDRFile.Implementation;

namespace BaldrAI.OpenOTDR.OTDRFile.Tests
{
    [TestClass()]
    public class FxdParamsTests
    {
        internal byte[] readFile(string filePath)
        {
            byte[] b;
            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                b = new byte[fs.Length];
                fs.Read(b, 0, b.Length);
            }

            return b;
        }

        [TestMethod()]
        public void FxdParamsParseTest7()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\7.bin");
            FxdParams fxdParams = new FxdParams(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2018, 7, 20, 1, 14, 45, 0), fxdParams.DateTime);
            Assert.AreEqual(1625.0, fxdParams.Wavelength);
            Assert.AreEqual(0, fxdParams.AcquisitionOffset);
            Assert.AreEqual(0, fxdParams.AcquisitionOffsetDistance);
            Assert.AreEqual("mt", fxdParams.Units);
            Assert.AreEqual(1230018, fxdParams.AcquisitionRange);
            Assert.AreEqual(2500, fxdParams.AcquisitionRangeDistance);
            Assert.AreEqual(1.47500, fxdParams.IndexOfRefraction);
        }

        [TestMethod()]
        public void FxdParamsParseTest6()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\6.bin");
            FxdParams fxdParams = new FxdParams(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2018, 5, 16, 4, 0, 23, 0), fxdParams.DateTime);
            Assert.AreEqual(1627.1, fxdParams.Wavelength);
            Assert.AreEqual("mt", fxdParams.Units);
            Assert.AreEqual(0, fxdParams.AcquisitionOffset);
            Assert.AreEqual(0, fxdParams.AcquisitionOffsetDistance);
            Assert.AreEqual(31250710, fxdParams.AcquisitionRange);
            Assert.AreEqual(0, fxdParams.AcquisitionRangeDistance);
            Assert.AreEqual(1.46830, fxdParams.IndexOfRefraction);
        }

        [TestMethod()]
        public void FxdParamsParseTest5()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\5.bin");
            FxdParams fxdParams = new FxdParams(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2018, 7, 20, 1, 06, 41, 0), fxdParams.DateTime);
            Assert.AreEqual(1625.0, fxdParams.Wavelength);
            Assert.AreEqual("mt", fxdParams.Units);
            Assert.AreEqual(0, fxdParams.AcquisitionOffset);
            Assert.AreEqual(0, fxdParams.AcquisitionOffsetDistance);
            Assert.AreEqual(2451696, fxdParams.AcquisitionRange);
            Assert.AreEqual(5000, fxdParams.AcquisitionRangeDistance);
            Assert.AreEqual(1.47000, fxdParams.IndexOfRefraction);
        }

        [TestMethod()]
        public void FxdParamsParseTest4()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\4.bin");
            FxdParams fxdParams = new FxdParams(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2020, 6, 14, 0, 23, 50, 0), fxdParams.DateTime);
            Assert.AreEqual(1310.0, fxdParams.Wavelength);
            Assert.AreEqual("mt", fxdParams.Units);
            Assert.AreEqual(0, fxdParams.AcquisitionOffset);
            Assert.AreEqual(0, fxdParams.AcquisitionOffsetDistance);
            Assert.AreEqual(500346, fxdParams.AcquisitionRange);
            Assert.AreEqual(0, fxdParams.AcquisitionRangeDistance);
            Assert.AreEqual(1.46710, fxdParams.IndexOfRefraction);
        }

        [TestMethod()]
        public void FxdParamsParseTest3()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\3.bin");
            FxdParams fxdParams = new FxdParams(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2019, 9, 30, 9, 27, 54, 0), fxdParams.DateTime);
            Assert.AreEqual(155, fxdParams.Wavelength);
            Assert.AreEqual("mt", fxdParams.Units);
            Assert.AreEqual(-2147, fxdParams.AcquisitionOffset);
            Assert.AreEqual(-0.42, fxdParams.AcquisitionOffsetDistance);
            Assert.AreEqual(300000, fxdParams.AcquisitionRange);
            Assert.AreEqual(600, fxdParams.AcquisitionRangeDistance);
            Assert.AreEqual(1.46750, fxdParams.IndexOfRefraction);
        }


        [TestMethod()]
        public void FxdParamsTest2()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\2.bin");
            FxdParams fxdParams = new FxdParams(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2019, 9, 30, 9, 27, 54, 0), fxdParams.DateTime);
            Assert.AreEqual(1550.0, fxdParams.Wavelength);
            Assert.AreEqual("mt", fxdParams.Units);
            Assert.AreEqual(-2139, fxdParams.AcquisitionOffset);
            Assert.AreEqual(-43.69, fxdParams.AcquisitionOffsetDistance);
            Assert.AreEqual(273210, fxdParams.AcquisitionRange);
            Assert.AreEqual(55813.4, fxdParams.AcquisitionRangeDistance);
            fxdParams.AcquisitionOffset = -1000;
            Assert.AreEqual(-1000, fxdParams.AcquisitionOffset);
            Assert.AreEqual(-20.43, fxdParams.AcquisitionOffsetDistance);
            fxdParams.AcquisitionOffset = 2139;
            Assert.AreEqual(2139, fxdParams.AcquisitionOffset);
            Assert.AreEqual(43.70, fxdParams.AcquisitionOffsetDistance);
            fxdParams.AcquisitionOffsetDistance = -4369;
            Assert.AreEqual(-2139, fxdParams.AcquisitionOffset);
            Assert.AreEqual(-4369, fxdParams.AcquisitionOffsetDistance);
            fxdParams.AcquisitionRangeDistance = 500000;
            Assert.AreEqual(244753, fxdParams.AcquisitionRange);
            Assert.AreEqual(50000.0, fxdParams.AcquisitionRangeDistance);
            fxdParams.AcquisitionRange = 273210;
            Assert.AreEqual(273210, fxdParams.AcquisitionRange);
            Assert.AreEqual(55813.5, fxdParams.AcquisitionRangeDistance);
            Assert.AreEqual(1.46750, fxdParams.IndexOfRefraction);
        }

        [TestMethod()]
        public void FxdParamsTest1()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\1.bin");
            FxdParams fxdParams = new FxdParams(data.AsSpan(), 2); 
            Assert.AreEqual(new DateTime(2020, 6, 13, 14, 12, 50, 0), fxdParams.DateTime);
            Assert.AreEqual(1312.9, fxdParams.Wavelength);
            Assert.AreEqual("mt", fxdParams.Units);
            Assert.AreEqual(0, fxdParams.AcquisitionOffset);
            Assert.AreEqual(0, fxdParams.AcquisitionOffsetDistance);
            Assert.AreEqual(489578, fxdParams.AcquisitionRange);
            Assert.AreEqual(156251.9, fxdParams.AcquisitionRangeDistance);
        }
    }
}
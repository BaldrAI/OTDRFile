using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaldrAI.OpenOTDR.OTDRFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaldrAI.OpenOTDR.OTDRFile.Tests
{
    [TestClass()]
    public class SupParamsDataTests
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
        public void SupParamsDataParseTest7()
        {
            var data = readFile(".\\TestData\\SupParamsChunks\\7.bin");
            SupParamsData supParamsData = new SupParamsData(data.AsSpan(), 2);
            Assert.AreEqual("SingleMode Emulator Module", supParamsData.ModuleName);
            Assert.AreEqual("20140931", supParamsData.ModuleSerialNumber);
            Assert.AreEqual("OTDR Emulator", supParamsData.OtdrName);
            Assert.AreEqual("20140931", supParamsData.OtdrSerialNumber);
            Assert.AreEqual("4.2-001_EA", supParamsData.SoftwareVersion);
            Assert.AreEqual("VanGuard Data", supParamsData.SupplierName);
            Assert.AreEqual("", supParamsData.Other);
        }

        [TestMethod()]
        public void SupParamsDataParseTest6()
        {
            var data = readFile(".\\TestData\\SupParamsChunks\\6.bin");
            SupParamsData supParamsData = new SupParamsData(data.AsSpan(), 2);
            Assert.AreEqual("FTB-730-NS1498", supParamsData.ModuleName);
            Assert.AreEqual("772797", supParamsData.ModuleSerialNumber);
            Assert.AreEqual("", supParamsData.OtdrName);
            Assert.AreEqual("", supParamsData.OtdrSerialNumber);
            Assert.AreEqual("", supParamsData.SoftwareVersion);
            Assert.AreEqual("", supParamsData.SupplierName);
            Assert.AreEqual("", supParamsData.Other);
        }

        [TestMethod()]
        public void SupParamsDataParseTest5()
        {
            var data = readFile(".\\TestData\\SupParamsChunks\\5.bin");
            SupParamsData supParamsData = new SupParamsData(data.AsSpan(), 2);
            Assert.AreEqual("SingleMode Emulator Module", supParamsData.ModuleName);
            Assert.AreEqual("20140931", supParamsData.ModuleSerialNumber);
            Assert.AreEqual("OTDR Emulator", supParamsData.OtdrName);
            Assert.AreEqual("20140931", supParamsData.OtdrSerialNumber);
            Assert.AreEqual("4.2-001_EA", supParamsData.SoftwareVersion);
            Assert.AreEqual("VanGuard Data", supParamsData.SupplierName);
            Assert.AreEqual("", supParamsData.Other);
        }

        [TestMethod()]
        public void SupParamsDataParseTest4()
        {
            var data = readFile(".\\TestData\\SupParamsChunks\\4.bin");
            SupParamsData supParamsData = new SupParamsData(data.AsSpan(), 2);
            Assert.AreEqual("MU909014B-056", supParamsData.ModuleName);
            Assert.AreEqual("6262117825", supParamsData.ModuleSerialNumber);
            Assert.AreEqual("MT9090A", supParamsData.OtdrName);
            Assert.AreEqual("6262098797", supParamsData.OtdrSerialNumber);
            Assert.AreEqual("3.02", supParamsData.SoftwareVersion);
            Assert.AreEqual("ANRITSU", supParamsData.SupplierName);
            Assert.AreEqual("", supParamsData.Other);
        }

        [TestMethod()]
        public void SupParamsDataParseTest3()
        {
            var data = readFile(".\\TestData\\SupParamsChunks\\3.bin");
            SupParamsData supParamsData = new SupParamsData(data.AsSpan(), 2);
            Assert.AreEqual("0.0.43", supParamsData.ModuleName);
            Assert.AreEqual("", supParamsData.ModuleSerialNumber);
            Assert.AreEqual("OFL280C-100", supParamsData.OtdrName);
            Assert.AreEqual("2G14PT7552", supParamsData.OtdrSerialNumber);
            Assert.AreEqual("1.2.04b1011F", supParamsData.SoftwareVersion);
            Assert.AreEqual("Noyes", supParamsData.SupplierName);
            Assert.AreEqual("Last Calibration Date:  2019-03-25", supParamsData.Other);
        }

        [TestMethod()]
        public void SupParamsDataParseTest2()
        {
            var data = readFile(".\\TestData\\SupParamsChunks\\2.bin");
            SupParamsData supParamsData = new SupParamsData(data.AsSpan(), 2);
            Assert.AreEqual("", supParamsData.ModuleName);
            Assert.AreEqual("", supParamsData.ModuleSerialNumber);
            Assert.AreEqual("", supParamsData.OtdrName);
            Assert.AreEqual("", supParamsData.OtdrSerialNumber);
            Assert.AreEqual("1.2.04b1011F", supParamsData.SoftwareVersion);
            Assert.AreEqual("Noyes", supParamsData.SupplierName);
            Assert.AreEqual("", supParamsData.Other);
        }

        [TestMethod()]
        public void SupParamsDataParseTest1()
        {
            var data = readFile(".\\TestData\\SupParamsChunks\\1.bin");
            SupParamsData supParamsData = new SupParamsData(data.AsSpan(), 2);
            Assert.AreEqual("MAX-730C-SM8-EA", supParamsData.ModuleName);
            Assert.AreEqual("1327161", supParamsData.ModuleSerialNumber);
            Assert.AreEqual("", supParamsData.OtdrName);
            Assert.AreEqual("", supParamsData.OtdrSerialNumber);
            Assert.AreEqual("", supParamsData.SoftwareVersion);
            Assert.AreEqual("", supParamsData.SupplierName);
            Assert.AreEqual("", supParamsData.Other);
        }

    }
}
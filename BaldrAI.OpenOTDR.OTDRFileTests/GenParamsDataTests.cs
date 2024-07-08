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
    public class GenParamsDataTests
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
        public void GenParamsDataParseTest7()
        {
            var data = readFile(".\\TestData\\GenParamsChunks\\7.bin");
            GenParamsData genParamsData = new GenParamsData(data.AsSpan(), 2);
            Assert.AreEqual("BC",genParamsData.BuildCondition);
            Assert.AreEqual("",genParamsData.CableCode);
            Assert.AreEqual("PON_Splitter_Cable",genParamsData.CableId);
            Assert.AreEqual("Simple PON trace",genParamsData.Comments);
            Assert.AreEqual("x32Splitter01",genParamsData.FiberId);
            Assert.AreEqual(652, genParamsData.FiberType);
            Assert.AreEqual("EN",genParamsData.Language);
            Assert.AreEqual("A Loc",genParamsData.LocationA);
            Assert.AreEqual("B Loc",genParamsData.LocationB);
            Assert.AreEqual("OTDR Operator",genParamsData.Operator);
            Assert.AreEqual(0,genParamsData.UserOffset);
            Assert.AreEqual(0,genParamsData.UserOffsetDistance);
            Assert.AreEqual(1625,genParamsData.Wavelength);
        }

        [TestMethod()]
        public void GenParamsDataParseTest6()
        {
            var data = readFile(".\\TestData\\GenParamsChunks\\6.bin");
            GenParamsData genParamsData = new GenParamsData(data.AsSpan(), 2);
            Assert.AreEqual("BC", genParamsData.BuildCondition);
            Assert.AreEqual("", genParamsData.CableCode);
            Assert.AreEqual("F SUNS 4601", genParamsData.CableId);
            Assert.AreEqual("", genParamsData.Comments);
            Assert.AreEqual("247", genParamsData.FiberId);
            Assert.AreEqual(652, genParamsData.FiberType);
            Assert.AreEqual("EN", genParamsData.Language);
            Assert.AreEqual("3DAD20.S031.2203", genParamsData.LocationA);
            Assert.AreEqual("B148", genParamsData.LocationB);
            Assert.AreEqual("", genParamsData.Operator);
            Assert.AreEqual(0, genParamsData.UserOffset);
            Assert.AreEqual(0, genParamsData.UserOffsetDistance);
            Assert.AreEqual(1625, genParamsData.Wavelength);
        }

        [TestMethod()]
        public void GenParamsDataParseTest5()
        {
            var data = readFile(".\\TestData\\GenParamsChunks\\5.bin");
            GenParamsData genParamsData = new GenParamsData(data.AsSpan(), 2);
            Assert.AreEqual("BC", genParamsData.BuildCondition);
            Assert.AreEqual("", genParamsData.CableCode);
            Assert.AreEqual("Lesson-VGD201", genParamsData.CableId);
            Assert.AreEqual("Simple short trace bi-directional", genParamsData.Comments);
            Assert.AreEqual("Practical-01", genParamsData.FiberId);
            Assert.AreEqual(652, genParamsData.FiberType);
            Assert.AreEqual("EN", genParamsData.Language);
            Assert.AreEqual("A End", genParamsData.LocationA);
            Assert.AreEqual("B End", genParamsData.LocationB);
            Assert.AreEqual("OTDR Operator", genParamsData.Operator);
            Assert.AreEqual(0, genParamsData.UserOffset);
            Assert.AreEqual(0, genParamsData.UserOffsetDistance);
            Assert.AreEqual(1625, genParamsData.Wavelength);
        }

        [TestMethod()]
        public void GenParamsDataParseTest4()
        {
            var data = readFile(".\\TestData\\GenParamsChunks\\4.bin");
            GenParamsData genParamsData = new GenParamsData(data.AsSpan(), 2);
            Assert.AreEqual("OT", genParamsData.BuildCondition);
            Assert.AreEqual("", genParamsData.CableCode);
            Assert.AreEqual("Unit_M", genParamsData.CableId);
            Assert.AreEqual("", genParamsData.Comments);
            Assert.AreEqual("MO183", genParamsData.FiberId);
            Assert.AreEqual(652, genParamsData.FiberType);
            Assert.AreEqual("EN", genParamsData.Language);
            Assert.AreEqual("SE-FAWER", genParamsData.LocationA);
            Assert.AreEqual("SE-FAWER-CLS26", genParamsData.LocationB);
            Assert.AreEqual("Rob", genParamsData.Operator);
            Assert.AreEqual(0, genParamsData.UserOffset);
            Assert.AreEqual(0, genParamsData.UserOffsetDistance);
            Assert.AreEqual(1310, genParamsData.Wavelength);
        }

        [TestMethod()]
        public void GenParamsDataParseTest3()
        {
            var data = readFile(".\\TestData\\GenParamsChunks\\3.bin");
            GenParamsData genParamsData = new GenParamsData(data.AsSpan(), 2);
            Assert.AreEqual("NC", genParamsData.BuildCondition);
            Assert.AreEqual("", genParamsData.CableCode);
            Assert.AreEqual("C001", genParamsData.CableId);
            Assert.AreEqual("", genParamsData.Comments);
            Assert.AreEqual("009", genParamsData.FiberId);
            Assert.AreEqual(652, genParamsData.FiberType);
            Assert.AreEqual("EN", genParamsData.Language);
            Assert.AreEqual("CAB000", genParamsData.LocationA);
            Assert.AreEqual("CLS007", genParamsData.LocationB);
            Assert.AreEqual("", genParamsData.Operator);
            Assert.AreEqual(24641, genParamsData.UserOffset);
            Assert.AreEqual(503, genParamsData.UserOffsetDistance);
            Assert.AreEqual(1550, genParamsData.Wavelength);
        }

        [TestMethod()]
        public void GenParamsDataParseTest2()
        {
            var data = readFile(".\\TestData\\GenParamsChunks\\2.bin");
            GenParamsData genParamsData = new GenParamsData(data.AsSpan(), 2);
            Assert.AreEqual("BC", genParamsData.BuildCondition);
            Assert.AreEqual("", genParamsData.CableCode);
            Assert.AreEqual("C001", genParamsData.CableId);
            Assert.AreEqual("", genParamsData.Comments);
            Assert.AreEqual("009", genParamsData.FiberId);
            Assert.AreEqual(652, genParamsData.FiberType);
            Assert.AreEqual("EN", genParamsData.Language);
            Assert.AreEqual("CAB000", genParamsData.LocationA);
            Assert.AreEqual("CLS007", genParamsData.LocationB);
            Assert.AreEqual("", genParamsData.Operator);
            Assert.AreEqual(24640, genParamsData.UserOffset);
            Assert.AreEqual(5033, genParamsData.UserOffsetDistance);
            Assert.AreEqual(1550, genParamsData.Wavelength);
        }

        [TestMethod()]
        public void GenParamsDataParseTest1()
        {
            var data = readFile(".\\TestData\\GenParamsChunks\\1.bin");
            GenParamsData genParamsData = new GenParamsData(data.AsSpan(), 2);
            Assert.AreEqual("BC", genParamsData.BuildCondition);
            Assert.AreEqual("", genParamsData.CableCode);
            Assert.AreEqual("", genParamsData.CableId);
            Assert.AreEqual("", genParamsData.Comments);
            Assert.AreEqual("Fiber8", genParamsData.FiberId);
            Assert.AreEqual(652, genParamsData.FiberType);
            Assert.AreEqual("EN", genParamsData.Language);
            Assert.AreEqual("", genParamsData.LocationA);
            Assert.AreEqual("", genParamsData.LocationB);
            Assert.AreEqual("", genParamsData.Operator);
            Assert.AreEqual(0, genParamsData.UserOffset);
            Assert.AreEqual(0, genParamsData.UserOffsetDistance);
            Assert.AreEqual(1310, genParamsData.Wavelength);
        }

    }
}
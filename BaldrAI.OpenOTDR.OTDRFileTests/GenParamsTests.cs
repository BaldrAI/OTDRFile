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
    public class GenParamsTests
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
        public void GenParamsTest()
        {
            var data = readFile(".\\TestData\\GenParamsChunks\\2.bin");
            GenParams genParams = new GenParams(data.AsSpan(), 2, new GenParamsConfig(0.20428787597955705));
            Assert.AreEqual("BC", genParams.BuildCondition);
            Assert.AreEqual("", genParams.CableCode);
            Assert.AreEqual("C001", genParams.CableId);
            Assert.AreEqual("", genParams.Comments);
            Assert.AreEqual("009", genParams.FiberId);
            Assert.AreEqual(652, genParams.FiberType);
            Assert.AreEqual("EN", genParams.Language);
            Assert.AreEqual("CAB000", genParams.LocationA);
            Assert.AreEqual("CLS007", genParams.LocationB);
            Assert.AreEqual("", genParams.Operator);
            Assert.AreEqual(1550, genParams.Wavelength);
            Assert.AreEqual(24640, genParams.UserOffset);
            Assert.AreEqual(5033, genParams.UserOffsetDistance);
            genParams.UserOffsetDistance = 5000;
            Assert.AreEqual(24475, genParams.UserOffset);
            Assert.AreEqual(5000, genParams.UserOffsetDistance);
            genParams.UserOffset = 24640;
            Assert.AreEqual(24640, genParams.UserOffset);
            Assert.AreEqual(5034, genParams.UserOffsetDistance); // Off by 1 due to vendor using static casting without handling the decimal.
        }
    }
}
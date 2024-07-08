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
    public class DataPtsDataTests
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
        public void DataPtsDataParseTest7()
        {
            var data = readFile(".\\TestData\\DataPtsChunks\\7.bin");
            DataPtsData dataPtsData = new DataPtsData(data.AsSpan(), 2);
            Assert.AreEqual((uint)25000, dataPtsData.NumberOfDataPoints);
            Assert.AreEqual((ushort)1, dataPtsData.NumberOfTraces);
            Assert.AreEqual(1, dataPtsData.Traces.Count);
            Assert.AreEqual((uint)25000, dataPtsData.Traces[0].NumberOfDataPoints);
            Assert.AreEqual((ushort)1000, dataPtsData.Traces[0].ScalingFactor);
            Assert.AreEqual((ushort)3076, dataPtsData.Traces[0].DataPoints[2]);
        }
        [TestMethod()]
        public void DataPtsDataParseTest6()
        {
            var data = readFile(".\\TestData\\DataPtsChunks\\6.bin");
            DataPtsData dataPtsData = new DataPtsData(data.AsSpan(), 2);
            Assert.AreEqual((uint)7834, dataPtsData.NumberOfDataPoints);
            Assert.AreEqual((ushort)1, dataPtsData.NumberOfTraces);
            Assert.AreEqual(1, dataPtsData.Traces.Count);
            Assert.AreEqual((uint)7834, dataPtsData.Traces[0].NumberOfDataPoints);
            Assert.AreEqual((ushort)1000, dataPtsData.Traces[0].ScalingFactor);
            Assert.AreEqual((ushort)8428, dataPtsData.Traces[0].DataPoints[2]);
        }
        [TestMethod()]
        public void DataPtsDataParseTest5()
        {
            var data = readFile(".\\TestData\\DataPtsChunks\\5.bin");
            DataPtsData dataPtsData = new DataPtsData(data.AsSpan(), 2);
            Assert.AreEqual((uint)200000, dataPtsData.NumberOfDataPoints);
            Assert.AreEqual((ushort)1, dataPtsData.NumberOfTraces);
            Assert.AreEqual(1, dataPtsData.Traces.Count);
            Assert.AreEqual((uint)200000, dataPtsData.Traces[0].NumberOfDataPoints);
            Assert.AreEqual((ushort)1000, dataPtsData.Traces[0].ScalingFactor);
            Assert.AreEqual((ushort)4098, dataPtsData.Traces[0].DataPoints[2]);
        }
        [TestMethod()]
        public void DataPtsDataParseTest4()
        {
            var data = readFile(".\\TestData\\DataPtsChunks\\4.bin");
            DataPtsData dataPtsData = new DataPtsData(data.AsSpan(), 2);
            Assert.AreEqual((uint)20001, dataPtsData.NumberOfDataPoints);
            Assert.AreEqual((ushort)1, dataPtsData.NumberOfTraces);
            Assert.AreEqual(1, dataPtsData.Traces.Count);
            Assert.AreEqual((uint)20001, dataPtsData.Traces[0].NumberOfDataPoints);
            Assert.AreEqual((ushort)1000, dataPtsData.Traces[0].ScalingFactor);
            Assert.AreEqual((ushort)43804, dataPtsData.Traces[0].DataPoints[2]);
        }

        [TestMethod()]
        public void DataPtsDataParseTest3()
        {
            var data = readFile(".\\TestData\\DataPtsChunks\\3.bin");
            DataPtsData dataPtsData = new DataPtsData(data.AsSpan(), 2);
            Assert.AreEqual((uint)30000, dataPtsData.NumberOfDataPoints);
            Assert.AreEqual((ushort)1, dataPtsData.NumberOfTraces);
            Assert.AreEqual(1, dataPtsData.Traces.Count);
            Assert.AreEqual((uint)30000, dataPtsData.Traces[0].NumberOfDataPoints);
            Assert.AreEqual((ushort)1000, dataPtsData.Traces[0].ScalingFactor);
            Assert.AreEqual((ushort)22159, dataPtsData.Traces[0].DataPoints[2]);
        }

        [TestMethod()]
        public void DataPtsDataParseTest2()
        {
            var data = readFile(".\\TestData\\DataPtsChunks\\2.bin");
            DataPtsData dataPtsData = new DataPtsData(data.AsSpan(), 2);
            Assert.AreEqual((uint)30000, dataPtsData.NumberOfDataPoints);
            Assert.AreEqual((ushort)1, dataPtsData.NumberOfTraces);
            Assert.AreEqual(1, dataPtsData.Traces.Count);
            Assert.AreEqual((uint)30000, dataPtsData.Traces[0].NumberOfDataPoints);
            Assert.AreEqual((ushort)1000, dataPtsData.Traces[0].ScalingFactor);
            Assert.AreEqual((ushort)21782, dataPtsData.Traces[0].DataPoints[2]);
        }

        [TestMethod()]
        public void DataPtsDataParseTest1()
        {
            var data = readFile(".\\TestData\\DataPtsChunks\\1.bin");
            DataPtsData dataPtsData = new DataPtsData(data.AsSpan(), 2);
            Assert.AreEqual((uint)31343, dataPtsData.NumberOfDataPoints);
            Assert.AreEqual((ushort)1, dataPtsData.NumberOfTraces);
            Assert.AreEqual(1, dataPtsData.Traces.Count);
            Assert.AreEqual((uint)31343, dataPtsData.Traces[0].NumberOfDataPoints);
            Assert.AreEqual((ushort)1000, dataPtsData.Traces[0].ScalingFactor);
            Assert.AreEqual((ushort)38488, dataPtsData.Traces[0].DataPoints[2]);
        }
    }
}
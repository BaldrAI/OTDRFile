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
    public class FxdParamsDataTests
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
        public void FxdParamsDataParseTest7()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\7.bin");
            FxdParamsData fxdParamsData = new FxdParamsData(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2018, 7, 20, 1, 14, 45, 0), fxdParamsData.DateTime);
            Assert.AreEqual(16250, fxdParamsData.Wavelength);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffset);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffsetDistance);
            Assert.AreEqual("mt", fxdParamsData.Units);
            Assert.AreEqual((uint)1230018, fxdParamsData.AcquisitionRange);
            Assert.AreEqual((uint)25000, fxdParamsData.AcquisitionRangeDistance);
            Assert.AreEqual(180, fxdParamsData.AveragingTime);
            Assert.AreEqual(64736, fxdParamsData.BackscatteringCoefficient);
            Assert.AreEqual(3000, fxdParamsData.EndOfTransmissionThreshold);
            Assert.AreEqual(0, fxdParamsData.FrontPanelOffset);
            Assert.AreEqual((uint)147500, fxdParamsData.IndexOfRefraction);
            Assert.AreEqual(0, fxdParamsData.LossThreshold);
            Assert.AreEqual(26, fxdParamsData.NoiseFloorLevel);
            Assert.AreEqual((uint)27000, fxdParamsData.NumberOfAverages);
            Assert.AreEqual(1000, fxdParamsData.NoiseFloorScalingFactor);
            Assert.AreEqual(1, fxdParamsData.NumberOfTraces);
            Assert.AreEqual(0, fxdParamsData.PowerOffsetFirstPoint);
            Assert.AreEqual(40000, fxdParamsData.ReflectionThreshold);
            Assert.AreEqual("ST", fxdParamsData.TraceType);
            Assert.AreEqual(0, fxdParamsData.X1);
            Assert.AreEqual(0, fxdParamsData.Y1);
            Assert.AreEqual(0, fxdParamsData.X2);
            Assert.AreEqual(0, fxdParamsData.Y2);
            var pulseWidths = new List<ushort> { 1000, };
            CollectionAssert.AreEqual(pulseWidths, fxdParamsData.PulseWidth);
            List<uint> sampleSpacings = new([492007,]);
            CollectionAssert.AreEqual(sampleSpacings, fxdParamsData.SampleSpacing);
            List<uint> numberOfPoints = new([25000,]);
            CollectionAssert.AreEqual(numberOfPoints, fxdParamsData.NumberOfDataPointsInTrace);
        }

        [TestMethod()]
        public void FxdParamsDataParseTest6()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\6.bin");
            FxdParamsData fxdParamsData = new FxdParamsData(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2018, 5, 16, 4, 0, 23, 0), fxdParamsData.DateTime);
            Assert.AreEqual(16271, fxdParamsData.Wavelength);
            Assert.AreEqual("mt", fxdParamsData.Units);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffset);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffsetDistance);
            Assert.AreEqual((uint)31250710, fxdParamsData.AcquisitionRange);
            Assert.AreEqual((uint)0, fxdParamsData.AcquisitionRangeDistance);
            Assert.AreEqual(30, fxdParamsData.AveragingTime);
            Assert.AreEqual(826, fxdParamsData.BackscatteringCoefficient);
            Assert.AreEqual(5000, fxdParamsData.EndOfTransmissionThreshold);
            Assert.AreEqual(0, fxdParamsData.FrontPanelOffset);
            Assert.AreEqual((uint)146830, fxdParamsData.IndexOfRefraction);
            Assert.AreEqual(100, fxdParamsData.LossThreshold);
            Assert.AreEqual(31999, fxdParamsData.NoiseFloorLevel);
            Assert.AreEqual((uint)7642, fxdParamsData.NumberOfAverages);
            Assert.AreEqual(1000, fxdParamsData.NoiseFloorScalingFactor);
            Assert.AreEqual(1, fxdParamsData.NumberOfTraces);
            Assert.AreEqual(0, fxdParamsData.PowerOffsetFirstPoint);
            Assert.AreEqual(65535, fxdParamsData.ReflectionThreshold);
            Assert.AreEqual("ST", fxdParamsData.TraceType);
            Assert.AreEqual(0, fxdParamsData.X1);
            Assert.AreEqual(0, fxdParamsData.Y1);
            Assert.AreEqual(0, fxdParamsData.X2);
            Assert.AreEqual(0, fxdParamsData.Y2);
            var pulseWidths = new List<ushort> { 100, };
            CollectionAssert.AreEqual(pulseWidths, fxdParamsData.PulseWidth);
            List<uint> sampleSpacings = new([625000,]);
            CollectionAssert.AreEqual(sampleSpacings, fxdParamsData.SampleSpacing);
            List<uint> numberOfPoints = new([7834,]);
            CollectionAssert.AreEqual(numberOfPoints, fxdParamsData.NumberOfDataPointsInTrace);
        }

        [TestMethod()]
        public void FxdParamsDataParseTest5()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\5.bin");
            FxdParamsData fxdParamsData = new FxdParamsData(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2018, 7, 20, 1, 06, 41, 0), fxdParamsData.DateTime);
            Assert.AreEqual(16250, fxdParamsData.Wavelength);
            Assert.AreEqual("mt", fxdParamsData.Units);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffset);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffsetDistance);
            Assert.AreEqual((uint)2451696, fxdParamsData.AcquisitionRange);
            Assert.AreEqual((uint)50000, fxdParamsData.AcquisitionRangeDistance);
            Assert.AreEqual(25, fxdParamsData.AveragingTime);
            Assert.AreEqual(64736, fxdParamsData.BackscatteringCoefficient);
            Assert.AreEqual(3000, fxdParamsData.EndOfTransmissionThreshold);
            Assert.AreEqual(0, fxdParamsData.FrontPanelOffset);
            Assert.AreEqual((uint)147000, fxdParamsData.IndexOfRefraction);
            Assert.AreEqual(0, fxdParamsData.LossThreshold);
            Assert.AreEqual(18, fxdParamsData.NoiseFloorLevel);
            Assert.AreEqual((uint)3750, fxdParamsData.NumberOfAverages);
            Assert.AreEqual(1000, fxdParamsData.NoiseFloorScalingFactor);
            Assert.AreEqual(1, fxdParamsData.NumberOfTraces);
            Assert.AreEqual(0, fxdParamsData.PowerOffsetFirstPoint);
            Assert.AreEqual(40000, fxdParamsData.ReflectionThreshold);
            Assert.AreEqual("ST", fxdParamsData.TraceType);
            Assert.AreEqual(0, fxdParamsData.X1);
            Assert.AreEqual(0, fxdParamsData.Y1);
            Assert.AreEqual(0, fxdParamsData.X2);
            Assert.AreEqual(0, fxdParamsData.Y2);
            var pulseWidths = new List<ushort> { 500, };
            CollectionAssert.AreEqual(pulseWidths, fxdParamsData.PulseWidth);
            List<uint> sampleSpacings = new([122585,]);
            CollectionAssert.AreEqual(sampleSpacings, fxdParamsData.SampleSpacing);
            List<uint> numberOfPoints = new([200000,]);
            CollectionAssert.AreEqual(numberOfPoints, fxdParamsData.NumberOfDataPointsInTrace);
        }

        [TestMethod()]
        public void FxdParamsDataParseTest4()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\4.bin");
            FxdParamsData fxdParamsData = new FxdParamsData(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2020, 6, 14, 0, 23, 50, 0), fxdParamsData.DateTime);
            Assert.AreEqual(13100, fxdParamsData.Wavelength);
            Assert.AreEqual("mt", fxdParamsData.Units);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffset);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffsetDistance);
            Assert.AreEqual((uint)500346, fxdParamsData.AcquisitionRange);
            Assert.AreEqual((uint)0, fxdParamsData.AcquisitionRangeDistance);
            Assert.AreEqual(30, fxdParamsData.AveragingTime);
            Assert.AreEqual(600, fxdParamsData.BackscatteringCoefficient);
            Assert.AreEqual(14464, fxdParamsData.EndOfTransmissionThreshold);
            Assert.AreEqual(500, fxdParamsData.FrontPanelOffset);
            Assert.AreEqual((uint)146710, fxdParamsData.IndexOfRefraction);
            Assert.AreEqual(50, fxdParamsData.LossThreshold);
            Assert.AreEqual(51999, fxdParamsData.NoiseFloorLevel);
            Assert.AreEqual((uint)15360, fxdParamsData.NumberOfAverages);
            Assert.AreEqual(1000, fxdParamsData.NoiseFloorScalingFactor);
            Assert.AreEqual(1, fxdParamsData.NumberOfTraces);
            Assert.AreEqual(0, fxdParamsData.PowerOffsetFirstPoint);
            Assert.AreEqual(40000, fxdParamsData.ReflectionThreshold);
            Assert.AreEqual("ST", fxdParamsData.TraceType);
            Assert.AreEqual(0, fxdParamsData.X1);
            Assert.AreEqual(0, fxdParamsData.Y1);
            Assert.AreEqual(0, fxdParamsData.X2);
            Assert.AreEqual(0, fxdParamsData.Y2);
            var pulseWidths = new List<ushort> { 100, };
            CollectionAssert.AreEqual(pulseWidths, fxdParamsData.PulseWidth);
            List<uint> sampleSpacings = new([250173,]);
            CollectionAssert.AreEqual(sampleSpacings, fxdParamsData.SampleSpacing);
            List<uint> numberOfPoints = new([20001,]);
            CollectionAssert.AreEqual(numberOfPoints, fxdParamsData.NumberOfDataPointsInTrace);
        }

        [TestMethod()]
        public void FxdParamsDataParseTest3()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\3.bin");
            FxdParamsData fxdParamsData = new FxdParamsData(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2019, 9, 30, 9, 27, 54, 0), fxdParamsData.DateTime);
            Assert.AreEqual(1550, fxdParamsData.Wavelength);
            Assert.AreEqual("mt", fxdParamsData.Units);
            Assert.AreEqual(-2147, fxdParamsData.AcquisitionOffset);
            Assert.AreEqual(-42, fxdParamsData.AcquisitionOffsetDistance);
            Assert.AreEqual((uint)300000, fxdParamsData.AcquisitionRange);
            Assert.AreEqual((uint)6000, fxdParamsData.AcquisitionRangeDistance);
            Assert.AreEqual(3000, fxdParamsData.AveragingTime);
            Assert.AreEqual(802, fxdParamsData.BackscatteringCoefficient);
            Assert.AreEqual(3000, fxdParamsData.EndOfTransmissionThreshold);
            Assert.AreEqual(2147, fxdParamsData.FrontPanelOffset);
            Assert.AreEqual((uint)146750, fxdParamsData.IndexOfRefraction);
            Assert.AreEqual(50, fxdParamsData.LossThreshold);
            Assert.AreEqual(30342, fxdParamsData.NoiseFloorLevel);
            Assert.AreEqual((uint)2704, fxdParamsData.NumberOfAverages);
            Assert.AreEqual(1000, fxdParamsData.NoiseFloorScalingFactor);
            Assert.AreEqual(1, fxdParamsData.NumberOfTraces);
            Assert.AreEqual(0, fxdParamsData.PowerOffsetFirstPoint);
            Assert.AreEqual(65000, fxdParamsData.ReflectionThreshold);
            Assert.AreEqual("ST", fxdParamsData.TraceType);
            Assert.AreEqual(0, fxdParamsData.X1);
            Assert.AreEqual(0, fxdParamsData.Y1);
            Assert.AreEqual(0, fxdParamsData.X2);
            Assert.AreEqual(0, fxdParamsData.Y2);
            var pulseWidths = new List<ushort> { 30, };
            CollectionAssert.AreEqual(pulseWidths, fxdParamsData.PulseWidth);
            List<uint> sampleSpacings = new([100000,]);
            CollectionAssert.AreEqual(sampleSpacings, fxdParamsData.SampleSpacing);
            List<uint> numberOfPoints = new([30000,]);
            CollectionAssert.AreEqual(numberOfPoints, fxdParamsData.NumberOfDataPointsInTrace);
        }

        [TestMethod()]
        public void FxdParamsDataParseTest2()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\2.bin");
            FxdParamsData fxdParamsData = new FxdParamsData(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2019, 9, 30, 9, 27, 54, 0), fxdParamsData.DateTime);
            Assert.AreEqual(15500, fxdParamsData.Wavelength);
            Assert.AreEqual("mt", fxdParamsData.Units);
            Assert.AreEqual(-2139, fxdParamsData.AcquisitionOffset);
            Assert.AreEqual(-4369, fxdParamsData.AcquisitionOffsetDistance);
            Assert.AreEqual((uint)273210, fxdParamsData.AcquisitionRange);
            Assert.AreEqual((uint)558134, fxdParamsData.AcquisitionRangeDistance);
            Assert.AreEqual(3000, fxdParamsData.AveragingTime);
            Assert.AreEqual(802, fxdParamsData.BackscatteringCoefficient);
            Assert.AreEqual(3000, fxdParamsData.EndOfTransmissionThreshold);
            Assert.AreEqual(2150, fxdParamsData.FrontPanelOffset);
            Assert.AreEqual((uint)146750, fxdParamsData.IndexOfRefraction);
            Assert.AreEqual(50, fxdParamsData.LossThreshold);
            Assert.AreEqual(30342, fxdParamsData.NoiseFloorLevel);
            Assert.AreEqual((uint)2704, fxdParamsData.NumberOfAverages);
            Assert.AreEqual(1000, fxdParamsData.NoiseFloorScalingFactor);
            Assert.AreEqual(1, fxdParamsData.NumberOfTraces);
            Assert.AreEqual(0, fxdParamsData.PowerOffsetFirstPoint);
            Assert.AreEqual(65000, fxdParamsData.ReflectionThreshold);
            Assert.AreEqual("ST", fxdParamsData.TraceType);
            Assert.AreEqual(0, fxdParamsData.X1);
            Assert.AreEqual(0, fxdParamsData.Y1);
            Assert.AreEqual(0, fxdParamsData.X2);
            Assert.AreEqual(0, fxdParamsData.Y2);
            var pulseWidths = new List<ushort> { 30, };
            CollectionAssert.AreEqual(pulseWidths, fxdParamsData.PulseWidth);
            List<uint> sampleSpacings = new([100000,]);
            CollectionAssert.AreEqual(sampleSpacings, fxdParamsData.SampleSpacing);
            List<uint> numberOfPoints = new([30000,]);
            CollectionAssert.AreEqual(numberOfPoints, fxdParamsData.NumberOfDataPointsInTrace);
        }

        [TestMethod()]
        public void FxdParamsDataParseTest1()
        {
            var data = readFile(".\\TestData\\FxdParamsChunks\\1.bin");
            FxdParamsData fxdParamsData = new FxdParamsData(data.AsSpan(), 2);
            Assert.AreEqual(new DateTime(2020, 6, 13, 14, 12, 50, 0), fxdParamsData.DateTime);
            Assert.AreEqual(13129, fxdParamsData.Wavelength);
            Assert.AreEqual("mt", fxdParamsData.Units);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffset);
            Assert.AreEqual(0, fxdParamsData.AcquisitionOffsetDistance);
            Assert.AreEqual((uint)489578, fxdParamsData.AcquisitionRange);
            Assert.AreEqual((uint)1562519, fxdParamsData.AcquisitionRangeDistance);
            Assert.AreEqual(10, fxdParamsData.AveragingTime);
            Assert.AreEqual(794, fxdParamsData.BackscatteringCoefficient);
            Assert.AreEqual(5000, fxdParamsData.EndOfTransmissionThreshold);
            Assert.AreEqual(0, fxdParamsData.FrontPanelOffset);
            Assert.AreEqual((uint)146770, fxdParamsData.IndexOfRefraction);
            Assert.AreEqual(20, fxdParamsData.LossThreshold);
            Assert.AreEqual(46119, fxdParamsData.NoiseFloorLevel);
            Assert.AreEqual((uint)1012, fxdParamsData.NumberOfAverages);
            Assert.AreEqual(1000, fxdParamsData.NoiseFloorScalingFactor);
            Assert.AreEqual(1, fxdParamsData.NumberOfTraces);
            Assert.AreEqual(0, fxdParamsData.PowerOffsetFirstPoint);
            Assert.AreEqual(65535, fxdParamsData.ReflectionThreshold);
            Assert.AreEqual("ST", fxdParamsData.TraceType);
            Assert.AreEqual(0, fxdParamsData.X1);
            Assert.AreEqual(0, fxdParamsData.Y1);
            Assert.AreEqual(0, fxdParamsData.X2);
            Assert.AreEqual(0, fxdParamsData.Y2);
            var  pulseWidths = new List<ushort> { 10, };
            CollectionAssert.AreEqual(pulseWidths, fxdParamsData.PulseWidth);
            List<uint> sampleSpacings = new([ 156250, ]);
            CollectionAssert.AreEqual(sampleSpacings, fxdParamsData.SampleSpacing);
            List<uint> numberOfPoints = new([ 31343, ]);
            CollectionAssert.AreEqual(numberOfPoints, fxdParamsData.NumberOfDataPointsInTrace);

        }
    }
}
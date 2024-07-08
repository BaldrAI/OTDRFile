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
    public class KeyEventsDataTests
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
        public void KeyParamsDataParseTest7()
        {
            var data = readFile(".\\TestData\\KeyEventsChunks\\7.bin");
            KeyEventsData keyEventsData = new KeyEventsData(data.AsSpan(), 2);
            Assert.AreEqual(1, keyEventsData.EndToEndLoss);
            Assert.AreEqual(0, keyEventsData.EndToEndLossMarker1);
            Assert.AreEqual(0, keyEventsData.EndToEndLossMarker2);
            List<KeyEventData> keyEvents = new();
            keyEvents.Add(new KeyEventData((ushort)1, (uint)12300, (short)250, (short)0, (int)40000, "1", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "AA"));
            keyEvents.Add(new KeyEventData((ushort)2, (uint)44575, (short)250, (short)0, (int)0, "0", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "Splice01-Gain"));
            keyEvents.Add(new KeyEventData((ushort)3, (uint)126101, (short)250, (short)0, (int)40000, "1", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "SplitterX32"));
            int i = 0;
            foreach (var expectedEvent in keyEvents)
            {
                var actualEvent = keyEventsData.Events[i++];
                Assert.AreEqual<KeyEventData>(expectedEvent, actualEvent);
            }
            Assert.AreEqual(3, keyEventsData.NumberOfEvents);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLoss);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLossMarker1);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLossMarker2);
        }

        [TestMethod()]
        public void KeyParamsDataParseTest6()
        {
            var data = readFile(".\\TestData\\KeyEventsChunks\\6.bin");
            KeyEventsData keyEventsData = new KeyEventsData(data.AsSpan(), 2);
            Assert.AreEqual(11675, keyEventsData.EndToEndLoss);
            Assert.AreEqual(0, keyEventsData.EndToEndLossMarker1);
            Assert.AreEqual(197938, keyEventsData.EndToEndLossMarker2);
            List<KeyEventData> keyEvents = new();
            keyEvents.Add(new KeyEventData((ushort)1, (uint)0, (short)0, (short)0, (int)0, "1", "F", "9999", "LS", (uint)0, (uint)0, (uint)938, (uint)7313, (uint)0, " "));
            keyEvents.Add(new KeyEventData((ushort)2, (uint)7313, (short)435, (short)39, (int)-38497, "1", "F", "9999", "LS", (uint)938, (uint)7313, (uint)8813, (uint)23063, (uint)7313, " "));
            keyEvents.Add(new KeyEventData((ushort)3, (uint)23063, (short)4, (short)5000, (int)0, "0", "E", "9999", "LS", (uint)8813, (uint)23063, (uint)24688, (uint)42625, (uint)23063, " "));
            keyEvents.Add(new KeyEventData((ushort)4, (uint)197938, (short)3240, (short)5000, (int)-56004, "1", "E", "9999", "LS", (uint)44625, (uint)197938, (uint)199625, (uint)444500, (uint)197938, " "));
            int i = 0;
            foreach (var expectedEvent in keyEvents)
            {
                var actualEvent = keyEventsData.Events[i++];
                Assert.AreEqual<KeyEventData>(expectedEvent, actualEvent);
            }
            Assert.AreEqual(4, keyEventsData.NumberOfEvents);
            Assert.AreEqual(37766, keyEventsData.OpticalReturnLoss);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLossMarker1);
            Assert.AreEqual(23062, keyEventsData.OpticalReturnLossMarker2);
        }

        [TestMethod()]
        public void KeyParamsDataParseTest5()
        {
            var data = readFile(".\\TestData\\KeyEventsChunks\\5.bin");
            KeyEventsData keyEventsData = new KeyEventsData(data.AsSpan(), 2);
            Assert.AreEqual(8, keyEventsData.EndToEndLoss);
            Assert.AreEqual(0, keyEventsData.EndToEndLossMarker1);
            Assert.AreEqual(0, keyEventsData.EndToEndLossMarker2);
            List<KeyEventData> keyEvents = new();
            keyEvents.Add(new KeyEventData((ushort)1, (uint)99097, (short)250, (short)0, (int)0, "0", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "Typical Splice"));
            keyEvents.Add(new KeyEventData((ushort)2, (uint)499753, (short)310, (short)0, (int)40000, "1", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "AB"));
            keyEvents.Add(new KeyEventData((ushort)3, (uint)560261, (short)250, (short)0, (int)0, "0", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "Gainer Due to loss settings"));
            keyEvents.Add(new KeyEventData((ushort)4, (uint)614493, (short)250, (short)0, (int)0, "0", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "High Loss Event"));
            keyEvents.Add(new KeyEventData((ushort)5, (uint)859564, (short)250, (short)0, (int)0, "0", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "Good Splice"));
            keyEvents.Add(new KeyEventData((ushort)6, (uint)964938, (short)250, (short)0, (int)0, "0", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "High Loss Splice"));
            keyEvents.Add(new KeyEventData((ushort)7, (uint)1075313, (short)250, (short)0, (int)0, "0", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "Pigtail"));
            keyEvents.Add(new KeyEventData((ushort)8, (uint)1075804, (short)250, (short)0, (int)40000, "1", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "Clocs Connectors01"));
            keyEvents.Add(new KeyEventData((ushort)9, (uint)1085611, (short)250, (short)0, (int)40000, "1", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "Close connector02"));
            keyEvents.Add(new KeyEventData((ushort)10, (uint)1086101, (short)250, (short)0, (int)0, "0", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "B-A gainer"));
            keyEvents.Add(new KeyEventData((ushort)11, (uint)1215894, (short)250, (short)0, (int)0, "0", "f", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "AH"));
            keyEvents.Add(new KeyEventData((ushort)12, (uint)1250855, (short)250, (short)0, (int)40000, "1", "e", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, "B End"));
            int i = 0;
            foreach (var expectedEvent in keyEvents)
            {
                var actualEvent = keyEventsData.Events[i++];
                Assert.AreEqual<KeyEventData>(expectedEvent, actualEvent);
            }
            Assert.AreEqual(12, keyEventsData.NumberOfEvents);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLoss);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLossMarker1);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLossMarker2);
        }

        [TestMethod()]
        public void KeyParamsDataParseTest4()
        {
            var data = readFile(".\\TestData\\KeyEventsChunks\\4.bin");
            KeyEventsData keyEventsData = new KeyEventsData(data.AsSpan(), 2);
            Assert.AreEqual(3034, keyEventsData.EndToEndLoss);
            Assert.AreEqual(0, keyEventsData.EndToEndLossMarker1);
            Assert.AreEqual(390745, keyEventsData.EndToEndLossMarker2);
            List<KeyEventData> keyEvents = new();
            keyEvents.Add(new KeyEventData((ushort)2, (uint)49459, (short)321, (short)434, (int)-34156, "1", "F", "9999", "2P", (uint)49459, (uint)49459, (uint)51811, (uint)51961, (uint)49459, " "));
            keyEvents.Add(new KeyEventData((ushort)3, (uint)340160, (short)303, (short)87, (int)-33268, "1", "F", "9999", "2P", (uint)340160, (uint)340160, (uint)343613, (uint)343763, (uint)340160, " "));
            keyEvents.Add(new KeyEventData((ushort)4, (uint)390745, (short)378, (short)13684, (int)4014, "1", "E", "9999", "2P", (uint)390745, (uint)390745, (uint)431674, (uint)431824, (uint)390745, " "));
            int i = 0;
            foreach (var expectedEvent in keyEvents)
            {
                var actualEvent = keyEventsData.Events[i++];
                Assert.AreEqual<KeyEventData>(expectedEvent, actualEvent);
            }
            Assert.AreEqual(3, keyEventsData.NumberOfEvents);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLoss);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLossMarker1);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLossMarker2);
        }

        [TestMethod()]
        public void KeyParamsDataParseTest3()
        {
            var data = readFile(".\\TestData\\KeyEventsChunks\\3.bin");
            KeyEventsData keyEventsData = new KeyEventsData(data.AsSpan(), 2);
            Assert.AreEqual(576, keyEventsData.EndToEndLoss);
            Assert.AreEqual(0, keyEventsData.EndToEndLossMarker1);
            Assert.AreEqual(182809, keyEventsData.EndToEndLossMarker2);
            List<KeyEventData> keyEvents = new();
            keyEvents.Add(new KeyEventData((ushort)1, (uint)0, (short)0, (short)-215, (int)-46671, "1", "F", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, " "));
            keyEvents.Add(new KeyEventData((ushort)2, (uint)532, (short)0, (short)374, (int)0, "0", "F", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, " "));
            keyEvents.Add(new KeyEventData((ushort)3, (uint)182802, (short)185, (short)-950, (int)-23027, "2", "E", "9999", "LS", (uint)0, (uint)0, (uint)0, (uint)0, (uint)0, " "));
            int i = 0;
            foreach (var expectedEvent in keyEvents)
            {
                var actualEvent = keyEventsData.Events[i++];
                Assert.AreEqual<KeyEventData>(expectedEvent, actualEvent);
            }
            Assert.AreEqual(3, keyEventsData.NumberOfEvents);
            Assert.AreEqual(24516, keyEventsData.OpticalReturnLoss);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLossMarker1);
            Assert.AreEqual(182809, keyEventsData.OpticalReturnLossMarker2);
        }

        [TestMethod()]
        public void KeyParamsDataParseTest2()
        {
            var data = readFile(".\\TestData\\KeyEventsChunks\\2.bin");
            KeyEventsData keyEventsData = new KeyEventsData(data.AsSpan(), 2);
            Assert.AreEqual(2078, keyEventsData.EndToEndLoss);
            Assert.AreEqual(-24640, keyEventsData.EndToEndLossMarker1);
            Assert.AreEqual(187100, keyEventsData.EndToEndLossMarker2);
            List<KeyEventData> keyEvents = new();
            keyEvents.Add(new KeyEventData((ushort)1, (uint)2150, (short)0, (short)-215, (int)-46671, "1", "F", "9999", "LS", (uint)2150, (uint)2150, (uint)2150, (uint)2150, (uint)2150, " "));
            keyEvents.Add(new KeyEventData((ushort)2, (uint)2680, (short)0, (short)374, (int)0, "0", "F", "9999", "LS", (uint)2150, (uint)2680, (uint)2680, (uint)2680, (uint)2680, " "));
            keyEvents.Add(new KeyEventData((ushort)3, (uint)184950, (short)185, (short)1238, (int)0, "1", "F", "9999", "LS", (uint)2680, (uint)184950, (uint)184950, (uint)187100, (uint)184950, " "));
            keyEvents.Add(new KeyEventData((ushort)4, (uint)187100, (short)0, (short)0, (int)-76053, "1", "E", "9999", "LS", (uint)184950, (uint)187100, (uint)187100, (uint)275350, (uint)187100, " "));
           int i = 0;
            foreach (var expectedEvent in keyEvents)
            {
                var actualEvent = keyEventsData.Events[i++];
                Assert.AreEqual<KeyEventData>(expectedEvent, actualEvent);
            }
            Assert.AreEqual(4, keyEventsData.NumberOfEvents);
            Assert.AreEqual(17841, keyEventsData.OpticalReturnLoss);
            Assert.AreEqual(-24640, keyEventsData.OpticalReturnLossMarker1);
            Assert.AreEqual(187100, keyEventsData.OpticalReturnLossMarker2);
        }

        [TestMethod()]
        public void KeyParamsDataParseTest1()
        {
            var data = readFile(".\\TestData\\KeyEventsChunks\\1.bin");
            KeyEventsData keyEventsData = new KeyEventsData(data.AsSpan(), 2);
            Assert.AreEqual(1912, keyEventsData.EndToEndLoss);
            Assert.AreEqual(0, keyEventsData.EndToEndLossMarker1);
            Assert.AreEqual(183062, keyEventsData.EndToEndLossMarker2);
            List<KeyEventData> keyEvents = new();
            keyEvents.Add(new KeyEventData((ushort)1,(uint)0, (short)0, (short)0, (int)-44958, "1","F","9999", "LS", (uint)0, (uint)0,(uint)203,(uint)7359,(uint)47, " "));
            keyEvents.Add(new KeyEventData((ushort)2, (uint)7359, (short)687, (short)652, (int)-34811, "1", "F", "9999", "LS", (uint)203, (uint)7359, (uint)8172, (uint)183062, (uint)7422, " "));
            keyEvents.Add(new KeyEventData((ushort)3, (uint)183062, (short)322, (short)0, (int)-17249, "2", "E", "9999", "LS", (uint)8172, (uint)183062, (uint)189141, (uint)191547, (uint)183125, " "));
            keyEvents.Add(new KeyEventData((ushort)4, (uint)191547, (short)0, (short)0, (int)-57072, "1", "F", "9999", "LS", (uint)189141, (uint)191547, (uint)193297, (uint)358734, (uint)191609, " "));
            keyEvents.Add(new KeyEventData((ushort)5, (uint)358734, (short)0, (short)0, (int)-49856, "1", "F", "9999", "LS", (uint)193297, (uint)358734, (uint)358969, (uint)367266, (uint)358844, " "));
            keyEvents.Add(new KeyEventData((ushort)6, (uint)367266, (short)0, (short)0, (int)-39452, "1", "F", "9999", "LS", (uint)358969, (uint)367266, (uint)367531, (uint)489719, (uint)367328, " "));
            int i = 0;
            foreach (var expectedEvent in keyEvents)
            {
                var actualEvent = keyEventsData.Events[i++];
                Assert.AreEqual<KeyEventData>(expectedEvent, actualEvent);
            }
            Assert.AreEqual(6, keyEventsData.NumberOfEvents);
            Assert.AreEqual(19852, keyEventsData.OpticalReturnLoss);
            Assert.AreEqual(0, keyEventsData.OpticalReturnLossMarker1);
            Assert.AreEqual(183062, keyEventsData.OpticalReturnLossMarker2);
        }
    }
}
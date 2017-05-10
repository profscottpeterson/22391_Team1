using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XAATArcade;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Forms;

namespace XAATArcade.Tests
{
    [TestClass]
    public class MemoryTests
    {
        XAATArcadeTest test = new XAATArcadeTest();
        MemoryTest memoryTest = new MemoryTest();

        [TestMethod]
        public void XAATArcadeMemory()
        {
            test.Memory(true);
            Assert.AreEqual("clicked", test.memoryButtonStatus);
            Assert.IsTrue(test.memoryPlayed, "memoryPlayed");
            Assert.IsTrue(test.removeTitlePage, "removeTitlePage");
        }

        [TestMethod]
        public void MemoryCreate()
        {
            memoryTest.Memory(test, true);
            memoryTest.CreateCards(true);
            Assert.IsTrue(memoryTest.memoryCleared, "memoryCleared");
            Assert.IsTrue(memoryTest.createMemoryStart, "createMemoryStart");
            Assert.AreEqual("2",memoryTest.lblPairsLeft.Text, "lblPairsLeft");
            Assert.AreEqual(4, memoryTest.gridList.Count , "gridList");
            Assert.AreEqual(4, memoryTest.backList.Count, "backList");
            Assert.AreEqual(4, memoryTest.frontList.Count, "frontList");
        }

        [TestMethod]
        public void MemoryIncorrectMatch()
        {
            memoryTest.Memory(test, true);
            memoryTest.CreateCards(true);
            memoryTest.CardSelect(true, memoryTest.backList[0]);
            Assert.AreEqual(1, memoryTest.count, "count");
            memoryTest.CardSelect(true, memoryTest.backList[1]);
            Assert.AreEqual(2, memoryTest.count, "count");
            Assert.IsTrue(memoryTest.noMatch, "noMatch");
        }

        [TestMethod]
        public void MemoryCorrectMatch()
        {
            memoryTest.Memory(test, true);
            memoryTest.CreateCards(true);
            memoryTest.CardSelect(true, memoryTest.backList[1]);
            Assert.AreEqual(1, memoryTest.count, "count");
            memoryTest.CardSelect(true, memoryTest.backList[3]);
            Assert.AreEqual(2, memoryTest.count, "count");
            Assert.AreEqual("1", memoryTest.lblPairsLeft.Text, "lblPairsLeft");
            Assert.IsTrue(memoryTest.match, "match");
        }
        
        [TestMethod]
        public void MemoryBackButton()
        {
            memoryTest.Memory(test, true);
            memoryTest.BackButton(true);
            Assert.IsTrue(memoryTest.memoryCleared, "memoryCleared");
            Assert.IsTrue(memoryTest.form.addTitlePage, "addTitlePage");
            Assert.IsFalse(memoryTest.form.memoryPlayed, "memoryPlayed");
        }
    }
}

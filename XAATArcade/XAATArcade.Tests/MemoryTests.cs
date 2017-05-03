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

    }
}

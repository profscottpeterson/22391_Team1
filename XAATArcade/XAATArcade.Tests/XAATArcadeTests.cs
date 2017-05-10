using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XAATArcade;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Forms;

namespace XAATArcade.Tests
{
    [TestClass]
    public class XAATArcadeTests
    {
        XAATArcadeTest test = new XAATArcadeTest();
        SequenceTest sequenceTest = new SequenceTest();
        MemoryTest memoryTest = new MemoryTest();

        [TestMethod]
        public void XAATArcadeLoad()
        {
            test.XAATArcade_Load(true);
            Assert.IsTrue(test.createTitlePage, "createTitlePage");
            Assert.IsTrue(test.createConfig, "createConfig");
            Assert.IsTrue(test.backgroundSound, "backgroundSound");
        }

        [TestMethod]
        public void XAATArcadeMemoryHover()
        {
            test.MemoryHover(true);
            Assert.AreEqual("enter", test.memoryButtonStatus, "memoryButtonStatus");
        }

        [TestMethod]
        public void XAATArcadeMemoryLeave()
        {
            test.MemoryMouseLeave(true);
            Assert.AreEqual("leave", test.memoryButtonStatus, "memoryButtonStatus");
        }

        [TestMethod]
        public void XAATArcadeSequenceHover()
        {
            test.SequenceHover(true);
            Assert.AreEqual("enter", test.sequenceButtonStatus, "sequenceButtonStatus");
        }

        [TestMethod]
        public void XAATArcadeSequenceLeave()
        {
            test.SequenceMouseLeave(true);
            Assert.AreEqual("leave", test.sequenceButtonStatus, "sequenceButtonStatus");
        }

        [TestMethod]
        public void XAATArcadeReflex()
        {
            test.Reflex(true);
            Assert.AreEqual("clicked", test.reflexButtonStatus, "reflexButtonStatus");
        }

        [TestMethod]
        public void XAATArcadeReflexHover()
        {
            test.ReflexHover(true);
            Assert.AreEqual("enter", test.reflexButtonStatus, "reflexButtonStatus");
        }

        [TestMethod]
        public void XAATArcadeReflexLeave()
        {
            test.ReflexMouseLeave(true);
            Assert.AreEqual("leave", test.reflexButtonStatus, "reflexButtonStatus");
        }

        [TestMethod]
        public void XAATArcadeOpenConfig()
        {
            test.OpenConfig(true);
            Assert.IsTrue(test.openConfig, "openConfig");
        }

        [TestMethod]
        public void XAATArcadeChangeBackgroundColor()
        {
            test.ChangeBackColor(true);
            Assert.IsTrue(test.changeBackgroundColor, "changeBackgroundColor");
        }


        [TestMethod]
        public void XAATArcadeTurnButtonSoundOff()
        {
            test.TurnButtonSoundOff(true);
            Assert.IsFalse(test.buttonSoundOn, "buttonSoundOn");
        }

        [TestMethod]
        public void XAATArcadeTurnButtonSoundOn()
        {
            test.TurnButtonSoundOn(true);
            Assert.IsTrue(test.buttonSoundOn, "buttonSoundOn");
        }

        [TestMethod]
        public void XAATArcadePlaySound()
        {
            test.PlaySound(true);
            Assert.IsTrue(test.buttonSound, "buttonSound");
        }


        [TestMethod]
        public void XAATArcadeTurnBackgroundSoundOff()
        {
            test.TurnBackgroundSoundOff(true);
            Assert.IsFalse(test.backgroundSoundOn, "backgroundSoundOn");
            Assert.IsFalse(test.backgroundSound, "backgroundSound");
        }
        
        [TestMethod]
        public void XAATArcadeTurnBackgroundSoundOn()
        {
            test.TurnBackgroundSoundOn(true);
            Assert.IsTrue(test.backgroundSoundOn, "backgroundSoundOn");
            Assert.IsTrue(test.backgroundSound, "backgroundSound");
        }

        [TestMethod]
        public void XAATArcadeCloseConfig()
        {
            test.CloseConfig(true);
            Assert.IsTrue(test.closeConfig, "closeConfig");
        }

        [TestMethod]
        public void XAATArcadeClose()
        {
            test.XAATArcade_FormClosed(true);
            Assert.IsTrue(test.closeForm, "closeForm");
        }
    }
}

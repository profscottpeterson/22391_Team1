using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XAATArcade;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Forms;

namespace XAATArcade.Tests
{
    [TestClass]
    public class SequenceTests
    {
        XAATArcadeTest test = new XAATArcadeTest();
        SequenceTest sequenceTest = new SequenceTest();

        [TestMethod]
        public void XAATArcadeSequence()
        {
            test.Sequence(true);
            Assert.AreEqual("clicked", test.sequenceButtonStatus);
            Assert.IsTrue(test.sequencePlayed, "sequencePlayed");
            Assert.IsTrue(test.removeTitlePage, "removeTitlePage");

        }




        [TestMethod]
        public void SequenceBackButton()
        {
            sequenceTest.Sequence(test, true);
            sequenceTest.BackButton(true);
            Assert.IsTrue(sequenceTest.sequenceCleared, "sequenceCleared");
            Assert.IsTrue(sequenceTest.form.addTitlePage, "addTitlePage");
            Assert.IsFalse(sequenceTest.form.sequencePlayed, "sequencePlayed");
        }
    }
}

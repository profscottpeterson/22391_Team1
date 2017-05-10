using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace XAATArcade.Tests
{
    [TestClass]
    public class SequenceTests
    {
        XAATArcadeTest test = new XAATArcadeTest();
        SequenceTest sequenceTest = new SequenceTest();
        Panel testPanel = new Panel();
        Panel testPanel2 = new Panel();

        [TestMethod]
        public void XAATArcadeSequence()
        {
            test.Sequence(true);
            Assert.AreEqual("clicked", test.sequenceButtonStatus);
            Assert.IsTrue(test.sequencePlayed, "sequencePlayed");
            Assert.IsTrue(test.removeTitlePage, "removeTitlePage");
        }

        [TestMethod]
        public void SequenceCreate()
        {
            sequenceTest.Sequence(test, true);
            Assert.IsTrue(sequenceTest.createSequenceStart, "createSequenceStart");
            Assert.AreEqual("0", sequenceTest.lblScore.Text);
        }

        [TestMethod]
        public void SequencePanelHover()
        {
            sequenceTest.Sequence(test, true);
            testPanel.Name = "1 , 1";
            sequenceTest.gridList.Add(testPanel);
            sequenceTest.PanelHover(true, testPanel);
            Assert.AreEqual("enter", sequenceTest.panelStatus, "panelStatus");
        }

        [TestMethod]
        public void SequencePanelLeave()
        {
            sequenceTest.Sequence(test, true);
            testPanel.Name = "1 , 1";
            sequenceTest.gridList.Add(testPanel);
            sequenceTest.PanelLeave(true, testPanel);
            Assert.AreEqual("leave", sequenceTest.panelStatus, "panelStatus");
        }

        [TestMethod]
        public void SequenceStart()
        {
            testPanel.Name = "1 , 1";
            testPanel2.Name = "2 , 2";
            sequenceTest.Sequence(test, true);
            sequenceTest.SequenceStart(true, testPanel);
            Assert.IsTrue(sequenceTest.createSequenceStart, "createSequenceStart");
            Assert.AreEqual("0", sequenceTest.lblScore.Text, "lblScore");
            Assert.AreEqual(testPanel.Name, sequenceTest.testList[0].Name, "testList");
            sequenceTest.SequenceSelect(true, testPanel, testPanel2);
            Assert.IsFalse(sequenceTest.error, "error");
            Assert.AreEqual("1", sequenceTest.lblScore.Text, "lblScore");
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

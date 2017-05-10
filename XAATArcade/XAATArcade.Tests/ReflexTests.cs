using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XAATArcade;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Forms;
using targetPractice;
using System.Drawing;

namespace XAATArcade.Tests
{
    [TestClass]
    public class ReflexTests
    {
        tpTest test = new tpTest();
               
        [TestMethod]
        public void ReflexResetGameTest()
        {
            test.ResetGameTest();
            Assert.AreEqual(test.ballListTest.Count, 0);
            Assert.AreEqual(test.ballVelocityTest.Count, 0);
            Assert.AreEqual(test.ballIsGrowingTest.Count, 0);
            Assert.IsTrue(test.btnStartTest.Enabled == true);
            Assert.IsTrue(test.btnStartTest.Visible == true);
            Assert.AreEqual(test.num_Balls_HitTest, 0);
            Assert.AreEqual(test.num_Balls_MissedTest, 0);
            Assert.IsTrue(test.pnlGameOverTest.Enabled == false);
            Assert.IsTrue(test.pnlGameOverTest.Visible == false);
        }

        [TestMethod]
        public void ReflexCheckForHitTest()
        {
            test.MakeBallTest();
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 1, 10, 10, 0);
            test.CheckForHitTest(e);
            Assert.AreEqual(test.ballListTest.Count, 0);
            Assert.AreEqual(test.ballVelocityTest.Count, 0);
            Assert.AreEqual(test.ballIsGrowingTest.Count, 0);
            Assert.AreEqual(test.num_Balls_HitTest, 1);
        }

        [TestMethod]
        public void ReflexCheckForMissTest()
        {
            test.MakeBallTest();
            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 1, 300, 300, 0);
            test.CheckForHitTest(e);
            Assert.AreEqual(test.ballListTest.Count, 1);
            Assert.AreEqual(test.ballVelocityTest.Count, 1);
            Assert.AreEqual(test.ballIsGrowingTest.Count, 1);
            Assert.IsTrue(test.pbLife1.Visible == false);
            Assert.AreEqual(test.ballIsGrowingTest.Count, 1);
            Assert.AreEqual(test.num_Balls_MissedTest, 1);
        }

        [TestMethod]
        public void ReflexStopTimersTest()
        {
            test.StartTimersTest();
            Assert.IsTrue(test.tBallGeneratorTest.Enabled == true);
            Assert.IsTrue(test.tBallMovementTest.Enabled == true);
            Assert.IsTrue(test.tBallSizeChangerTest.Enabled == true);
        }

        [TestMethod]
        public void ReflexStartTimersTest()
        {
            test.StartTimersTest();
            test.StopTimersTest();
            Assert.IsTrue(test.tBallGeneratorTest.Enabled == false);
            Assert.IsTrue(test.tBallMovementTest.Enabled == false);
            Assert.IsTrue(test.tBallSizeChangerTest.Enabled == false);
        }

        [TestMethod]
        public void ReflexShowStartBtnTest()
        {
            test.HideStartBtnTest();
            test.ShowStartBtnTest();
            Assert.IsTrue(test.btnStartTest.Enabled == true);
            Assert.IsTrue(test.btnStartTest.Visible == true);
        }

        [TestMethod]
        public void ReflexHideStartBtnTest()
        {
            test.ShowStartBtnTest();
            test.HideStartBtnTest();
            Assert.IsTrue(test.btnStartTest.Enabled == false);
            Assert.IsTrue(test.btnStartTest.Visible == false);
        }

        [TestMethod]
        public void ReflexShowOptionsTest()
        {
            test.HideOptionsTest();
            test.ShowOptionsTest();
            Assert.IsTrue(test.pnlOptoinsMenuTest.Enabled == true);
            Assert.IsTrue(test.pnlOptoinsMenuTest.Visible == true);
        }

        [TestMethod]
        public void ReflexHideOptionsTest()
        {
            test.ShowOptionsTest();
            test.HideOptionsTest();
            Assert.IsTrue(test.pnlOptoinsMenuTest.Enabled == false);
            Assert.IsTrue(test.pnlOptoinsMenuTest.Visible == false);
        }

        [TestMethod]
        public void ReflexShowGameOverTest()
        {
            test.HideGameOverTest();
            test.ShowGameOverTest();
            Assert.IsTrue(test.pnlGameOverTest.Enabled == true);
            Assert.IsTrue(test.pnlGameOverTest.Visible == true);
        }

        [TestMethod]
        public void ReflexHideGameOverTest()
        {
            test.ShowGameOverTest();
            test.HideGameOverTest();
            Assert.IsTrue(test.pnlGameOverTest.Enabled == false);
            Assert.IsTrue(test.pnlGameOverTest.Visible == false);
        }

        [TestMethod]
        public void ReflexMakeBallTest()
        {
            test.MakeBallTest();
            Assert.AreEqual(test.ballListTest.Count, 1);
            Assert.AreEqual(test.ballVelocityTest.Count, 1);
            Assert.AreEqual(test.ballIsGrowingTest.Count, 1);
        }

        [TestMethod]
        public void ReflexMoveBallTest()
        {
            Rectangle test1 = new Rectangle(11, 11, 18, 18);
            Rectangle test2 = new Rectangle(12, 12, 18, 18);
            test.MakeBallTest();
            test.MoveBallTest();
            Assert.AreEqual(test.ballListTest[0], test1);
            test.MoveBallTest();
            Assert.AreEqual(test.ballListTest[0], test2);
        }

        [TestMethod]
        public void ReflexRemoveLifeTest()
        {
            test.RemoveLifeTest();
            Assert.AreEqual(test.gameLives, 0);
            Assert.IsTrue(test.pbLife1.Visible == false);

        }

        [TestMethod]
        public void ReflexRestockLivesTest()
        {
            test.RestockLivesTest();
            Assert.AreEqual(test.gameLives, 3);
            Assert.IsTrue(test.pbLife1.Visible == true);
        }

        [TestMethod]
        public void ReflexTargetResizerTest()
        {
            test.MakeBallTest();
            test.TargetResizerTest();
            Rectangle test1 = new Rectangle(10, 10, 19, 19);
            Rectangle test2 = new Rectangle(10, 10, 20, 20);
            Assert.AreEqual(test.ballListTest[0], test1);
            test.TargetResizerTest();
            Assert.AreEqual(test.ballListTest[0], test2);
        }

        [TestMethod]
        public void ReflexTargetDrawerTest()
        {
            test.MakeBallTest();
            test.TargetDrawerTest();
            Assert.IsTrue(test.c.SmoothingMode == System.Drawing.Drawing2D.SmoothingMode.AntiAlias);
            Assert.IsTrue(test.c.IsClipEmpty == false);
        }
    }
}

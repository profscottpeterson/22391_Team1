﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XAATArcade;
using System.Windows.Input;
using System.ComponentModel;

namespace XAATArcade.Tests
{
    [TestClass]
    public class XAATArcadeTests
    {
        XAATArcade main = new XAATArcade();
        
        
        
        
        [TestMethod]
        public void MemoryStartTimer()
        {
            Memory memory = new Memory(main, main.Size);



        }

        [TestMethod]
        public void MemoryStopTimer()
        {

        }

        [TestMethod]
        public void Sequence()
        {
            Sequence sequence = new Sequence(main, main.Size);
            //sequence.PlaySound() += delegate ();

            //sequence.SequenceStart(object sender, EventArgs e);

           


           // main.sequence.ClearSequence


        }



    }
}
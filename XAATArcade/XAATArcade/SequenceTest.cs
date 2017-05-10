using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace XAATArcade
{
    public class SequenceTest
    {
        public Panel pnlGrid = new Panel();
        public int x = 90;
        public int y = 65;
        public Label lblScore = new Label();
        public List<Panel> gridList = new List<Panel>();
        public  List<Panel> sequenceList = new List<Panel>();
        public List<Panel> clickedList = new List<Panel>();
        public Random rand = new Random();
        public bool error = false;
        public XAATArcadeTest form;
        public bool sequenceCleared;
        public bool createSequenceStart;
        public string panelStatus;
        public string gameStatus;
        public List<Panel> testList = new List<Panel>();

        public void Sequence(XAATArcadeTest parent, bool sequenceButton)
        {
            form = parent;
            CreateSequenceStart();
        }

        public void CreateSequenceStart()
        {
            lblScore = new Label();
            lblScore.Text = "0";

            for (int row = 0; row <= 2; row++)
            {
                for (int column = 0; column <= 2; column++)
                {
                    pnlGrid = new Panel();
                    pnlGrid.Name = row + " , " + column;
                    gridList.Add(pnlGrid);
                }
            }
            createSequenceStart = true;
        }

        public void SequenceStart(bool sequenceStartButton, Panel p)
        {
            if (sequenceStartButton == true)
            {
                if (sequenceList.Count > 0)
                {
                    ClearSequence();
                    CreateSequenceStart();
                    error = false;
                }
                testList = StartSequence(p);
            }
        }

        public void PanelHover(bool panelButton, Panel panelClicked)
        {
            if (panelButton == true)
            {
                foreach (Panel p in gridList)
                {
                    if (panelClicked == p)
                    {
                        panelStatus = "enter";
                    }
                }
            }
        }

        public void PanelLeave(bool panelButton, Panel panelClicked)
        {
            if (panelButton == true)
            foreach (Panel p in gridList)
            {
                if (panelClicked == p)
                {
                        panelStatus = "leave";
                }
            }
        }

        public List<Panel> StartSequence(Panel p)
        {
            lblScore.Text = sequenceList.Count().ToString();
            sequenceList.Add(p);

            if (error == false)
            {
                return sequenceList;
            }
            else
                return null;
        }

        public void SequenceSelect(bool panelButton, Panel panelClicked, Panel p)
        {
            if (panelButton == true)
            {
                clickedList.Add(panelClicked);

                if (clickedList.Count == sequenceList.Count)
                {
                    CheckSequence(p);
                }
            }
        }

        public void CheckSequence(Panel p)
        {
            for (int i = 0; i < clickedList.Count; i++)
            {
                if (clickedList[i] != sequenceList[i])
                {
                    error = true;
                    gameStatus = "Game Over. New game will start.";
                    break;
                }
            }
            if (error == false)
            {
                StartSequence(p);
            }
            else
            {
                ClearSequence();
                CreateSequenceStart();
                error = false;
                StartSequence(p);
            }
        }

        public void ClearSequence()
        {
            sequenceList.Clear();
            gridList.Clear();
            clickedList.Clear();
            sequenceCleared = true;
        }

        public void BackButton(bool sequenceBackButton)
        {
            if (sequenceBackButton == true)
            {
                ClearSequence();
                form.AddTitlePage();
                form.sequencePlayed = false;
            }
        }
    }
}

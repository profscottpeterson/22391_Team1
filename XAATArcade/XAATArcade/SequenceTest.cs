using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
        public List<Panel> pickedList = new List<Panel>();
        public List<Panel> clickedList = new List<Panel>();
        public Random rand = new Random();
        public bool error = false;
        public XAATArcadeTest form;


        public bool sequenceCleared;
        public bool createSequenceStart;
        public string panelStatus;
        public string gameStatus;

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

        public void SequenceStart(bool sequenceStartButton)
        {
            if (sequenceStartButton == true)
            {
                if (sequenceList.Count > 0)
                {
                    ClearSequence();
                    CreateSequenceStart();
                    error = false;
                }
                StartSequence();
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

        public async Task StartSequence()
        {
            lblScore.Text = sequenceList.Count().ToString();
            sequenceList.Add(gridList[rand.Next(gridList.Count)]);

            if (error == false)
            {
                if (sequenceList.Count > 0)
                {
                    foreach (Panel p in sequenceList)
                    {
                        p.Enabled = false;
                    }
                    foreach (Panel p in sequenceList)
                    {
                        pickedList.Add(p);
                        Color color = p.BackColor;
                        await Task.Delay(1000);
                        p.BackColor = Color.Black;
                        p.BackgroundImage = Properties.Resources.sequencesquareHover;
                        await Task.Delay(300);
                        p.BackColor = color;
                        p.BackgroundImage = Properties.Resources.sequenceBoarder;
                    }
                    foreach (Panel p in sequenceList)
                    {
                        p.Enabled = true;
                    }
                }
            }
        }

        public void SequenceSelect(bool panelButton, Panel panelClicked)
        {
            if (panelButton == true)
            {
                Panel clickedSquare = (Panel)panelClicked;
                clickedList.Add(clickedSquare);

                if (clickedList.Count == pickedList.Count)
                {
                    CheckSequence();
                }
            }
        }

        public async Task CheckSequence()
        {
            for (int i = 0; i < clickedList.Count; i++)
            {
                if (clickedList[i] != pickedList[i])
                {
                    error = true;
                    gameStatus = "Game Over. New game will start.";
                    break;
                }
            }
            if (error == false)
            {
                await StartSequence();
            }
            else
            {
                ClearSequence();
                CreateSequenceStart();
                error = false;
                await StartSequence();
            }
        }

        public void ClearSequence()
        {
            sequenceList.Clear();
            gridList.Clear();
            clickedList.Clear();
            pickedList.Clear();
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

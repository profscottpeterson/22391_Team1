using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace XAATArcade
{
    public class MemoryTest
    {
        Button btnCardBacks = new Button();
        Panel pnlGrid = new Panel();
        Point pt = new Point(0, 0);
        int width = 70;
        int height = 110;
        int x = 61;
        int y = 65;
        public Label lblPairsLeft = new Label();
        public List<Control> frontList = new List<Control>();
        public List<Panel> gridList = new List<Panel>();
        public List<Button> backList = new List<Button>();
        public List<Panel> matchList = new List<Panel>();
        public List<Button> matchBackList = new List<Button>();
        public XAATArcadeTest form;
        public bool memoryCleared;
        public bool createMemoryStart;
        public int count;
        public bool noMatch;
        public bool match;

        public void Memory(XAATArcadeTest parent, bool memoryButton)
        {
            form = parent;
            CreateMemoryStart();
        }

        public void CreateMemoryStart()
        {
            lblPairsLeft = new Label();
            createMemoryStart = true;
        }

        public void CreateCards(bool clickedCreatCardsButton)
        {
            if (clickedCreatCardsButton == true)
            {
                ClearMemory();
                CreateMemoryStart();

                lblPairsLeft.Text = "2";
                for (int row = 0; row <= 1; row++)
                {
                    for (int column = 0; column <= 1; column++)
                    {
                        pnlGrid = new Panel();
                        pnlGrid.Location = new Point(x + (column * (width + 5)), y + (row * (height + 5)));
                        pnlGrid.Name = row + " , " + column;
                        gridList.Add(pnlGrid);

                        btnCardBacks = new Button();
                        btnCardBacks.Location = new Point(x + (column * (width + 5)), y + (row * (height + 5)));
                        btnCardBacks.Name = row + " , " + column;
                        backList.Add(btnCardBacks);
                    }
                }

                PictureBox pbCard1 = new PictureBox();
                PictureBox pbCard2 = new PictureBox();
                PictureBox pbCard3 = new PictureBox();
                PictureBox pbCard4 = new PictureBox();

                pbCard1.Name = "bowAndArrow";
                pbCard1.Size = new Size(1,1);
                frontList.Add(pbCard1);

                pbCard2.Name = "circle";
                pbCard2.Size = new Size(1, 1);
                frontList.Add(pbCard2);

                pbCard3.Name = "bowAndArrow";
                pbCard3.Size = new Size(1, 1);
                frontList.Add(pbCard3);

                pbCard4.Name = "circle";
                pbCard4.Size = new Size(1, 1);
                frontList.Add(pbCard4);

                for (int i = 0; i < gridList.Count; i++)
                {
                    gridList[i].Controls.Add(frontList[i]);
                }
            }
        }

        public void CardSelect(bool cardSelected, Button clickedBack)
        {
            if (cardSelected == true)
            {
                count = 0;
                foreach (Button b in backList)
                {
                    if (b.Visible == false)
                    {
                        count++;
                    }
                }
                if (count <= 1)
                {
                    clickedBack.Visible = false;
                    count++;
                    if (count == 2)
                    {
                        CardCheck();
                    }
                }
            }
        }

        public void CardCheck()
        {
            foreach (Button b in backList)
            {
                if (b.Visible == false)
                {
                    matchBackList.Add(b);
                    foreach (Panel p in gridList)
                    {
                        if (b.Location == p.Location)
                        {
                            matchList.Add(p);
                            break;
                        }
                    }
                }
            }

            if (matchList.Count > 0)
            {
                if (matchList[0].GetChildAtPoint(pt).Name == matchList[1].GetChildAtPoint(pt).Name)
                {
                    backList.Remove(matchBackList[1]);
                    backList.Remove(matchBackList[0]);
                    matchBackList[1].Dispose();
                    matchBackList[0].Dispose();
                    matchBackList.Clear();
                    gridList.Remove(matchList[1]);
                    gridList.Remove(matchList[0]);
                    frontList.Remove(matchList[1].GetChildAtPoint(pt));
                    frontList.Remove(matchList[0].GetChildAtPoint(pt));
                    matchList[1].Dispose();
                    matchList[0].Dispose();
                    matchList.Clear();
                    lblPairsLeft.Text = (frontList.Count / 2).ToString();
                    match = true;
                }
                else
                {
                    matchBackList[1].Visible = true;
                    matchBackList[0].Visible = true;
                    matchBackList.Clear();
                    matchList.Clear();
                    noMatch = true;

                }
            }
        }

        public void ClearMemory()
        {
            frontList.Clear();
            gridList.Clear();
            backList.Clear();
            matchList.Clear();
            matchBackList.Clear();
            memoryCleared = true;
        }

        public void BackButton(bool backButtonclicked)
        {
            if (backButtonclicked == true)
            {
                ClearMemory();
                form.AddTitlePage();
                form.memoryPlayed = false;
            }
        }
    }
}

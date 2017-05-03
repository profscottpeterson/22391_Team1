using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace XAATArcade
{
    public class MemoryTest
    {
            Button btnCardBacks = new Button();
            Panel pnlGrid = new Panel();
            int width = 70;
            int height = 110;
            int x = 61;
            int y = 65;
            Point pt = new Point(0, 0);
            Label lblPairsLeft = new Label();
            Label lblGameOver = new Label();
            List<Control> frontList = new List<Control>();
            List<Panel> gridList = new List<Panel>();
            List<Button> backList = new List<Button>();
            List<Panel> matchList = new List<Panel>();
            List<Button> matchBackList = new List<Button>();
            Random rand = new Random();
            Label lblMatchesLeft = new Label();
            private XAATArcadeTest form;
            public void Memory(XAATArcadeTest parent, bool memoryButton)
            {
                form = parent;
                CreateMemoryStart();
            }


            public void CreateMemoryStart()
            {
                lblPairsLeft = new Label();
                lblGameOver = new Label();
                lblGameOver.Text = "GAME OVER";
            }

        public void CreateCards(bool clickedCreatCardsButton)
            {
                ClearMemory();
                CreateMemoryStart();

                lblPairsLeft.Text = "10";
                for (int row = 0; row <= 3; row++)
                {
                    for (int column = 0; column <= 4; column++)
                    {
                        pnlGrid = new Panel();
                        pnlGrid.Name = row + " , " + column;
                        gridList.Add(pnlGrid);

                        btnCardBacks = new Button();
                        btnCardBacks.Name = row + " , " + column;
                        backList.Add(btnCardBacks);
                    }
                }

                foreach (Button x in backList)
                {
                    x.BringToFront();
                }
                //Setting up the different picture boxes
                PictureBox pbCard1 = new PictureBox();
                PictureBox pbCard2 = new PictureBox();
                PictureBox pbCard3 = new PictureBox();
                PictureBox pbCard4 = new PictureBox();
                PictureBox pbCard5 = new PictureBox();
                PictureBox pbCard6 = new PictureBox();
                PictureBox pbCard7 = new PictureBox();
                PictureBox pbCard8 = new PictureBox();
                PictureBox pbCard9 = new PictureBox();
                PictureBox pbCard10 = new PictureBox();
                PictureBox pbCard11 = new PictureBox();
                PictureBox pbCard12 = new PictureBox();
                PictureBox pbCard13 = new PictureBox();
                PictureBox pbCard14 = new PictureBox();
                PictureBox pbCard15 = new PictureBox();
                PictureBox pbCard16 = new PictureBox();
                PictureBox pbCard17 = new PictureBox();
                PictureBox pbCard18 = new PictureBox();
                PictureBox pbCard19 = new PictureBox();
                PictureBox pbCard20 = new PictureBox();

                pbCard1.Name = "bowAndArrow";
                frontList.Add(pbCard1);
            
                pbCard2.Name = "circle";
                frontList.Add(pbCard2);

                pbCard3.Name = "diamond";
                frontList.Add(pbCard3);
            
                pbCard4.Name = "heart";
                frontList.Add(pbCard4);
            
                pbCard5.Name = "knife";
                frontList.Add(pbCard5);
            
                pbCard6.Name = "lightning";
                frontList.Add(pbCard6);
            
                pbCard7.Name = "rectangle";
                frontList.Add(pbCard7);
            
                pbCard8.Name = "shield";
                frontList.Add(pbCard8);
            
                pbCard9.Name = "shurikin";
                frontList.Add(pbCard9);
            
                pbCard10.Name = "star";
                frontList.Add(pbCard10);
            
                pbCard11.Name = "bowAndArrow";
                frontList.Add(pbCard11);
            
                pbCard12.Name = "circle";
                frontList.Add(pbCard12);
            
                pbCard13.Name = "diamond";
                frontList.Add(pbCard13);
            
                pbCard14.Name = "heart";
                frontList.Add(pbCard14);
            
                pbCard15.Name = "knife";
                frontList.Add(pbCard15);
            
                pbCard16.Name = "lightning";
                frontList.Add(pbCard16);
            
                pbCard17.Name = "rectangle";
                frontList.Add(pbCard17);
            
                pbCard18.Name = "shield";
                frontList.Add(pbCard18);
            
                pbCard19.Name = "shurikin";
                frontList.Add(pbCard19);
            
                pbCard20.Name = "star";
                frontList.Add(pbCard20);

                List<int> indexList = new List<int>();
                while (indexList.Count < 20)
                {
                    int index = rand.Next(gridList.Count);
                    if (indexList.Count == 0 || !indexList.Contains(index))
                    {
                        indexList.Add(index);
                    }
                }

                for (int i = 0; i < indexList.Count; i++)
                {
                    int randomIndex = indexList[i];
                    gridList[randomIndex].Controls.Add(frontList[i]);
                }

            }

        public void GameOver()
            {
                lblGameOver.BringToFront();
                lblGameOver.Visible = true;

                foreach (Button b in backList)
                {
                    b.Enabled = false;
                }
            }
        //Method for when a card is selected, it checks the cards and makes the image visiable
        public void CardSelect(object sender, EventArgs e)
            {
                Button clickedBack = (Button)sender;
                int count = 0;

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
            //
            public async Task CardCheck()
            {
                await Task.Delay(250);
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
                //if the list of match is > 0 remove and dispose from the matchlist
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
                    }
                    else
                    {
                        matchBackList[1].Visible = true;
                        matchBackList[0].Visible = true;
                        matchBackList.Clear();
                        matchList.Clear();
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

            }

        public void BackButton(bool backButtonclicked)
            {
                ClearMemory();
                form.AddTitlePage();
                form.memoryPlayed = false;
            }



        }
}

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
/// <summary>
/// Memory game, makes cards out of picture boxes.  On click, flips the cards and then checks if they are the same
/// if they are, deletes the picture boxes.  If not, Flips them over again
/// </summary>
namespace XAATArcade
{
    class Memory
    {
        //Button Assembly Code
        Button btnMemoryStart = new Button();
        Button btnBack = new Button();
        Button btnCardBacks = new Button();
        Panel pnlGrid = new Panel();
        int width = 70;
        int height = 110;
        int x = 61;
        int y = 65;
        Point pt = new Point(0, 0);
        Label lblPairsLeft = new Label();
        Label lblTimer = new Label();
        Label lblPairsLeftDesc = new Label();
        Label lblTimerDesc = new Label();
        Label lblGameOver = new Label();
        //Group of lists
        List<Control> frontList = new List<Control>();
        List<Panel> gridList = new List<Panel>();
        List<Button> backList = new List<Button>();
        List<Panel> matchList = new List<Panel>();
        List<Button> matchBackList = new List<Button>();
        //Random number Assembly for matching list
        Random rand = new Random();
        Size formSize;
        Label lblMatchesLeft = new Label();
        public System.Timers.Timer t = new System.Timers.Timer();
        int h, m, s;
        private XAATArcade form;
        //Memory game Assembly method
        public Memory(XAATArcade parent, Size parentSize)
        {
            form = parent;
            formSize = parentSize;
            CreateMemoryStart();
        }
        //Import font
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        Font font;
        Font fontGo;
        FontFamily ff;
        //Method to set fonts and buttons most noteably the start and back buttons dynamicly
        public void CreateMemoryStart()
        {
            byte[] fontArray = Properties.Resources._8_BITWONDER;
            int dataLength = Properties.Resources._8_BITWONDER.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFont = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFont);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];

            font = new Font(ff, 5f, FontStyle.Regular);
            fontGo = new Font(ff, 10f, FontStyle.Regular);

            btnBack = new Button();
            btnBack.Location = new Point((formSize.Width - formSize.Width) + 1, (formSize.Height - formSize.Height) + 1);
            btnBack.Size = new Size(50, 50);
            btnBack.Text = "Back";
            btnBack.Click += (s, z) => { BackButton(s, z); };
            btnBack.MouseDown += (s, z) => { form.PlaySound(s, z); };
            btnBack.BackColor = Color.Blue;
            btnBack.ForeColor = Color.White;
            form.Controls.Add(btnBack);
            btnBack.Font = font;

            btnMemoryStart = new Button();
            btnMemoryStart.Location = new Point(formSize.Width - 51, (formSize.Height - formSize.Height) + 1);
            btnMemoryStart.Size = new Size(50, 50);
            btnMemoryStart.Text = "New Game";
            btnMemoryStart.Click += (s, z) => { CreateCards(s, z); };
            btnMemoryStart.MouseDown += (s, z) => { form.PlaySound(s, z); };
            btnMemoryStart.BackColor = Color.Blue;
            btnMemoryStart.Font = font;
            btnMemoryStart.ForeColor = Color.White;
            form.Controls.Add(btnMemoryStart);

            lblPairsLeftDesc = new Label();
            lblPairsLeftDesc.Location = new Point(formSize.Width - 202, (formSize.Height - formSize.Height) + 11);
            lblPairsLeftDesc.Size = new Size(50, 150);
            lblPairsLeftDesc.ForeColor = Color.White;
            lblPairsLeftDesc.AutoSize = true;
            lblPairsLeftDesc.Font = new Font(ff, 10f, FontStyle.Regular);
            lblPairsLeftDesc.Text = "Pairs Left: ";
            form.Controls.Add(lblPairsLeftDesc);

            lblPairsLeft = new Label();
            lblPairsLeft.Location = new Point(formSize.Width - 152, (formSize.Height - formSize.Height) + 31);
            lblPairsLeft.Size = new Size(30, 30);
            lblPairsLeft.ForeColor = Color.White;
            lblPairsLeft.Font = new Font(ff, 10f, FontStyle.Regular);
            form.Controls.Add(lblPairsLeft);

            lblTimerDesc = new Label();
            lblTimerDesc.Location = new Point(formSize.Width - 430, (formSize.Height - formSize.Height) + 11);
            lblTimerDesc.Size = new Size(50, 150);
            lblTimerDesc.ForeColor = Color.White;
            lblTimerDesc.AutoSize = true;
            lblTimerDesc.Font = new Font(ff, 10f, FontStyle.Regular);
            lblTimerDesc.Text = "Remaining Time: ";
            form.Controls.Add(lblTimerDesc);

            lblTimer = new Label();
            lblTimer.Location = new Point(formSize.Width - 382, (formSize.Height - formSize.Height) + 31);
            lblTimer.Size = new Size(50, 150);
            lblTimer.ForeColor = Color.White;
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font(ff, 10f, FontStyle.Regular);
            form.Controls.Add(lblTimer);

            lblGameOver = new Label();
            lblGameOver.Location = new Point(formSize.Width - (formSize.Width / 2) - 50, formSize.Height - (formSize.Height / 2) - 50);
            lblGameOver.Size = new Size(100, 100);
            lblGameOver.BackColor = Color.Blue;
            lblGameOver.ForeColor = Color.White;
            lblGameOver.Text = "GAME OVER";
            lblGameOver.Font = fontGo;
            
            lblGameOver.TextAlign = ContentAlignment.MiddleCenter;
            lblGameOver.Visible = false;
            form.Controls.Add(lblGameOver);

            h = 0;
            m = 0;
            s = 0;
        }
        //Starts the timer and start button after clearing the memory game
        public void CreateCards(object sender, EventArgs e)
        {
            ClearMemory();
            CreateMemoryStart();

            t = new System.Timers.Timer();
            t.Interval = 10;
            t.Elapsed += OnTimeEvent;
            t.Stop();
            t.Start();
            //makes the panels for the cards
            lblPairsLeft.Text = "10";
            for (int row = 0; row <= 3; row++)
            {
                for (int column = 0; column <= 4; column++)
                {
                    pnlGrid = new Panel();
                    pnlGrid.Location = new Point(x + (column * (width + 5)), y + (row * (height + 5)));
                    pnlGrid.Size = new Size(width, height);
                    pnlGrid.Name = row + " , " + column;
                    gridList.Add(pnlGrid);
                    form.Controls.Add(pnlGrid);

                    btnCardBacks = new Button();
                    btnCardBacks.Location = new Point(x + (column * (width + 5)), y + (row * (height + 5)));
                    btnCardBacks.Size = new Size(width, height);
                    btnCardBacks.Name = row + " , " + column;
                    btnCardBacks.Visible = true;
                    btnCardBacks.BackgroundImage = Properties.Resources.back4;
                    backList.Add(btnCardBacks);
                    btnCardBacks.Click += (s, z) => { CardSelect(s, z); };
                    btnCardBacks.MouseDown += (s, z) => { form.PlaySound(s, z); };
                    form.Controls.Add(btnCardBacks);
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
            //Different image files for each of the cards
            pbCard1.Image = Properties.Resources.bowAndArrow;
            pbCard1.Name = "bowAndArrow";
            pbCard1.Size = new Size(width, height);
            frontList.Add(pbCard1);

            pbCard2.Image = Properties.Resources.boot;
            pbCard2.Name = "boot";
            pbCard2.Size = new Size(width, height);
            frontList.Add(pbCard2);
            
            pbCard3.Image = Properties.Resources.helm;
            pbCard3.Name = "helm";
            pbCard3.Size = new Size(width, height);
            frontList.Add(pbCard3);

            pbCard4.Image = Properties.Resources.lance;
            pbCard4.Name = "lance";
            pbCard4.Size = new Size(width, height);
            frontList.Add(pbCard4);

            pbCard5.Image = Properties.Resources.knife;
            pbCard5.Name = "knife";
            pbCard5.Size = new Size(width, height);
            frontList.Add(pbCard5);

            pbCard6.Image = Properties.Resources.scimitar;
            pbCard6.Name = "scimitar";
            pbCard6.Size = new Size(width, height);
            frontList.Add(pbCard6);

            pbCard7.Image = Properties.Resources.scythe;
            pbCard7.Name = "scythe";
            pbCard7.Size = new Size(width, height);
            frontList.Add(pbCard7);

            pbCard8.Image = Properties.Resources.shield;
            pbCard8.Name = "shield";
            pbCard8.Size = new Size(width, height);
            frontList.Add(pbCard8);

            pbCard9.Image = Properties.Resources.shurikin;
            pbCard9.Name = "shurikin";
            pbCard9.Size = new Size(width, height);
            frontList.Add(pbCard9);

            pbCard10.Image = Properties.Resources.warhammer;
            pbCard10.Name = "warhammer";
            pbCard10.Size = new Size(width, height);
            frontList.Add(pbCard10);

            pbCard11.Image = Properties.Resources.bowAndArrow;
            pbCard11.Name = "bowAndArrow";
            pbCard11.Size = new Size(width, height);
            frontList.Add(pbCard11);

            pbCard12.Image = Properties.Resources.boot;
            pbCard12.Name = "boot";
            pbCard12.Size = new Size(width, height);
            frontList.Add(pbCard12);

            pbCard13.Image = Properties.Resources.helm;
            pbCard13.Name = "helm";
            pbCard13.Size = new Size(width, height);
            frontList.Add(pbCard13);

            pbCard14.Image = Properties.Resources.lance;
            pbCard14.Name = "lance";
            pbCard14.Size = new Size(width, height);
            frontList.Add(pbCard14);

            pbCard15.Image = Properties.Resources.knife;
            pbCard15.Name = "knife";
            pbCard15.Size = new Size(width, height);
            frontList.Add(pbCard15);

            pbCard16.Image = Properties.Resources.scimitar;
            pbCard16.Name = "scimitar";
            pbCard16.Size = new Size(width, height);
            frontList.Add(pbCard16);

            pbCard17.Image = Properties.Resources.scythe;
            pbCard17.Name = "scythe";
            pbCard17.Size = new Size(width, height);
            frontList.Add(pbCard17);

            pbCard18.Image = Properties.Resources.shield;
            pbCard18.Name = "shield";
            pbCard18.Size = new Size(width, height);
            frontList.Add(pbCard18);

            pbCard19.Image = Properties.Resources.shurikin;
            pbCard19.Name = "shurikin";
            pbCard19.Size = new Size(width, height);
            frontList.Add(pbCard19);

            pbCard20.Image = Properties.Resources.warhammer;
            pbCard20.Name = "warhammer";
            pbCard20.Size = new Size(width, height);
            frontList.Add(pbCard20);
            //adds the different images to the list and randomizes them with the rand
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
        //Timer focus method if form is unfocused
        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            form.Invoke(new Action(() =>
            {
                if (form.ContainsFocus == false || form.rdBtnTimerOff.Checked == true)
                {
                    form.disposeTimer = true;
                }
                else
                {
                    form.disposeTimer = false;
                }
                if (form.disposeTimer == false)
                {
                    s += 1;
                    if (s == 60)
                    {
                        s = 0;
                        m += 1;
                    }
                    if (m == 60)
                    {
                        m = 0;
                        h += 1;
                    }

                    lblTimer.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                }
            }));
            
            if (m == 40)
            {
                t.Stop();
                form.Invoke(new Action(() =>
                {
                    GameOver();
                }));
            }
        }
        //Game over method if the time == 0
        void GameOver()
        {
            lblGameOver.BringToFront();
            lblGameOver.Visible = true;

            foreach (Button b in backList)
            {
                b.Enabled = false;
            }
        }
        //Method for when a card is selected, it checks the cards and makes the image visiable
        void CardSelect(object sender, EventArgs e)
        {
            btnMemoryStart.Focus();
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
                    //if there is no more cards timer stop
                    if (gridList.Count == 0)
                    {
                        t.Stop();
                    }
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
        //Clears all of the lists and dispose the timer
        public void ClearMemory()
        {
            frontList.Clear();
            gridList.Clear();
            backList.Clear();
            matchList.Clear();
            matchBackList.Clear();
            t.Dispose();
            //Dispose of the form controls
            for (int i = form.Controls.Count - 1; i >= 0; i--)
            {
                if (form.Controls[i].Name != "Config Button")
                {
                    if (form.Controls[i].Name != "Config Panel")
                    {
                        form.Controls[i].Dispose();
                    }
                }
            }
        }
        //makes the back button that stops timer and goes to title page
        private void BackButton(object sender, EventArgs e)
        {
            t.Stop();
            ClearMemory();
            form.AddTitlePage();
            form.memoryPlayed = false;
        }
    }
}

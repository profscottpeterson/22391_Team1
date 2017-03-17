using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XAATArcade
{
    public partial class XAATArcade : Form
    {
        PictureBox title = new PictureBox();
        MenuButton setting = new MenuButton();
        MenuStrip settings = new MenuStrip();
        Button game1 = new Button();
        Button game2 = new Button();
        Button game3 = new Button();
        Button game4 = new Button();
        Button memoryStart = new Button();
        Button back = new Button();
        Panel grid = new Panel();
        Button backs = new Button();
        int width = 70;
        int height = 110;
        int x = 55;
        int y = 55;
        Point pt = new Point(0, 0);
        Label pairsLeft = new Label();
        List<Control> frontList = new List<Control>();
        List<Panel> gridList = new List<Panel>();
        List<Button> backList = new List<Button>();
        List<Panel> match = new List<Panel>();
        List<Button> matchBack = new List<Button>();
        Random rand = new Random();
        Size formSize;
        Label matchesLeft = new Label();

        // make backbutton availibale for all games
        // create battleship game
        // create timer for matching game
        // create config screen
            // popupbox
            // cancell doesn't do anything while in game
            // on setup cancel goes back to main page
            // timer off timmer on
            // difficulty easy timer set to 5 min
            // difficulty medium timer set to 3 min
            // difficulty hard timer set to 1:30 min
        // timer starts on start button
        // timer stops when pairs left reaches 0

        public XAATArcade()
        {
            InitializeComponent();
        }

        private void XAATArcade_Load(object sender, EventArgs e)
        {
            formSize = ClientSize;
            CreateTitlePage();
        }

        private void CreateTitlePage()
        {
            title.Location = new Point(50, 10);
            title.Size = new Size(350, 100);
            title.BackColor = Color.Aqua;
            this.Controls.Add(title);
                        
            game1.Location = new Point(50, 120);
            game1.Size = new Size(100, 25);
            game1.Text = "Reflex";
            this.Controls.Add(game1);

            game2.Location = new Point(50, 180);
            game2.Size = new Size(100, 25);
            game2.Text = "Memory";
            this.Controls.Add(game2);

            game3.Location = new Point(50, 240);
            game3.Size = new Size(100, 25);
            this.Controls.Add(game3);

            game4.Location = new Point(50, 300);
            game4.Size = new Size(100, 25);
            this.Controls.Add(game4);

            game1.Click += (s, z) => { Reflex(s, z); };
            game2.Click += (s, z) => { Memory(s, z); };
        }

        private void RemoveTitlePage()
        {
            this.Controls.Remove(title);
            this.Controls.Remove(game1);
            this.Controls.Remove(game2);
            this.Controls.Remove(game3);
            this.Controls.Remove(game4);
           // game1.Enabled = false;
        }

        private void Memory(object sender, EventArgs e)
        {
            RemoveTitlePage();
            CreateStart();
        }

        private void CreateStart()
        {
            back = new Button();
            back.Location = new Point((formSize.Width - formSize.Width) + 1, (formSize.Height - formSize.Height) + 1);
            back.Size = new Size(50, 50);
            back.Text = "Back";
            back.Click += (s, z) => { BackButton(s, z); };
            this.Controls.Add(back);

            memoryStart = new Button();
            memoryStart.Location = new Point(formSize.Width - 51, (formSize.Height - formSize.Height) + 1);
            memoryStart.Size = new Size(50, 50);
            memoryStart.Text = "New Game";
            memoryStart.Click += (s, z) => { CreateCard(s, z); };
            this.Controls.Add(memoryStart);

            pairsLeft = new Label();
            pairsLeft.Location = new Point(formSize.Width - 102, (formSize.Height - formSize.Height) + 1);
            pairsLeft.Size = new Size(50,50);
            this.Controls.Add(pairsLeft);
        }

        private void ClearMemory()
        {
            frontList.Clear();
            gridList.Clear();
            backList.Clear();
            match.Clear();
            matchBack.Clear();

            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                this.Controls[i].Dispose();
            }
        }

        private void BackButton(object sender, EventArgs e)
        {
            ClearMemory();
            CreateTitlePage();
        }
        
        void CreateCard(object sender, EventArgs e)
        {
            ClearMemory();
            CreateStart();

            pairsLeft.Text = "10";
            for (int row = 0; row <= 3; row++)
            {
                for (int column = 0; column <= 4; column++)
                {
                    grid = new Panel();
                    grid.Location = new Point(x + (column * (width + 5)), y + (row * (height + 5)));
                    grid.Size = new Size(width, height);
                    grid.Name = row + " , " + column;
                    gridList.Add(grid);
                    this.Controls.Add(grid);

                    backs = new Button();
                    backs.Location = new Point(x + (column * (width + 5)), y + (row * (height + 5)));
                    backs.Size = new Size(width, height);
                    backs.Name = row + " , " + column;
                    backs.Visible = true;
                    backs.BackgroundImage = Properties.Resources.back;
                    backList.Add(backs);
                    backs.Click += (s, z) => { CardSelect(s, z); };
                    this.Controls.Add(backs);
                }
            }

            foreach (Button x in backList)
            {
                x.BringToFront();
            }

            PictureBox card1 = new PictureBox();
            PictureBox card2 = new PictureBox();
            PictureBox card3 = new PictureBox();
            PictureBox card4 = new PictureBox();
            PictureBox card5 = new PictureBox();
            PictureBox card6 = new PictureBox();
            PictureBox card7 = new PictureBox();
            PictureBox card8 = new PictureBox();
            PictureBox card9 = new PictureBox();
            PictureBox card10 = new PictureBox();
            PictureBox card11 = new PictureBox();
            PictureBox card12 = new PictureBox();
            PictureBox card13 = new PictureBox();
            PictureBox card14 = new PictureBox();
            PictureBox card15 = new PictureBox();
            PictureBox card16 = new PictureBox();
            PictureBox card17 = new PictureBox();
            PictureBox card18 = new PictureBox();
            PictureBox card19 = new PictureBox();
            PictureBox card20 = new PictureBox();

            card1.Image = Properties.Resources.bowAndArrow;
            card1.Name = "bowAndArrow";
            card1.Size = new Size(width, height);
            frontList.Add(card1);

            card2.Image = Properties.Resources.circle;
            card2.Name = "circle";
            card2.Size = new Size(width, height);
            frontList.Add(card2);

            card3.Image = Properties.Resources.diamond;
            card3.Name = "diamond";
            card3.Size = new Size(width, height);
            frontList.Add(card3);

            card4.Image = Properties.Resources.heart;
            card4.Name = "heart";
            card4.Size = new Size(width, height);
            frontList.Add(card4);

            card5.Image = Properties.Resources.knife;
            card5.Name = "knife";
            card5.Size = new Size(width, height);
            frontList.Add(card5);

            card6.Image = Properties.Resources.lightning;
            card6.Name = "lightning";
            card6.Size = new Size(width, height);
            frontList.Add(card6);

            card7.Image = Properties.Resources.rectangle;
            card7.Name = "rectangle";
            card7.Size = new Size(width, height);
            frontList.Add(card7);

            card8.Image = Properties.Resources.shield;
            card8.Name = "shield";
            card8.Size = new Size(width, height);
            frontList.Add(card8);

            card9.Image = Properties.Resources.shurikin;
            card9.Name = "shurikin";
            card9.Size = new Size(width, height);
            frontList.Add(card9);

            card10.Image = Properties.Resources.star;
            card10.Name = "star";
            card10.Size = new Size(width, height);
            frontList.Add(card10);

            card11.Image = Properties.Resources.bowAndArrow;
            card11.Name = "bowAndArrow";
            card11.Size = new Size(width, height);
            frontList.Add(card11);

            card12.Image = Properties.Resources.circle;
            card12.Name = "circle";
            card12.Size = new Size(width, height);
            frontList.Add(card12);

            card13.Image = Properties.Resources.diamond;
            card13.Name = "diamond";
            card13.Size = new Size(width, height);
            frontList.Add(card13);

            card14.Image = Properties.Resources.heart;
            card14.Name = "heart";
            card14.Size = new Size(width, height);
            frontList.Add(card14);

            card15.Image = Properties.Resources.knife;
            card15.Name = "knife";
            card15.Size = new Size(width, height);
            frontList.Add(card15);

            card16.Image = Properties.Resources.lightning;
            card16.Name = "lightning";
            card16.Size = new Size(width, height);
            frontList.Add(card16);

            card17.Image = Properties.Resources.rectangle;
            card17.Name = "rectangle";
            card17.Size = new Size(width, height);
            frontList.Add(card17);

            card18.Image = Properties.Resources.shield;
            card18.Name = "shield";
            card18.Size = new Size(width, height);
            frontList.Add(card18);

            card19.Image = Properties.Resources.shurikin;
            card19.Name = "shurikin";
            card19.Size = new Size(width, height);
            frontList.Add(card19);

            card20.Image = Properties.Resources.star;
            card20.Name = "star";
            card20.Size = new Size(width, height);
            frontList.Add(card20);

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

        void CardSelect(object sender, EventArgs e)
        {
            memoryStart.Focus();
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

        public async Task CardCheck()
        {
            await Task.Delay(250);
            foreach (Button b in backList)
            {
                if (b.Visible == false)
                {
                    matchBack.Add(b);
                    foreach (Panel p in gridList)
                    {
                        if (b.Location == p.Location)
                        {
                            match.Add(p);
                            break;
                        }
                    }
                }
            }

            if (match.Count > 0)
            {
                if (match[0].GetChildAtPoint(pt).Name == match[1].GetChildAtPoint(pt).Name)
                {
                    backList.Remove(matchBack[1]);
                    backList.Remove(matchBack[0]);
                    matchBack[1].Dispose();
                    matchBack[0].Dispose();
                    matchBack.Clear();
                    gridList.Remove(match[1]);
                    gridList.Remove(match[0]);
                    frontList.Remove(match[1].GetChildAtPoint(pt));
                    frontList.Remove(match[0].GetChildAtPoint(pt));
                    match[1].Dispose();
                    match[0].Dispose();
                    match.Clear();
                    pairsLeft.Text = (frontList.Count / 2).ToString();
                }
                else
                {
                    matchBack[1].Visible = true;
                    matchBack[0].Visible = true;
                    matchBack.Clear();
                    match.Clear();
                }
            }
        }

        private void Reflex(object sender, EventArgs e)
        {
            MessageBox.Show("3");
        }
    }
}

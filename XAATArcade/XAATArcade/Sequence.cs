using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
/// <summary>
/// Creates the sequence game after it is selected on the main menu
/// </summary>
namespace XAATArcade
{
    class Sequence
    {
        //Initial assembly for the items on the screen
        Button btnSequenceStart = new Button();
        Button btnBack = new Button();
        Panel pnlGrid = new Panel();
        int x = 90;
        int y = 65;
        Label lblScore = new Label();
        Label lblScoreText = new Label();
        Label matchesLeft = new Label();
        List<Panel> gridList = new List<Panel>();
        List<Panel> sequenceList = new List<Panel>();
        List<Panel> pickedList = new List<Panel>();
        List<Panel> clickedList = new List<Panel>();
        Random rand = new Random();
        Size formSize;
        Color randomColor;
        bool error = false;
        private XAATArcade form;
        Font font;
        FontFamily ff;
        //form setup
        public Sequence(XAATArcade parent, Size parentSize)
        {
            form = parent;
            formSize = parentSize;
            CreateSequenceStart();
        }
        //imports font
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        
        private void CreateSequenceStart()
        {
            //adds font
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
            //Adds back button to form
            btnBack = new Button();
            btnBack.Location = new Point((formSize.Width - formSize.Width) + 1, (formSize.Height - formSize.Height) + 1);
            btnBack.Size = new Size(50, 50);
            btnBack.Font = new Font(ff, 5f, FontStyle.Regular);
            btnBack.Text = "Back";
            btnBack.BackColor = Color.Blue;
            btnBack.Click += (s, z) => { BackButton(s, z); };
            btnBack.MouseDown += (s, z) => { form.PlaySound(s, z); };
            form.Controls.Add(btnBack);
            //Adds start button to form
            btnSequenceStart = new Button();
            btnSequenceStart.Location = new Point(formSize.Width - 51, (formSize.Height - formSize.Height) + 1);
            btnSequenceStart.Size = new Size(50, 50);
            btnSequenceStart.Font = new Font(ff, 5f, FontStyle.Regular);
            btnSequenceStart.Text = "Start";
            btnSequenceStart.BackColor = Color.Blue;
            btnSequenceStart.Click += (s, z) => { SequenceStart(s, z); };
            btnSequenceStart.MouseDown += (s, z) => { form.PlaySound(s, z); };
            form.Controls.Add(btnSequenceStart);
            //Score label
            lblScore = new Label();
            lblScore.Location = new Point(formSize.Width - 202, (formSize.Height - formSize.Height) + 20);
            lblScore.Size = new Size(150, 50);
            lblScore.Text = "0";
            lblScore.AutoSize = true;
            lblScore.Font = new Font(ff, 15f, FontStyle.Regular);
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            lblScore.ForeColor = Color.White;
            form.Controls.Add(lblScore);
            //label under the score label
            lblScoreText = new Label();
            lblScoreText.Location = new Point(formSize.Width - 374, (formSize.Height - formSize.Height) + 5);
            lblScoreText.Size = new Size(150, 50);
            lblScoreText.Text = "Score";
            lblScore.AutoSize = true;
            lblScoreText.Font = new Font(ff, 15f, FontStyle.Regular);
            lblScoreText.ForeColor = Color.White;
            lblScoreText.TextAlign = ContentAlignment.MiddleCenter;
            form.Controls.Add(lblScoreText);

            for (int row = 0; row <= 2; row++)
            {
                for (int column = 0; column <= 2; column++)
                {
                    //adds color to the panels
                    //makes sure that the color of the backcolor is different from the panels
                    randomColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                    if (randomColor == form.BackColor)
                    {
                        randomColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                    }
                    
                    pnlGrid = new Panel();
                    pnlGrid.Location = new Point(x + (column * (100 + 5)), y + (row * (100 + 5)));
                    pnlGrid.Size = new Size(100, 100);
                    pnlGrid.Name = row + " , " + column;
                    pnlGrid.BackColor = randomColor;
                    pnlGrid.BackgroundImage = Properties.Resources.sequenceBoarder;
                    pnlGrid.Click += (s, z) => { SequenceSelect(s, z); };
                    pnlGrid.MouseDoubleClick += (s, z) => { SequenceSelect(s, z); };
                    pnlGrid.MouseHover += (s, z) => { PanelHover(s, z); };
                    pnlGrid.MouseLeave += (s, z) => { PanelLeave(s, z); };
                    pnlGrid.MouseDown += (s, z) => { form.PlaySound(s, z); };
                    gridList.Add(pnlGrid);
                    form.Controls.Add(pnlGrid);
                }
            }
        }
        //starts the game
        private void SequenceStart(object sender, EventArgs e)
        {
            if (sequenceList.Count > 0)
            {
                ClearSequence();
                CreateSequenceStart();
                error = false;
            }
            StartSequence();
        }
        //On hover method
        private void PanelHover(object sender, EventArgs e)
        {
            foreach (Panel p in gridList)
            {
                if (sender == p)
                {
                    p.BackgroundImage = Properties.Resources.sequencesquareHover;
                }
            }
        }
        //off hover
        private void PanelLeave(object sender, EventArgs e)
        {
            foreach (Panel p in gridList)
            {
                if (sender == p)
                {
                    p.BackgroundImage = Properties.Resources.sequenceBoarder;
                }
            }
        }
        //Starts the sequence
        private async Task StartSequence()
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
        //Adds the panel to a list of clicked panels in a sequence
        public void SequenceSelect(object sender, EventArgs e)
        {
            Panel clickedSquare = (Panel)sender;
            clickedList.Add(clickedSquare);

            if (clickedList.Count == pickedList.Count)
            {
                CheckSequence();
            }
        }
        // if sequence is wrong game over
        async Task CheckSequence()
        {
            for (int i = 0; i < clickedList.Count; i++)
            {
                if (clickedList[i] != pickedList[i])
                {
                    error = true;
                    MessageBox.Show("Game Over. New game will start.", "Game Over");
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
        //Clears Sequence
        private void ClearSequence()
        {
            sequenceList.Clear();
            gridList.Clear();
            clickedList.Clear();
            pickedList.Clear();

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
        //Back button with all methods for it
        private void BackButton(object sender, EventArgs e)
        {
            ClearSequence();
            form.AddTitlePage();
            form.sequencePlayed = false;
        }
    }
}

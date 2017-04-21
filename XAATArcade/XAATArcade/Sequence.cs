using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace XAATArcade
{
    public class Sequence
    {
        Button btnSequenceStart = new Button();
        Button btnBack = new Button();
        Panel pnlGrid = new Panel();
        int x = 55;
        int y = 55;
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

        public Sequence(XAATArcade parent, Size parentSize)
        {
            form = parent;
            formSize = parentSize;
            CreateSequenceStart();
        }

        public void CreateSequenceStart()
        {
            btnBack = new Button();
            btnBack.Location = new Point((formSize.Width - formSize.Width) + 1, (formSize.Height - formSize.Height) + 1);
            btnBack.Size = new Size(50, 50);
            btnBack.Text = "Back";
            btnBack.Click += (s, z) => { BackButton(s, z); };
            form.Controls.Add(btnBack);

            btnSequenceStart = new Button();
            btnSequenceStart.Location = new Point(formSize.Width - 51, (formSize.Height - formSize.Height) + 1);
            btnSequenceStart.Size = new Size(50, 50);
            btnSequenceStart.Text = "Start";
            btnSequenceStart.Click += (s, z) => { SequenceStart(s, z); };
            form.Controls.Add(btnSequenceStart);

            lblScore = new Label();
            lblScore.Location = new Point(formSize.Width - 102, (formSize.Height - formSize.Height) + 20);
            lblScore.Size = new Size(50, 15);
            lblScore.Text = "0";
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            form.Controls.Add(lblScore);

            lblScoreText = new Label();
            lblScoreText.Location = new Point(formSize.Width - 104, (formSize.Height - formSize.Height) + 1);
            lblScoreText.Size = new Size(50, 15);
            lblScoreText.Text = "Score";
            lblScoreText.TextAlign = ContentAlignment.MiddleCenter;
            form.Controls.Add(lblScoreText);

            for (int row = 0; row <= 2; row++)
            {
                for (int column = 0; column <= 2; column++)
                {
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
                    pnlGrid.Click += (s, z) => { SequenceSelect(s, z); };
                    pnlGrid.MouseDoubleClick += (s, z) => { SequenceSelect(s, z); };
                    gridList.Add(pnlGrid);
                    form.Controls.Add(pnlGrid);
                }
            }
        }

        public void SequenceStart(object sender, EventArgs e)
        {
            PlaySound();
            if (sequenceList.Count > 0)
            {
                ClearSequence();
                CreateSequenceStart();
                error = false;
            }
            StartSequence();
        }

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
                        await Task.Delay(300);
                        p.BackColor = color;
                    }
                    foreach (Panel p in sequenceList)
                    {
                        p.Enabled = true;
                    }
                }
            }
        }

        void SequenceSelect(object sender, EventArgs e)
        {
            PlaySound();
            Panel clickedSquare = (Panel)sender;

            clickedList.Add(clickedSquare);

            if (clickedList.Count == pickedList.Count)
            {
                CheckSequence();
            }
        }

        async Task CheckSequence()
        {
            for (int i = 0; i < clickedList.Count; i++)
            {
                if (clickedList[i] != pickedList[i])
                {
                    error = true;
                    MessageBox.Show("Game Over");
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

        public void PlaySound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.Stream = Properties.Resources.click;
            player.Load();
            player.Play();
        }

        public void ClearSequence()
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

        public void BackButton(object sender, EventArgs e)
        {
            PlaySound();
            ClearSequence();
            form.CreateTitlePage();
        }
    }
}

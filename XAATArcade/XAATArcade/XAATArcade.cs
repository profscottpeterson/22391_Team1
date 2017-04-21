using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;

namespace XAATArcade
{
    public partial class XAATArcade : Form
    {
        PictureBox pbTitle = new PictureBox();
        Button btnConfig = new Button();
        Button btnSequence = new Button();
        Button btnMemory = new Button();
        Button game3 = new Button();
        Button game4 = new Button();
        Button btnClose = new Button();
        Button btnChangeBackgroundColor = new Button();

        public bool memoryPlayed = false;
        public bool sequencePlayed = false;
        public bool disposeTimer = false;
        Panel pnlConfig = new Panel();
        Size formSize;
        Memory memory;
        Sequence sequence;

        // make backbutton availibale for all games
        // create config screen
        // timer off timmer on
        // interface for testing
        // method that adds sound to all buttons

        public XAATArcade()
        {
            InitializeComponent();
        }

        private void XAATArcade_Load(object sender, EventArgs e)
        {
            formSize = ClientSize;
            CreateTitlePage();
        }

        public void CreateTitlePage()
        {
            pbTitle.Location = new Point(50, 10);
            pbTitle.Size = new Size(350, 100);
            pbTitle.BackColor = Color.Aqua;
            this.Controls.Add(pbTitle);

            btnSequence.Location = new Point(50, 120);
            btnSequence.Size = new Size(100, 25);
            btnSequence.BackColor = Color.Chocolate;
            btnSequence.Text = "Sequence";
            btnSequence.Click += (s, z) => { Sequence(s, z); };
            this.Controls.Add(btnSequence);

            btnMemory.Location = new Point(50, 180);
            btnMemory.Size = new Size(100, 25);
            btnMemory.Text = "Memory";
            btnMemory.Click += (s, z) => { Memory(s, z); };
            this.Controls.Add(btnMemory);

            game3.Location = new Point(50, 240);
            game3.Size = new Size(100, 25);
            this.Controls.Add(game3);

            game4.Location = new Point(50, 300);
            game4.Size = new Size(100, 25);
            this.Controls.Add(game4);

            btnConfig.Location = new Point(formSize.Width - 51, formSize.Height - 51);
            btnConfig.Name = "Config Button";
            btnConfig.Size = new Size(50, 50);
            btnConfig.BackgroundImage = Properties.Resources.config;
            btnConfig.BackgroundImageLayout = ImageLayout.Center;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.FlatAppearance.BorderSize = 0;
            btnConfig.Click += (s, z) => { CreateConfig(s, z); };
            Controls.Add(btnConfig);

            pnlConfig.SetBounds((formSize.Width - formSize.Width) + 20, (formSize.Height - formSize.Height) + 20, formSize.Width - 40, formSize.Height - 40);
            pnlConfig.Name = "Config Panel";
            pnlConfig.BackColor = Color.Bisque;
            pnlConfig.Visible = false;
            Controls.Add(pnlConfig);
        }

        private void RemoveTitlePage()
        {
            this.Controls.Remove(pbTitle);
            this.Controls.Remove(btnSequence);
            this.Controls.Remove(btnMemory);
            this.Controls.Remove(game3);
            this.Controls.Remove(game4);
        }

        public void Memory(object sender, EventArgs e)
        {
            PlaySound();
            memoryPlayed = true;
            RemoveTitlePage();
            memory = new Memory(this, formSize);
        }

        public void Sequence(object sender, EventArgs e)
        {
            PlaySound();
            sequencePlayed = true;
            RemoveTitlePage();
            sequence = new Sequence(this, formSize);
        }

        private void PlaySound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.Stream = Properties.Resources.click;
            player.Load();
            player.Play();
        }

        private void XAATArcade_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (memoryPlayed == true)
            {
                memory.t.Stop();
                memory.t.Dispose();
                disposeTimer = true;

            }
            Application.DoEvents();
        }

        public void CreateConfig(object sender, EventArgs e)
        {
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i].Name != "Config Panel")
                {
                    Controls[i].Enabled = false;
                }
            }

            if (disposeTimer == false & memoryPlayed == true)
            {
                memory.t.Stop();
                disposeTimer = true;
            }
            PlaySound();
            pnlConfig.BringToFront();
            pnlConfig.Visible = true;


            btnClose.Location = new Point(pnlConfig.Width - pnlConfig.Width + 10, pnlConfig.Height - pnlConfig.Height + 10);

            btnClose.Size = new Size(50, 50);
            //btnClose.BackgroundImage = Properties.Resources.config;
            //btnClose.BackgroundImageLayout = ImageLayout.Center;
            btnClose.Click += (s, z) => { CloseConfig(s, z); };
            //Controls.Add(btnClose);
            pnlConfig.Controls.Add(btnClose);

            btnChangeBackgroundColor.Location = new Point();



        }

        public void ChangeBackColor(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            DialogResult colorResult = colorDialog1.ShowDialog();
            if (colorResult == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        public void CloseConfig(object sender, EventArgs e)
        {
            PlaySound();
            pnlConfig.Visible = false;
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i].Name != "Config Panel")
                {
                    Controls[i].Enabled = true;
                }
            }

            if (disposeTimer == true && memoryPlayed == true)
            {
                disposeTimer = false;
                memory.t.Start();
            }
        }

        //#region Hi
        //#endregion
    }
}

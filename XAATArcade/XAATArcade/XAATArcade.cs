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
using targetPractice;

namespace XAATArcade
{
    public partial class XAATArcade : Form
    {
        PictureBox pbTitle = new PictureBox();
        Button btnConfig = new Button();
        Button btnSequence = new Button();
        Button btnMemory = new Button();
        Button btnReflex = new Button();
        Button btnClose = new Button();
        Button btnChangeBackgroundColor = new Button();
        public bool memoryPlayed = false;
        public bool sequencePlayed = false;
        public bool disposeTimer = false;
        Panel pnlConfig = new Panel();
        Size formSize;
        Memory memory;
        Sequence sequence;
        Form1 reflex;
        public Font font;

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
            CreateConfig();
            this.BackColor = Color.Black;
        }

        private void CreateTitlePage()
        {
            pbTitle.Location = new Point((((this.Width / 2) /2) /2) + 10, 10);
            pbTitle.Size = new Size(350, 300);
            pbTitle.Image = Properties.Resources.xaatarcadetitle;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(pbTitle);

            btnSequence.Location = new Point(this.Width - this.Width + 30, 310);
            btnSequence.Size = new Size(350, 80);
            btnSequence.BackgroundImage = Properties.Resources.sequence;
            btnSequence.Click += (s, z) => { Sequence(s, z); };
            btnSequence.MouseHover += (s, z) => { SequenceHover(s, z); };
            btnSequence.MouseLeave += (s, z) => { SequenceMouseLeave(s, z); };
            btnSequence.MouseDown += (s, z) => { PlaySound(s, z); };
            btnSequence.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnSequence);

            btnMemory.Location = new Point(this.Width - this.Width + 30, 370);
            btnMemory.Size = new Size(350, 80);
            btnMemory.BackgroundImage = Properties.Resources.memory;
            btnMemory.Click += (s, z) => { Memory(s, z); };
            btnMemory.MouseHover += (s, z) => { MemoryHover(s, z); };
            btnMemory.MouseLeave += (s, z) => { MemoryMouseLeave(s, z); };
            btnMemory.MouseDown += (s, z) => { PlaySound(s, z); };
            btnMemory.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnMemory);

            btnReflex.Location = new Point(this.Width - this.Width + 30, 430);
            btnReflex.Size = new Size(350, 80);
            btnReflex.BackgroundImage = Properties.Resources.reflex;
            btnReflex.Click += (s, z) => { Reflex(s, z); };
            btnReflex.MouseHover += (s, z) => { ReflexHover(s, z); };
            btnReflex.MouseLeave += (s, z) => { ReflexMouseLeave(s, z); };
            btnReflex.MouseDown += (s, z) => { PlaySound(s, z); };
            btnReflex.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnReflex);
        }

        private void CreateConfig()
        {
            btnConfig.Location = new Point(formSize.Width - 51, formSize.Height - 51);
            btnConfig.Name = "Config Button";
            btnConfig.Size = new Size(50, 50);
            btnConfig.BackgroundImage = Properties.Resources.cog;
            btnConfig.BackgroundImageLayout = ImageLayout.Center;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.FlatAppearance.BorderSize = 0;
            btnConfig.Click += (s, z) => { OpenConfig(s, z); };
            btnConfig.MouseDown += (s, z) => { PlaySound(s, z); };
            Controls.Add(btnConfig);

            pnlConfig.SetBounds((formSize.Width - formSize.Width) + 20, (formSize.Height - formSize.Height) + 20, formSize.Width - 40, formSize.Height - 40);
            pnlConfig.Name = "Config Panel";
            pnlConfig.BackColor = Color.Bisque;
            pnlConfig.Visible = false;
            Controls.Add(pnlConfig);

            btnClose.Location = new Point(pnlConfig.Width - 52, pnlConfig.Height - 52);
            btnClose.Size = new Size(50, 50);
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.MiddleCenter;
            btnClose.Click += (s, z) => { CloseConfig(s, z); };
            btnClose.MouseDown += (s, z) => { PlaySound(s, z); };
            pnlConfig.Controls.Add(btnClose);

            btnChangeBackgroundColor.Location = new Point((((this.Width / 2) / 2) / 2) + 10, 10);
            btnChangeBackgroundColor.Size = new Size(50, 50);
            btnChangeBackgroundColor.Text = "Change Background Color";
            btnChangeBackgroundColor.TextAlign = ContentAlignment.MiddleCenter;
            btnChangeBackgroundColor.Click += (s, z) => { ChangeBackColor(s, z); };
            btnChangeBackgroundColor.MouseDown += (s, z) => { PlaySound(s, z); };
            pnlConfig.Controls.Add(btnChangeBackgroundColor);
        }

        public void AddTitlePage()
        {
            this.Controls.Add(pbTitle);
            this.Controls.Add(btnSequence);
            this.Controls.Add(btnMemory);
            this.Controls.Add(btnReflex);
        }

        private void RemoveTitlePage()
        {
            this.Controls.Remove(pbTitle);
            this.Controls.Remove(btnSequence);
            this.Controls.Remove(btnMemory);
            this.Controls.Remove(btnReflex);
        }

        #region Memory
        private void Memory(object sender, EventArgs e)
        {
            memoryPlayed = true;
            RemoveTitlePage();
            memory = new Memory(this, formSize);
        }

        private void MemoryHover(object sender, EventArgs e)
        {
            btnMemory.BackgroundImage = Properties.Resources.memoryHover;
            pbTitle.Image = Properties.Resources.matchinggame;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void MemoryMouseLeave(object sender, EventArgs e)
        {
            btnMemory.BackgroundImage = Properties.Resources.memory;
            pbTitle.Image = Properties.Resources.xaatarcadetitle;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        #endregion

        #region Sequence
        private void Sequence(object sender, EventArgs e)
        {
            sequencePlayed = true;
            RemoveTitlePage();
            sequence = new Sequence(this, formSize);
        }

        private void SequenceHover(object sender, EventArgs e)
        {
            btnSequence.BackgroundImage = Properties.Resources.sequencehover;
            pbTitle.Image = Properties.Resources.sequencegame;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void SequenceMouseLeave(object sender, EventArgs e)
        {
            btnSequence.BackgroundImage = Properties.Resources.sequence;
            pbTitle.Image = Properties.Resources.xaatarcadetitle;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        #endregion

        #region Reflex
        private void Reflex(object sender, EventArgs e)
        {
             reflex = new Form1();
            reflex.ShowDialog();
        }

        private void ReflexHover(object sender, EventArgs e)
        {
            btnReflex.BackgroundImage = Properties.Resources.reflexhover;
            pbTitle.Image = Properties.Resources.reflexgame;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void ReflexMouseLeave(object sender, EventArgs e)
        {
            btnReflex.BackgroundImage = Properties.Resources.reflex;
            pbTitle.Image = Properties.Resources.xaatarcadetitle;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        #endregion

        public void PlaySound(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.Stream = Properties.Resources.click;
            player.Load();
            player.Play();
        }

        #region Config
        public void OpenConfig(object sender, EventArgs e)
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
            
            pnlConfig.BringToFront();
            pnlConfig.Visible = true;
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
        #endregion

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
    }
}

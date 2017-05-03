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
using System.Media;
using System.IO;
/// <summary>
/// Main Form for the project, the project menu.
/// </summary>

namespace XAATArcade
{
    public partial class XAATArcade : Form
    {
        //Setup of the form
        PictureBox pbTitle = new PictureBox();
        Button btnConfig = new Button();
        Button btnSequence = new Button();
        Button btnMemory = new Button();
        Button btnReflex = new Button();
        Button btnClose = new Button();
        Button btnChangeBackgroundColor = new Button();
        RadioButton rdBtnButtonSoundOn = new RadioButton();
        RadioButton rdBtnButtonSoundOff = new RadioButton();
        RadioButton rdBtnBackgroundSoundOn = new RadioButton();
        RadioButton rdBtnBackgroundSoundOff = new RadioButton();
        public bool memoryPlayed = false;
        public bool sequencePlayed = false;
        public bool disposeTimer = false;
        bool buttonSoundOn = true;
        bool backgroundSoundOn = true;
        Panel pnlConfig = new Panel();
        Panel pnlButtonSound = new Panel();
        Panel pnlBackgroundSound = new Panel();
        Size formSize;
        Memory memory;
        Sequence sequence;
        Form1 reflex;
        public Font font;
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        ColorDialog colorDialog1 = new ColorDialog();

        // make backbutton availibale for all games
        // create config screen
        // timer off timmer on
        // interface for testing
        // method that adds sound to all buttons
        // add the csv file

        public XAATArcade()
        {
            InitializeComponent();
        }
        //on load form size==ClientSize and creates page, and sets up the back color and sound
        private void XAATArcade_Load(object sender, EventArgs e)
        {
            formSize = ClientSize;
            CreateTitlePage();
            CreateConfig();
            this.BackColor = Color.Black;

            Player.URL = System.IO.Directory.GetCurrentDirectory() + "/Sounds/backgroundMusic.wav";
            (Player.settings as WMPLib.IWMPSettings).setMode("loop", true);
            PlayBackgroundSound();
        }
        //does what the method says
        private void CreateTitlePage()
        {
            pbTitle.Location = new Point((((this.Width / 2) /2) /2) + 10, 10);
            pbTitle.Size = new Size(370, 320);
            pbTitle.Image = Properties.Resources.Untitled_2;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(pbTitle);

            btnSequence.Location = new Point(this.Width - this.Width + 30, 310);
            btnSequence.Size = new Size(350, 80);
            btnSequence.BackgroundImage = Properties.Resources.sequence;
            btnSequence.Click += (s, z) => { Sequence(s, z); };
            btnSequence.MouseEnter += (s, z) => { SequenceHover(s, z); };
            btnSequence.MouseLeave += (s, z) => { SequenceMouseLeave(s, z); };
            btnSequence.MouseDown += (s, z) => { PlaySound(s, z); };
            btnSequence.FlatStyle = FlatStyle.Flat;
            btnSequence.FlatAppearance.BorderSize = 0;
            btnSequence.BackgroundImageLayout = ImageLayout.Center;
            btnSequence.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSequence.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.Controls.Add(btnSequence);

            btnMemory.Location = new Point(this.Width - this.Width + 30, 370);
            btnMemory.Size = new Size(350, 80);
            btnMemory.BackgroundImage = Properties.Resources.memory;
            btnMemory.Click += (s, z) => { Memory(s, z); };
            btnMemory.MouseEnter += (s, z) => { MemoryHover(s, z); };
            btnMemory.MouseLeave += (s, z) => { MemoryMouseLeave(s, z); };
            btnMemory.MouseDown += (s, z) => { PlaySound(s, z); };
            btnMemory.FlatStyle = FlatStyle.Flat;
            btnMemory.FlatAppearance.BorderSize = 0;
            btnMemory.BackgroundImageLayout = ImageLayout.Center;
            btnMemory.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMemory.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.Controls.Add(btnMemory);

            btnReflex.Location = new Point(this.Width - this.Width + 30, 430);
            btnReflex.Size = new Size(350, 80);
            btnReflex.BackgroundImage = Properties.Resources.reflex;
            btnReflex.Click += (s, z) => { Reflex(s, z); };
            btnReflex.MouseEnter += (s, z) => { ReflexHover(s, z); };
            btnReflex.MouseLeave += (s, z) => { ReflexMouseLeave(s, z); };
            btnReflex.MouseDown += (s, z) => { PlaySound(s, z); };
            btnReflex.FlatStyle = FlatStyle.Flat;
            btnReflex.FlatAppearance.BorderSize = 0;
            btnReflex.BackgroundImageLayout = ImageLayout.Center;
            btnReflex.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnReflex.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.Controls.Add(btnReflex);
        }
        //Creates config button dynamicly
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

            //closes the config menu
            btnClose.Location = new Point(pnlConfig.Width - 52, pnlConfig.Height - 52);
            btnClose.Size = new Size(50, 50);
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.MiddleCenter;
            btnClose.Click += (s, z) => { CloseConfig(s, z); };
            btnClose.MouseDown += (s, z) => { PlaySound(s, z); };
            pnlConfig.Controls.Add(btnClose);

            //Changes Background color
            btnChangeBackgroundColor.Location = new Point((((this.Width / 2) / 2) / 2) + 10, 10);
            btnChangeBackgroundColor.Size = new Size(50, 50);
            btnChangeBackgroundColor.Text = "Change Background Color";
            btnChangeBackgroundColor.TextAlign = ContentAlignment.MiddleCenter;
            btnChangeBackgroundColor.Click += (s, z) => { ChangeBackColor(s, z); };
            btnChangeBackgroundColor.MouseDown += (s, z) => { PlaySound(s, z); };
            pnlConfig.Controls.Add(btnChangeBackgroundColor);

            pnlButtonSound.Location = new Point((((this.Width / 2) / 2) / 2) + 10, 70);
            pnlButtonSound.Size = new Size(200, 60);
            pnlButtonSound.Name = "Button Sound Panel";
            pnlButtonSound.BackColor = Color.Yellow;
            pnlConfig.Controls.Add(pnlButtonSound);

            //Allows the button sound on
            rdBtnButtonSoundOn.Location = new Point(5, 5);
            rdBtnButtonSoundOn.Click += (s, z) => { TurnButtonSoundOn(s, z); };
            rdBtnButtonSoundOn.Width = 200;
            rdBtnButtonSoundOn.Text = "Button Sound On";
            rdBtnButtonSoundOn.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnButtonSoundOn.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnButtonSoundOn.Checked = true;
            rdBtnButtonSoundOn.MouseDown += (s, z) => { PlaySound(s, z); };
            pnlButtonSound.Controls.Add(rdBtnButtonSoundOn);

            //Allows the button sounds off
            rdBtnButtonSoundOff.Location = new Point(5, 30);
            rdBtnButtonSoundOff.Click += (s, z) => { TurnButtonSoundOff(s, z); };
            rdBtnButtonSoundOff.Width = 200;
            rdBtnButtonSoundOff.Text = "Button Sound Off";
            rdBtnButtonSoundOff.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnButtonSoundOff.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnButtonSoundOff.MouseDown += (s, z) => { PlaySound(s, z); };
            pnlButtonSound.Controls.Add(rdBtnButtonSoundOff);

            pnlBackgroundSound.Location = new Point((((this.Width / 2) / 2) / 2) + 10, 130);
            pnlBackgroundSound.Size = new Size(200, 60);
            pnlBackgroundSound.Name = "Background Sound Panel";
            pnlBackgroundSound.BackColor = Color.AliceBlue;
            pnlConfig.Controls.Add(pnlBackgroundSound);

            //allows sound to be turned off
            rdBtnBackgroundSoundOn.Location = new Point(5, 5);
            rdBtnBackgroundSoundOn.Click += (s, z) => { TurnBackgroundSoundOn(s, z); };
            rdBtnBackgroundSoundOn.Width = 200;
            rdBtnBackgroundSoundOn.Text = "Background Sound On";
            rdBtnBackgroundSoundOn.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnBackgroundSoundOn.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnBackgroundSoundOn.Checked = true;
            rdBtnBackgroundSoundOn.MouseDown += (s, z) => { PlaySound(s, z); };
            pnlBackgroundSound.Controls.Add(rdBtnBackgroundSoundOn);

            //allows background sound off
            rdBtnBackgroundSoundOff.Location = new Point(5, 30);
            rdBtnBackgroundSoundOff.Click += (s, z) => { TurnBackgroundSoundOff(s, z); };
            rdBtnBackgroundSoundOff.Width = 200;
            rdBtnBackgroundSoundOff.Text = "Background Sound Off";
            rdBtnBackgroundSoundOff.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnBackgroundSoundOff.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnBackgroundSoundOff.MouseDown += (s, z) => { PlaySound(s, z); };
            pnlBackgroundSound.Controls.Add(rdBtnBackgroundSoundOff);
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
        //Memory setup
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
            btnMemory.Size += new Size(9, 9);
        }

        private void MemoryMouseLeave(object sender, EventArgs e)
        {
            btnMemory.BackgroundImage = Properties.Resources.memory;
            pbTitle.Image = Properties.Resources.Untitled_2;
            btnMemory.Size -= new Size(9, 9);
        }
        #endregion
        //Sequence setup
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
            btnSequence.Size += new Size(9, 9);
        }

        private void SequenceMouseLeave(object sender, EventArgs e)
        {
            btnSequence.BackgroundImage = Properties.Resources.sequence;
            pbTitle.Image = Properties.Resources.Untitled_2;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
            btnSequence.Size -= new Size(9, 9);
        }
        #endregion
        //Reflex setup
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
            btnReflex.Size += new Size(9, 9);
        }

        private void ReflexMouseLeave(object sender, EventArgs e)
        {
            btnReflex.BackgroundImage = Properties.Resources.reflex;
            pbTitle.Image = Properties.Resources.Untitled_2;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
            btnReflex.Size -= new Size(9, 9);
        }
        #endregion
        //Config setup
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
        //Used for sound
        #region Sound
        private void TurnButtonSoundOn(object sender, EventArgs e)
        {
            buttonSoundOn = true;
        }

        private void TurnButtonSoundOff(object sender, EventArgs e)
        {
            buttonSoundOn = false;
        }

        public void PlaySound(object sender, EventArgs e)
        {
            if (buttonSoundOn == true)
            {
                new System.Threading.Thread(() => {
                    var a = new System.Windows.Media.MediaPlayer();
                    a.Open(new System.Uri(System.IO.Directory.GetCurrentDirectory() + "/Sounds/click.wav"));
                    a.Play();
                }).Start();
            }
        }

        private void TurnBackgroundSoundOn(object sender, EventArgs e)
        {
            if (backgroundSoundOn == false)
            {
                backgroundSoundOn = true;
                PlayBackgroundSound();
            }
        }

        private void TurnBackgroundSoundOff(object sender, EventArgs e)
        {
            if (backgroundSoundOn == true)
            {
                backgroundSoundOn = false;
                StopBackgroundSound();
            }
        }

        public void PlayBackgroundSound()
        {
            Player.controls.play();
        }

        public void StopBackgroundSound()
        {
            Player.controls.pause();
        }
        #endregion
        //form close method
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

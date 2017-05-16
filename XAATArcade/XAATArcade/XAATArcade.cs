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
        RadioButton rdBtnTimerOn = new RadioButton();
        public RadioButton rdBtnTimerOff = new RadioButton();
        RadioButton rdBtnSpeed200 = new RadioButton();
        RadioButton rdBtnSpeed300 = new RadioButton();
        RadioButton rdBtnSpeed400 = new RadioButton();
        RadioButton rdBtnSpeed500 = new RadioButton();
        public bool memoryPlayed = false;
        public bool sequencePlayed = false;
        public bool disposeTimer = false;
        public int speed;
        bool buttonSoundOn = true;
        bool backgroundSoundOn = true;
        Panel pnlConfig = new Panel();
        GroupBox grpBoxButtonSound = new GroupBox();
        GroupBox grpBoxBackgroundSound = new GroupBox();
        GroupBox grpBoxMemoryTimer = new GroupBox();
        GroupBox grpBoxSequenceSpeed = new GroupBox();

        Size formSize;
        Memory memory;
        Sequence sequence;
        Form1 reflex;
        public Font font;
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();

        System.Windows.Media.MediaPlayer a = new System.Windows.Media.MediaPlayer();
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
            btnChangeBackgroundColor.Location = new Point((((this.Width / 2) / 2) / 2) + 10, 20);
            btnChangeBackgroundColor.Size = new Size(200, 25);
            btnChangeBackgroundColor.Text = "Change Background Color";
            btnChangeBackgroundColor.TextAlign = ContentAlignment.MiddleCenter;
            btnChangeBackgroundColor.Click += (s, z) => { ChangeBackColor(s, z); };
            btnChangeBackgroundColor.MouseDown += (s, z) => { PlaySound(s, z); };
            pnlConfig.Controls.Add(btnChangeBackgroundColor);

            grpBoxButtonSound.Location = new Point((((this.Width / 2) / 2) / 2) + 10, 60);
            grpBoxButtonSound.Size = new Size(115, 70);
            grpBoxButtonSound.Text = "Button Sound";
            grpBoxButtonSound.Name = "Button Sound Group Box";
            grpBoxButtonSound.BackColor = Color.Yellow;
            pnlConfig.Controls.Add(grpBoxButtonSound);

            //Allows the button sound on
            rdBtnButtonSoundOn.Location = new Point(10, 15);
            rdBtnButtonSoundOn.Click += (s, z) => { TurnButtonSoundOn(s, z); };
            rdBtnButtonSoundOn.Width = 40;
            rdBtnButtonSoundOn.Text = "On";
            rdBtnButtonSoundOn.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnButtonSoundOn.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnButtonSoundOn.Checked = true;
            rdBtnButtonSoundOn.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxButtonSound.Controls.Add(rdBtnButtonSoundOn);

            //Allows the button sounds off
            rdBtnButtonSoundOff.Location = new Point(10, 40);
            rdBtnButtonSoundOff.Click += (s, z) => { TurnButtonSoundOff(s, z); };
            rdBtnButtonSoundOff.Width = 40;
            rdBtnButtonSoundOff.Text = "Off";
            rdBtnButtonSoundOff.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnButtonSoundOff.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnButtonSoundOff.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxButtonSound.Controls.Add(rdBtnButtonSoundOff);

            grpBoxBackgroundSound.Location = new Point((((this.Width / 2) / 2) / 2) + 10, 150);
            grpBoxBackgroundSound.Size = new Size(115, 70);
            grpBoxBackgroundSound.Text = "Background Sound";
            grpBoxBackgroundSound.Name = "Background Sound Group Box";
            grpBoxBackgroundSound.BackColor = Color.AliceBlue;
            pnlConfig.Controls.Add(grpBoxBackgroundSound);

            //allows background sound to be turned on
            rdBtnBackgroundSoundOn.Location = new Point(10, 15);
            rdBtnBackgroundSoundOn.Click += (s, z) => { TurnBackgroundSoundOn(s, z); };
            rdBtnBackgroundSoundOn.Width = 40;
            rdBtnBackgroundSoundOn.Text = "On";
            rdBtnBackgroundSoundOn.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnBackgroundSoundOn.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnBackgroundSoundOn.Checked = true;
            rdBtnBackgroundSoundOn.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxBackgroundSound.Controls.Add(rdBtnBackgroundSoundOn);

            //allows background sound off
            rdBtnBackgroundSoundOff.Location = new Point(10, 40);
            rdBtnBackgroundSoundOff.Click += (s, z) => { TurnBackgroundSoundOff(s, z); };
            rdBtnBackgroundSoundOff.Width = 40;
            rdBtnBackgroundSoundOff.Text = "Off";
            rdBtnBackgroundSoundOff.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnBackgroundSoundOff.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnBackgroundSoundOff.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxBackgroundSound.Controls.Add(rdBtnBackgroundSoundOff);

            grpBoxMemoryTimer.Location = new Point((((this.Width / 2) / 2) / 2) + 10, 240);
            grpBoxMemoryTimer.Size = new Size(115, 70);
            grpBoxMemoryTimer.Visible = false;
            grpBoxMemoryTimer.Text = "Timer";
            grpBoxMemoryTimer.Name = "Memory Timer Group Box";
            grpBoxMemoryTimer.BackColor = Color.Orange;
            pnlConfig.Controls.Add(grpBoxMemoryTimer);

            //turns timer on
            rdBtnTimerOn.Location = new Point(10, 15);
            rdBtnTimerOn.Width = 40;
            rdBtnTimerOn.Text = "On";
            rdBtnTimerOn.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnTimerOn.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnTimerOn.Checked = true;
            rdBtnTimerOn.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxMemoryTimer.Controls.Add(rdBtnTimerOn);

            //turns timer off
            rdBtnTimerOff.Location = new Point(10, 40);
            rdBtnTimerOff.Width = 40;
            rdBtnTimerOff.Text = "Off";
            rdBtnTimerOff.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnTimerOff.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnTimerOff.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxMemoryTimer.Controls.Add(rdBtnTimerOff);
            
            grpBoxSequenceSpeed.Location = new Point((((this.Width / 2) / 2) / 2) + 10, 240);
            grpBoxSequenceSpeed.Size = new Size(115, 120);
            grpBoxSequenceSpeed.Text = "Speed";
            grpBoxSequenceSpeed.Visible = false;
            grpBoxSequenceSpeed.Name = "Sequence Speed Group Box";
            grpBoxSequenceSpeed.BackColor = Color.PaleGreen;
            pnlConfig.Controls.Add(grpBoxSequenceSpeed);

            //seqeunce speed at 200
            rdBtnSpeed200.Location = new Point(10, 15);
            rdBtnSpeed200.Width = 60;
            rdBtnSpeed200.Text = "200";
            rdBtnSpeed200.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnSpeed200.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnSpeed200.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxSequenceSpeed.Controls.Add(rdBtnSpeed200);

            //seqeunce speed at 300
            rdBtnSpeed300.Location = new Point(10, 40);
            rdBtnSpeed300.Width = 60;
            rdBtnSpeed300.Text = "300";
            rdBtnSpeed300.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnSpeed300.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnSpeed300.Checked = true;
            rdBtnSpeed300.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxSequenceSpeed.Controls.Add(rdBtnSpeed300);

            //seqeunce speed at 500
            rdBtnSpeed400.Location = new Point(10, 65);
            rdBtnSpeed400.Width = 60;
            rdBtnSpeed400.Text = "400";
            rdBtnSpeed400.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnSpeed400.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnSpeed400.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxSequenceSpeed.Controls.Add(rdBtnSpeed400);

            //seqeunce speed at 500
            rdBtnSpeed500.Location = new Point(10, 90);
            rdBtnSpeed500.Width = 60;
            rdBtnSpeed500.Text = "500";
            rdBtnSpeed500.TextAlign = ContentAlignment.MiddleLeft;
            rdBtnSpeed500.CheckAlign = ContentAlignment.MiddleLeft;
            rdBtnSpeed500.MouseDown += (s, z) => { PlaySound(s, z); };
            grpBoxSequenceSpeed.Controls.Add(rdBtnSpeed500);

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
            reflex = new targetPractice.Form1();
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

            if (memoryPlayed == true)
            {
                grpBoxMemoryTimer.Visible = true;

                if (rdBtnTimerOn.Checked == true)
                {
                    disposeTimer = false;
                }

                if (rdBtnTimerOff.Checked == true)
                {
                    disposeTimer = true;
                }

                if (disposeTimer == false)
                {
                    memory.t.Stop();
                    disposeTimer = true;
                }
            }

            if (sequencePlayed == true)
            {
                grpBoxSequenceSpeed.Visible = true;
            }

            pnlConfig.BringToFront();
            pnlConfig.Visible = true;
        }

        public int GetSpeed()
        {
            if (rdBtnSpeed200.Checked == true)
            {
                speed = 200;
            }
            if (rdBtnSpeed300.Checked == true)
            {
                speed = 300;
            }
            if (rdBtnSpeed400.Checked == true)
            {
                speed = 400;
            }
            if (rdBtnSpeed500.Checked == true)
            {
                speed = 500;
            }
            return speed;
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

            if (memoryPlayed == true)
            {
                grpBoxMemoryTimer.Visible = false;
            }

            if (sequencePlayed == true)
            {
                grpBoxSequenceSpeed.Visible = false;
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
                a.Open(new System.Uri(System.IO.Directory.GetCurrentDirectory() + "/Sounds/click.wav"));
                a.Play();
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

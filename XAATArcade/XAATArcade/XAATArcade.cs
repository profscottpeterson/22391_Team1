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
        Button btnSequence = new Button();
        Button btnMemory = new Button();
        Button game3 = new Button();
        Button game4 = new Button();
        Size formSize;
        System.Timers.Timer t = new System.Timers.Timer();
        Memory memory;
        Sequence sequence;

        // make backbutton availibale for all games
        // create battleship game
        // create config screen
        // popupbox
        // cancell doesn't do anything while in game
        // on setup cancel goes back to main page
        // timer off timmer on
        // difficulty easy timer set to 5 min
        // difficulty medium timer set to 3 min
        // difficulty hard timer set to 1:30 min

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
        }

        private void RemoveTitlePage()
        {
            this.Controls.Remove(pbTitle);
            this.Controls.Remove(btnSequence);
            this.Controls.Remove(btnMemory);
            this.Controls.Remove(game3);
            this.Controls.Remove(game4);
        }

        private void Memory(object sender, EventArgs e)
        {
            PlaySound();
            RemoveTitlePage();
            memory = new Memory(this, formSize);
        }

        private void Sequence(object sender, EventArgs e)
        {
            PlaySound();
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
            t.Stop();
            Application.DoEvents();
        }

        private void CreateConfig()
        {
            
        }

        //#region Hi
        // #endregion
    }
}

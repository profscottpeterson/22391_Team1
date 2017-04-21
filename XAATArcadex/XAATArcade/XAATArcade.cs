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
        public Font font;

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
            this.BackColor = Color.Black;
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
            btnSequence.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnSequence);

            btnMemory.Location = new Point(this.Width - this.Width + 30, 370);
            btnMemory.Size = new Size(350, 80);
            btnMemory.BackgroundImage = Properties.Resources.memory;
            btnMemory.Click += (s, z) => { Memory(s, z); };
            btnMemory.MouseHover += (s, z) => { MemoryHover(s, z); };
            btnMemory.MouseLeave += (s, z) => { MemoryMouseLeave(s, z); };
            btnMemory.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnMemory);

            game3.Location = new Point(this.Width - this.Width + 30, 430);
            game3.Size = new Size(350, 80);
            game3.BackgroundImage = Properties.Resources.reflex;
            game3.MouseHover += (s, z) => { ReflexHover(s, z); };
            game3.MouseLeave += (s, z) => { ReflexMouseLeave(s, z); };
            game3.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(game3);
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

        private void SequenceHover(object sender, EventArgs e)
        {
            btnSequence.BackgroundImage = Properties.Resources.sequencehover;
            pbTitle.Image = Properties.Resources.sequencegame;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
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

        private void SequenceMouseLeave(object sender, EventArgs e)
        {
            btnSequence.BackgroundImage = Properties.Resources.sequence;
            pbTitle.Image = Properties.Resources.xaatarcadetitle;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void ReflexHover(object sender, EventArgs e)
        {
           game3.BackgroundImage = Properties.Resources.reflexhover;
            pbTitle.Image = Properties.Resources.reflexgame;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void ReflexMouseLeave(object sender, EventArgs e)
        {
            game3.BackgroundImage = Properties.Resources.reflex;
            pbTitle.Image = Properties.Resources.xaatarcadetitle;
            pbTitle.SizeMode = PictureBoxSizeMode.CenterImage;
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

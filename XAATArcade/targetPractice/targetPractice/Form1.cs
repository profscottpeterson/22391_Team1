using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Timers;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace targetPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.loadFont();
            hitplayer.Stream = Properties.Resources.NFF_glassy_tap_02;
            missplayer.Stream = Properties.Resources.NFF_clog_up;
            hitplayer.Load();
            missplayer.Load();
            tBallMovement.Stop();
            tBallSizeChanger.Stop();
            tBallGenerator.Stop();
            this.btnStart.Enabled = true;
            this.btnStart.Visible = true;
            btnStart.BackColor = Color.White;
        }

        class DoubleBufferedPanel : Panel { public DoubleBufferedPanel() : base() { DoubleBuffered = true; } }

        int num_Balls_Hit, num_Balls_Missed = 0;
        List<Rectangle> ballList = new List<Rectangle>();
        List<Point> ballVelocity = new List<Point>();
        List<bool> ballIsGrowing = new List<bool>();
        Size formSize;
        Random rand = new Random();
        int h, m, s;
        List<Image> BallColors = new List<Image> {targetPractice.Properties.Resources.blue, targetPractice.Properties.Resources.red, targetPractice.Properties.Resources.green, targetPractice.Properties.Resources.yellow, targetPractice.Properties.Resources.orange, targetPractice.Properties.Resources.purple};
        List<int> BallSize = new List<int> { 80,70,60,50,40 };

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        System.Media.SoundPlayer hitplayer = new System.Media.SoundPlayer();
        System.Media.SoundPlayer missplayer = new System.Media.SoundPlayer();

        private void tBallGenerator_Tick(object sender, EventArgs e)
        {
            int width = 18;
            if (cbBallSize.SelectedIndex != -1)
            {
                width = BallSize[cbBallSize.SelectedIndex];
                ballList.Add(new Rectangle(
                    rand.Next(10, (formSize.Width - 30)),
                    rand.Next(10, (formSize.Height - panel1.Height) - 20),
                    width, width));
            }
            else
            {
                width = 18;
                ballList.Add(new Rectangle(
                    rand.Next(10, (formSize.Width - 30)),
                    rand.Next(10, (formSize.Height - panel1.Height) - 20),
                    width, width));
            }
            int vx = rand.Next(1, 8);
            int vy = rand.Next(1, 8);
            if (rand.Next(0, 2) == 0) vx = -vx;
            if (rand.Next(0, 2) == 0) vy = -vy;
            ballVelocity.Add(new Point(vx, vy));
            ballIsGrowing.Add(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Save the form's size.
            formSize = ClientSize;

            // Use double buffering to reduce flicker.
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            this.UpdateStyles();
            this.MouseDown += new MouseEventHandler(Form1_Click);
        }

        private void tBallMovement_Tick(object sender, EventArgs e)
        {
   
            for (int ball_num = 0; ball_num < ballList.Count; ball_num++)
            {
                int old_x = ballVelocity[ball_num].X;
                int reverse_x = -(ballVelocity[ball_num].X);
                int old_y = ballVelocity[ball_num].Y;
                int reverse_y = -(ballVelocity[ball_num].Y);

                // Move the ball.
                int new_x = ballList[ball_num].X + ballVelocity[ball_num].X;
                int new_y = ballList[ball_num].Y + ballVelocity[ball_num].Y;

                if (new_x < 0)
                {
                    ballVelocity[ball_num] = new Point(-ballVelocity[ball_num].X, ballVelocity[ball_num].Y);
                }
                else if (new_x + ballList[ball_num].Width >= formSize.Width)
                {
                    ballVelocity[ball_num] = new Point(-ballVelocity[ball_num].X, ballVelocity[ball_num].Y);
                    new_x = new_x + ballVelocity[ball_num].X;
                }
                if (new_y < 0)
                {
                    ballVelocity[ball_num] = new Point(ballVelocity[ball_num].X, -ballVelocity[ball_num].Y);
                }
                else if (new_y + ballList[ball_num].Height >= formSize.Height - panel1.Size.Height)
                {
                    ballVelocity[ball_num] = new Point(ballVelocity[ball_num].X, -ballVelocity[ball_num].Y);
                    new_y = new_y + ballVelocity[ball_num].Y;
                }

                ballList[ball_num] = new Rectangle(
                    new_x, new_y,
                    ballList[ball_num].Width,
                    ballList[ball_num].Height);
            }
            this.Refresh();
            formSize = ClientSize;
            lblScoreHit.Text = num_Balls_Hit.ToString();
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics c = e.Graphics;
            c.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            c.Clear(BackColor);
          
            for (int i = 0; i < ballList.Count; i++)
            {
                if (cbBallColor.SelectedIndex != -1)
                {
                    c.DrawImage(BallColors[cbBallColor.SelectedIndex], ballList[i].X, ballList[i].Y, ballList[i].Size.Height, ballList[i].Size.Width);
                } else
                c.DrawImage(targetPractice.Properties.Resources.target2, ballList[i].X, ballList[i].Y, ballList[i].Size.Height, ballList[i].Size.Width);
            }
        }

        private void tGameTime_Tick(object sender, EventArgs e)
        {
            if (cbBallSize.SelectedIndex == -1)
            {
                for (int ball_num = 0; ball_num < ballList.Count; ball_num++)
                {
                    int ballShrink = ballList[ball_num].Width;
                    int ballGrow = ballList[ball_num].Width;
                    ballGrow += 1;
                    ballShrink -= 1;
                    if (ballList[ball_num].Width <= 74 && ballIsGrowing[ball_num] == true)
                    {
                        ballList[ball_num] = new Rectangle(ballList[ball_num].X, ballList[ball_num].Y, ballGrow, ballGrow);
                    }
                    else if (ballList[ball_num].Width == 75)
                    {
                        ballList[ball_num] = new Rectangle(ballList[ball_num].X, ballList[ball_num].Y, ballShrink, ballShrink);
                        ballIsGrowing[ball_num] = false;
                    }
                    else if (ballList[ball_num].Width >= 16 && ballIsGrowing[ball_num] == false)
                    {

                        ballList[ball_num] = new Rectangle(ballList[ball_num].X, ballList[ball_num].Y, ballShrink, ballShrink);
                    }
                    else if (ballList[ball_num].Width < 16)
                    {
                        ballList.Remove(ballList[ball_num]);
                        ballVelocity.Remove(ballVelocity[ball_num]);
                        ballIsGrowing.Remove(ballIsGrowing[ball_num]);
                        num_Balls_Missed += 1;
                    }

                }
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled == true)
            {
                panel2.Enabled = false;
                panel2.Visible = false;
                tBallMovement.Stop();
                tBallGenerator.Stop();
                tBallSizeChanger.Stop();
                btnStart.Visible = true;
                btnStart.Enabled = true;
                this.Refresh();
            }
            else if (panel2.Enabled == false)
            {
                panel2.Enabled = true;
                panel2.Visible = true;
                tBallMovement.Stop();
                tBallGenerator.Stop();
                tBallSizeChanger.Stop();
                btnStart.Visible = true;
                btnStart.Enabled = true;
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ballList.Clear();
            //ballVelocity.Clear();
            //ballIsGrowing.Clear();
            btnStart.Enabled = true;
            btnStart.Visible = true;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel2.Enabled = false;
            this.Refresh();
        }

        private void cbBallSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ballList.Clear();
            ballVelocity.Clear();
            ballIsGrowing.Clear();
            btnStart.Enabled = true;
            btnStart.Visible = true;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ballList.Clear();
            ballVelocity.Clear();
            ballIsGrowing.Clear();
            btnStart.Enabled = true;
            btnStart.Visible = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ballList.Clear();
            ballVelocity.Clear();
            ballIsGrowing.Clear();
            btnStart.Enabled = true;
            btnStart.Visible = true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ballList.Clear();
            ballVelocity.Clear();
            ballIsGrowing.Clear();
            btnStart.Enabled = true;
            btnStart.Visible = true;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            ballList.Clear();
            ballVelocity.Clear();
            ballIsGrowing.Clear();
            btnStart.Enabled = true;
            btnStart.Visible = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tBallMovement.Start();
            tBallGenerator.Start();
            tBallSizeChanger.Start();
            btnStart.Visible = false;
            btnStart.Enabled = false;
            this.Refresh();
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            tBallMovement.Stop();
            tBallSizeChanger.Stop();
            tBallGenerator.Stop();
            Application.DoEvents();
        }

        private void loadFont()
        {
            byte[] fontArray = targetPractice.Properties.Resources._8_BITWONDER;
            int dataLength = targetPractice.Properties.Resources._8_BITWONDER.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFont = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFont);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];

            font = new Font(ff, 15f, FontStyle.Regular);

            lblScoreHit.Font = new Font(ff, 48, FontStyle.Regular);
            lblScoreHit.ForeColor = Color.Green;
            lblBallColor.Font = new Font(ff, 16, FontStyle.Regular);
            lblBallSpeed.Font = new Font(ff, 16, FontStyle.Regular);
            lblBallSize.Font = new Font(ff, 16, FontStyle.Regular);
            lblCursorType.Font = new Font(ff, 16, FontStyle.Regular);
            lblBallMovement.Font = new Font(ff, 16, FontStyle.Regular);
            btnStart.Font = new Font(ff, 16, FontStyle.Regular);
        }

        void Form1_Click(object sender, MouseEventArgs e)
        {
            bool ballhit = false;

            for (int ball_num = 0; ball_num < ballList.Count; ball_num++)
            {
                if (ballList[ball_num].Contains(e.Location))
                {
                    ballList.Remove(ballList[ball_num]);
                    ballVelocity.Remove(ballVelocity[ball_num]);
                    ballIsGrowing.Remove(ballIsGrowing[ball_num]);
                    num_Balls_Hit += 1;
                    ballhit = true;
                    hitplayer.Play();
                }
            }

            if (ballhit == false)
            {
                num_Balls_Missed += 1;
                missplayer.Play();
            }
        }

    }
}

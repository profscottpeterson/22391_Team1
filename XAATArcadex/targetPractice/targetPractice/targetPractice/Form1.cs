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
            //this.Click += this.checkIfHit;
            this.loadFont();
        }

        class DoubleBufferedPanel : Panel { public DoubleBufferedPanel() : base() { DoubleBuffered = true; } }

        int num_Balls_Hit, num_Balls_Missed = 0;
        List<Rectangle> ballList = new List<Rectangle>();
        List<Point> ballVelocity = new List<Point>();
        List<bool> ballIsGrowing = new List<bool>();
        Size formSize;
        Random rand = new Random();
        System.Timers.Timer t;
        int h, m, s;

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        private void tBallGenerator_Tick(object sender, EventArgs e)
        {
            int width = 18;
            ballList.Add(new Rectangle(
                rand.Next(10, (formSize.Width - 30)),
                rand.Next(10, (formSize.Height - panel1.Height) - 20),
                width, width));
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
             
            t = new System.Timers.Timer();
            t.Interval = 10;
            t.Elapsed += onTimeEvent;
            t.Start();
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
            lblScoreMissed.Text = num_Balls_Missed.ToString();
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics c = e.Graphics;
            c.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            c.Clear(BackColor);
          
            for (int i = 0; i < ballList.Count; i++)
            {
                
                c.DrawImage(targetPractice.Properties.Resources.target2, ballList[i].X, ballList[i].Y, ballList[i].Size.Height, ballList[i].Size.Width);
                c.DrawString(i.ToString(), new Font("Tahoma", 8), Brushes.Orange, ballList[i]);
            }
        }

        private void tGameTime_Tick(object sender, EventArgs e)
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
                }else if (ballList[ball_num].Width == 75)
                {
                    ballList[ball_num] = new Rectangle(ballList[ball_num].X, ballList[ball_num].Y, ballShrink, ballShrink);
                    ballIsGrowing[ball_num] = false;
                }else if (ballList[ball_num].Width >= 16 && ballIsGrowing[ball_num] == false)
                {

                    ballList[ball_num] = new Rectangle(ballList[ball_num].X, ballList[ball_num].Y, ballShrink, ballShrink);
                }else if (ballList[ball_num].Width < 16)
                {
                    ballList.Remove(ballList[ball_num]);
                    ballVelocity.Remove(ballVelocity[ball_num]);
                    ballIsGrowing.Remove(ballIsGrowing[ball_num]);
                    num_Balls_Missed += 1;
                    lblScoreMissed.Text = num_Balls_Missed.ToString();
                }

            }
        }

        private void onTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }

                lblTimer.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));

            if (h == 2)
            {
                t.Stop();
                tBallMovement.Stop();
                tBallGenerator.Stop();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
            tBallGenerator.Stop();
        }

        //private void Form1_Closing(object sender, FormClosingEventArgs e)
        //{
        //    t.Stop();
        //    Application.DoEvents();
        //}

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

            lblTimer.Font = new Font(ff, 28, FontStyle.Regular);
            lblScoreHit.Font = new Font(ff, 28, FontStyle.Regular);
            lblScoreMissed.Font = new Font(ff, 28, FontStyle.Regular);
            lblScoreMissed.ForeColor = Color.Red;
            lblScoreHit.ForeColor = Color.Green;

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
                }
            }

            if (ballhit == false)
            {
                num_Balls_Missed += 1;
            }
        }

    }
}

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

namespace targetPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Click += this.checkIfHit;
        }

        class DoubleBufferedPanel : Panel { public DoubleBufferedPanel() : base() { DoubleBuffered = true; } }

        int num_Balls = 0;
        List<Rectangle> ballList = new List<Rectangle>();
        List<Point> ballVelocity = new List<Point>();
        Size formSize;
        Random rand = new Random();
        System.Timers.Timer t;
        int h, m, s;

        private void tBallGenerator_Tick(object sender, EventArgs e)
        {
            int width = rand.Next(10, 40);
            ballList.Add(new Rectangle(
                rand.Next(10, 700 - 3 * width),
                rand.Next(10, 700 - 3 * width),
                width, width));
            int vx = rand.Next(2, 10);
            int vy = rand.Next(2, 10);
            if (rand.Next(0, 2) == 0) vx = -vx;
            if (rand.Next(0, 2) == 0) vy = -vy;
            ballVelocity.Add(new Point(vx, vy));
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
                int new_x = ballList[ball_num].X +
                    ballVelocity[ball_num].X;
                int new_y = ballList[ball_num].Y +
                    ballVelocity[ball_num].Y;
                if (new_x < 0)
                {
                    ballVelocity[ball_num] = new Point(-ballVelocity[ball_num].X, ballVelocity[ball_num].Y);
                }
                else if (new_x + ballList[ball_num].Width >
                    formSize.Width)
                {
                    ballVelocity[ball_num] = new Point(-ballVelocity[ball_num].X, ballVelocity[ball_num].Y);
                }
                if (new_y < 0 + 10)
                {
                    ballVelocity[ball_num] = new Point(ballVelocity[ball_num].X, -ballVelocity[ball_num].Y);
                }
                else if (new_y + ballList[ball_num].Height >
                    formSize.Height - 190)
                {
                    ballVelocity[ball_num] = new Point(ballVelocity[ball_num].X, -ballVelocity[ball_num].Y);
                }

                ballList[ball_num] = new Rectangle(
                    new_x, new_y,
                    ballList[ball_num].Width,
                    ballList[ball_num].Height);
            }
            this.Refresh();
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics c = e.Graphics;
            c.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            c.Clear(BackColor);

            //Bitmap backgroundImage = new Bitmap(targetPractice.Properties.Resources.backgroun2); 
            //e.Graphics.DrawImage(backgroundImage, this.ClientRectangle,
       // new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height),
        //GraphicsUnit.Pixel);
          
            for (int i = 0; i < ballList.Count; i++)
            {
                c.DrawImage(targetPractice.Properties.Resources.target1, ballList[i].X, ballList[i].Y, ballList[i].Size.Height, ballList[i].Size.Width);
            }
        }

        private void tGameTime_Tick(object sender, EventArgs e)
        {

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

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }
    }
}

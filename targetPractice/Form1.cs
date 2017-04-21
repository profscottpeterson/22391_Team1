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

namespace targetPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int num_Balls = 0;
        List<Rectangle> ballList = new List<Rectangle>();
        List<Point> ballVelocity = new List<Point>();
        Size formSize;
        Random rand = new Random();

        private void tBallGenerator_Tick(object sender, EventArgs e)
        {
            int width = rand.Next(10, 40);
            ballList.Add(new Rectangle(
                rand.Next(0, ClientSize.Width - 2 * width),
                rand.Next(0, ClientSize.Height - 2 * width),
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
                if (new_y < 0)
                {
                    ballVelocity[ball_num] = new Point(ballVelocity[ball_num].X, -ballVelocity[ball_num].Y);
                }
                else if (new_y + ballList[ball_num].Height >
                    formSize.Height)
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
            for (int i = 0; i < ballList.Count; i++)
            {
                c.FillEllipse(Brushes.Red, ballList[i]);
                c.DrawEllipse(Pens.Black, ballList[i]);
            }
        }

        private void tGameTime_Tick(object sender, EventArgs e)
        {

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            foreach (Rectangle obj in ballList)
            {
               // if (obj.)
                //{
                    //Do Something
                //}
            }
        }
    }
}

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
    public class tpTest
    {
        public List<Rectangle> ballListTest = new List<Rectangle>();
        public List<Point> ballVelocityTest = new List<Point>();
        public List<bool> ballIsGrowingTest = new List<bool>();
        public int num_Balls_HitTest, num_Balls_MissedTest;
        public System.Media.SoundPlayer hitplayerTest = new System.Media.SoundPlayer();
        public System.Media.SoundPlayer missplayerTest = new System.Media.SoundPlayer();
        public System.Timers.Timer tBallMovementTest = new System.Timers.Timer();
        public System.Timers.Timer tBallSizeChangerTest = new System.Timers.Timer();
        public System.Timers.Timer tBallGeneratorTest = new System.Timers.Timer();
        public Button btnStartTest = new Button();
        public Panel pnlOptoinsMenuTest = new Panel();
        public Panel pnlGameOverTest = new Panel();
        public Random rand = new Random();
        public List<Image> BallColorsTest = new List<Image> { targetPractice.Properties.Resources.blue, targetPractice.Properties.Resources.red, targetPractice.Properties.Resources.green, targetPractice.Properties.Resources.yellow, targetPractice.Properties.Resources.orange, targetPractice.Properties.Resources.purple, targetPractice.Properties.Resources.pokeball };
        public List<int> BallSizeTest = new List<int> { 80, 70, 60, 50, 40 };
        public PictureBox pbLife1 = new PictureBox();
        public int gameLives = 3;
        public ComboBox cbBallSizeTest = new ComboBox();
        public CheckBox cbDisableMovementTest = new CheckBox();
        public ComboBox cbBallColorTest = new ComboBox();
        public Graphics c;
        public Form testform = new Form();    

        public void ResetGameTest()
        {
            ballListTest.Clear();
            ballVelocityTest.Clear();
            ballIsGrowingTest.Clear();
            ShowStartBtnTest();
            num_Balls_HitTest = 0;
            num_Balls_MissedTest = 0;
            HideGameOverTest();
        }

        public void CheckForHitTest(MouseEventArgs e)
        {
            bool ballhit = false;

            for (int ball_num = 0; ball_num < ballListTest.Count; ball_num++)
            {
                if (ballListTest[ball_num].Contains(e.Location))
                {
                    ballListTest.Remove(ballListTest[ball_num]);
                    ballVelocityTest.Remove(ballVelocityTest[ball_num]);
                    if (cbBallSizeTest.SelectedIndex > -1)
                    {

                    }
                    else
                    {
                        ballIsGrowingTest.Remove(ballIsGrowingTest[ball_num]);
                    }
                    num_Balls_HitTest += 1;
                    ballhit = true;
                    hitplayerTest.Play();
                }
            }

            if (ballhit == false)
            {
                num_Balls_MissedTest += 1;
                RemoveLifeTest();
            }
        }

        public void StopTimersTest()
        {
            tBallMovementTest.Stop();
            tBallSizeChangerTest.Stop();
            tBallGeneratorTest.Stop();
        }

        public void StartTimersTest()
        {
            tBallMovementTest.Start();
            tBallGeneratorTest.Start();
            tBallSizeChangerTest.Start();
        }

        public void ShowStartBtnTest()
        {
            btnStartTest.Visible = true;
            btnStartTest.Enabled = true;
        }

        public void HideStartBtnTest()
        {
            btnStartTest.Visible = false;
            btnStartTest.Enabled = false;
        }

        public void ShowOptionsTest()
        {
            pnlOptoinsMenuTest.Enabled = true;
            pnlOptoinsMenuTest.Visible = true;
        }

        public void HideOptionsTest()
        {
            pnlOptoinsMenuTest.Visible = false;
            pnlOptoinsMenuTest.Enabled = false;
        }

        public void ShowGameOverTest()
        {
            pnlGameOverTest.Enabled = true;
            pnlGameOverTest.Visible = true;
        }

        public void HideGameOverTest()
        {
            pnlGameOverTest.Enabled = false;
            pnlGameOverTest.Visible = false;
        }

        public void MakeBallTest()
        {
            //size of target variable
            int width;

            //velocity of target variable
            int vx, vy;

            //default size
            width = 18;
            ballListTest.Add(new Rectangle(rand.Next(10, 10), rand.Next(10, 10), width, width));

            // add growing flag 
            ballIsGrowingTest.Add(true);
       
            vx = rand.Next(1, 1);
            vy = rand.Next(1, 1);

            ballVelocityTest.Add(new Point(vx, vy));
        }

        public void MoveBallTest()
        {
            for (int ball_num = 0; ball_num < ballListTest.Count; ball_num++)
            {
                int old_x = ballVelocityTest[ball_num].X;
                int reverse_x = -(ballVelocityTest[ball_num].X);
                int old_y = ballVelocityTest[ball_num].Y;
                int reverse_y = -(ballVelocityTest[ball_num].Y);

                // Move the ball.
                int new_x = ballListTest[ball_num].X + ballVelocityTest[ball_num].X;
                int new_y = ballListTest[ball_num].Y + ballVelocityTest[ball_num].Y;

                if (new_x < 0)
                {
                    ballVelocityTest[ball_num] = new Point(-ballVelocityTest[ball_num].X, ballVelocityTest[ball_num].Y);
                }
                else if (new_x + ballListTest[ball_num].Width >= 200)
                {
                    ballVelocityTest[ball_num] = new Point(-ballVelocityTest[ball_num].X, ballVelocityTest[ball_num].Y);
                    new_x = new_x + ballVelocityTest[ball_num].X;
                }
                if (new_y < 0)
                {
                    ballVelocityTest[ball_num] = new Point(ballVelocityTest[ball_num].X, -ballVelocityTest[ball_num].Y);
                }
                else if (new_y + ballListTest[ball_num].Height >= 200)
                {
                    ballVelocityTest[ball_num] = new Point(ballVelocityTest[ball_num].X, -ballVelocityTest[ball_num].Y);
                    new_y = new_y + ballVelocityTest[ball_num].Y;
                }

                ballListTest[ball_num] = new Rectangle(
                    new_x, new_y,
                    ballListTest[ball_num].Width,
                    ballListTest[ball_num].Height);
            }
        }

        public void RemoveLifeTest()
        {
            pbLife1.Visible = false;
            gameLives -= 3;
        }

        public void RestockLivesTest()
        {
            gameLives = 3;
            pbLife1.Visible = true;
        
        }

        public void TargetResizerTest()
        {
            if (cbBallSizeTest.SelectedIndex == -1)
            {
                for (int ball_num = 0; ball_num < ballListTest.Count; ball_num++)
                {
                    int ballShrink = ballListTest[ball_num].Width;
                    int ballGrow = ballListTest[ball_num].Width;
                    ballGrow += 1;
                    ballShrink -= 1;
                    if (ballListTest[ball_num].Width <= 74 && ballIsGrowingTest[ball_num] == true)
                    {
                        ballListTest[ball_num] = new Rectangle(ballListTest[ball_num].X, ballListTest[ball_num].Y, ballGrow, ballGrow);
                    }
                    else if (ballListTest[ball_num].Width == 75 && ballIsGrowingTest[ball_num] == true)
                    {
                        //ballList[ball_num] = new Rectangle(ballList[ball_num].X, ballList[ball_num].Y, ballShrink, ballShrink);
                        ballIsGrowingTest[ball_num] = false;
                    }
                    else if (ballListTest[ball_num].Width >= 16 && ballIsGrowingTest[ball_num] == false)
                    {

                        ballListTest[ball_num] = new Rectangle(ballListTest[ball_num].X, ballListTest[ball_num].Y, ballShrink, ballShrink);
                    }
                    else if (ballListTest[ball_num].Width < 16)
                    {
                        ballListTest.Remove(ballListTest[ball_num]);
                        ballVelocityTest.Remove(ballVelocityTest[ball_num]);
                        ballIsGrowingTest.Remove(ballIsGrowingTest[ball_num]);
                        num_Balls_MissedTest += 1;
                        RemoveLifeTest();
                        missplayerTest.Play();
                    }

                }
            }
            else
            {

            }
        }

        public void TargetDrawerTest()
        {
            c = testform.CreateGraphics();
            c.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
           
            for (int i = 0; i < ballListTest.Count; i++)
            {
                if (cbBallColorTest.SelectedIndex != -1)
                {
                    c.DrawImage(BallColorsTest[cbBallColorTest.SelectedIndex], ballListTest[i].X, ballListTest[i].Y, ballListTest[i].Size.Height, ballListTest[i].Size.Width);
                }
                else
                    c.DrawImage(targetPractice.Properties.Resources.target2, ballListTest[i].X, ballListTest[i].Y, ballListTest[i].Size.Height, ballListTest[i].Size.Width);
            }
        }
    }
}

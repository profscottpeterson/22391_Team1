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
/// <summary>
/// Form for the target pratice
/// </summary>
namespace targetPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.loadFont();
            //streaming the different sounds
            hitplayer.Stream = Properties.Resources.NFF_glassy_tap_02;
            missplayer.Stream = Properties.Resources.NFF_clog_up;
            hitplayer.Load();
            missplayer.Load();
            hitplayer.Play();
            missplayer.Play();
            tBallMovement.Stop();
            tBallSizeChanger.Stop();
            tBallGenerator.Stop();
            this.btnStart.Enabled = true;
            this.btnStart.Visible = true;
            btnStart.BackColor = Color.White;
        }

        class DoubleBufferedPanel : Panel { public DoubleBufferedPanel() : base() { DoubleBuffered = true; } }

        int num_Balls_Hit, num_Balls_Missed = 0;

        int gameLives = 3;

        // List of targets
        List<Rectangle> ballList = new List<Rectangle>();

        // List of targets Velocity Parallel to BallList
        List<Point> ballVelocity = new List<Point>();

        // List of Flag for target growth and shrinking PArallel to ballList and ballVelocity
        List<bool> ballIsGrowing = new List<bool>();

        Size formSize;

        Random rand = new Random();

        List<Image> BallColors = new List<Image> {targetPractice.Properties.Resources.blue, targetPractice.Properties.Resources.red, targetPractice.Properties.Resources.green, targetPractice.Properties.Resources.yellow, targetPractice.Properties.Resources.orange, targetPractice.Properties.Resources.purple, targetPractice.Properties.Resources.pokeball};
        List<int> BallSize = new List<int> { 80,70,60,50,40 };

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;

        System.Media.SoundPlayer hitplayer = new System.Media.SoundPlayer();
        System.Media.SoundPlayer missplayer = new System.Media.SoundPlayer();

        private void tBallGenerator_Tick(object sender, EventArgs e)
        {
            MakeBall(cbSpeed.SelectedIndex);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Save the form's size.
            formSize = ClientSize;

            SetFormToDoubleBuffer();

            this.MouseDown += new MouseEventHandler(Ball_Click);
        }

        private void tBallMovement_Tick(object sender, EventArgs e)
        {
            if (cbDisableMovement.Checked == true)
            {
            }
            else
            {
                MoveBall();
            }

            this.Refresh();

            formSize = ClientSize;

            lblScoreHit.Text = num_Balls_Hit.ToString();

            if (gameLives == 0 || ballList.Count >= 10)
            {
                StopTimers();
                ShowGameOver();
            }
            
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            TargetDrawer(e);
        }

        private void tGameTime_Tick(object sender, EventArgs e)
        {
            TargetResizer();
        }

        private void btnOptionsMenu_Click(object sender, EventArgs e)
        {
            if (pnlOptoinsMenu.Enabled == true)
            {
                HideOptions();
                ShowStartBtn();
                this.Refresh();
            }
            else if (pnlOptoinsMenu.Enabled == false)
            {
                ShowOptions();
                StopTimers();
            }

        }

        private void btnOptionsExit_Click(object sender, EventArgs e)
        {
            HideOptions();
            ShowStartBtn();
            this.Refresh();
        }

        private void cbBallColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStartBtn();
        }

        private void cbBallSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void cbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void cbCursorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCursorType.SelectedIndex == -1)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Cross;
            }
        }

        private void cbBallMovement_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void cbSpawnSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            RestockLives();
            StartTimers();
            HideStartBtn();
            this.Refresh();
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            StopTimers();
            Application.DoEvents();
        }

        private void Ball_Click(object sender, MouseEventArgs e)
        {
            CheckForHit(e);
        }

        private void DisableMovement_CheckedChanged(object sender, EventArgs e)
        {
            ResetGame();
            cbBallSize.SelectedIndex = 0;

        }

        /// <summary>
        /// Game Methods
        /// </summary>
        private void ResetGame()
        {
            ballList.Clear();
            ballVelocity.Clear();
            ballIsGrowing.Clear();
            ShowStartBtn();
            num_Balls_Hit = 0;
            num_Balls_Missed = 0;
            HideGameOver();
        }

        private void CheckForHit(MouseEventArgs e)
        {
            bool ballhit = false;

            for (int ball_num = 0; ball_num < ballList.Count; ball_num++)
            {
                if (ballList[ball_num].Contains(e.Location))
                {
                    ballList.Remove(ballList[ball_num]);
                    ballVelocity.Remove(ballVelocity[ball_num]);
                    if(cbDisableMovement.Checked == true)
                    {

                    }
                    else
                    {
                        ballIsGrowing.Remove(ballIsGrowing[ball_num]);
                    }
                    num_Balls_Hit += 1;
                    ballhit = true;
                    hitplayer.Play();
                }
            }

            if (ballhit == false)
            {
                num_Balls_Missed += 1;
                missplayer.Play();
                RemoveLife();
            }
        }

        private void StopTimers()
        {
            tBallMovement.Stop();
            tBallSizeChanger.Stop();
            tBallGenerator.Stop();
        }

        private void StartTimers()
        {
            tBallMovement.Start();
            tBallGenerator.Start();
            tBallSizeChanger.Start();
        }

        private void ShowStartBtn()
        {
            btnStart.Visible = true;
            btnStart.Enabled = true;
        }

        private void HideStartBtn()
        {
            btnStart.Visible = false;
            btnStart.Enabled = false;
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
            lblBallSpawnSpeed.Font = new Font(ff, 16, FontStyle.Regular);
            btnStart.Font = new Font(ff, 16, FontStyle.Regular);
            lblGOScore.Font = new Font(ff, 30, FontStyle.Regular);
            cbDisableMovement.Font = new Font(ff, 16, FontStyle.Regular);
        }

        private void ShowOptions()
        {
            pnlOptoinsMenu.Enabled = true;
            pnlOptoinsMenu.Visible = true;
        }

        private void HideOptions()
        {
            pnlOptoinsMenu.Visible = false;
            pnlOptoinsMenu.Enabled = false;
        }

        private void ShowGameOver()
        {
            pnlGameOver.Enabled = true;
            pnlGameOver.Visible = true;
        }

        private void HideGameOver()
        {
            pnlGameOver.Enabled = false;
            pnlGameOver.Visible = false;
        }

        private void MakeBall(int Speed) {
            //size of target
            int width;

            //velocity of target
            int vx, vy;

            if (cbBallSize.SelectedIndex != -1)
            {
                if (cbDisableMovement.Checked == true)
                {
                    int x, y;
                    Rectangle target;
                    x = rand.Next(10, (formSize.Width - 60));
                    y = rand.Next(10, (formSize.Height - pnlHUD.Height) - 40);
                     
                    foreach (var rect in ballList)
                    {
                        width = BallSize[cbBallSize.SelectedIndex];

                        target = new Rectangle(x, y, width, width);
                        
                        if (rect.Contains(target)) {
                            x = rand.Next(10, (formSize.Width - 60));
                            y = rand.Next(10, (formSize.Height - pnlHUD.Height) - 40);
                        }

                        foreach (var rectt in ballList)
                        {
                             target = new Rectangle(x, y, width, width);

                            if (rectt.Contains(target))
                            {
                                x = rand.Next(10, (formSize.Width - 60));
                                y = rand.Next(10, (formSize.Height - pnlHUD.Height) - 40);
                            }
                        }

                    }

                    //if size is picked and no ball movement // try to avoid overlapping
                    width = BallSize[cbBallSize.SelectedIndex];
                    ballList.Add(new Rectangle(x, y, width, width));
                }
                else
                {
                    //if sized is picked and there is still movement in targets
                    width = BallSize[cbBallSize.SelectedIndex];
                    ballList.Add(new Rectangle(
                        rand.Next(10, (formSize.Width - 60)),
                        rand.Next(10, (formSize.Height - pnlHUD.Height) - 40),
                        width, width));
                }
                
            }
            else
            {
                //default size
                width = 18;
                ballList.Add(new Rectangle(
                    rand.Next(10, (formSize.Width - 60)),
                    rand.Next(10, (formSize.Height - pnlHUD.Height) - 40),
                    width, width));
                // add growing flag 
                ballIsGrowing.Add(true);
            }

            //set speed of target
            if (Speed == -1) {
                //default
                vx = rand.Next(1, 5);
                vy = rand.Next(1, 5);
            }
            else
            {
                //if speed is picked
                int ActualSpeed;
                ActualSpeed = Speed + 1;
                vx = ActualSpeed;
                vy = ActualSpeed;
            }

            //randomize velocity direction
            if (rand.Next(0, 2) == 0) vx = -vx;
            if (rand.Next(0, 2) == 0) vy = -vy;

            ballVelocity.Add(new Point(vx, vy));
        }

        private void btnGOReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void MoveBall()
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
                else if (new_y + ballList[ball_num].Height >= formSize.Height - pnlHUD.Size.Height)
                {
                    ballVelocity[ball_num] = new Point(ballVelocity[ball_num].X, -ballVelocity[ball_num].Y);
                    new_y = new_y + ballVelocity[ball_num].Y;
                }

                ballList[ball_num] = new Rectangle(
                    new_x, new_y,
                    ballList[ball_num].Width,
                    ballList[ball_num].Height);
            }
        }

        private void RemoveLife()
        {
            if (gameLives > 0)
            {
                string box = "pbLife" + gameLives;
                pnlHUD.Controls[box].Visible = false;
                gameLives -= 1;
            }
        }

        private void RestockLives()
        {
            gameLives = 3;
            for (int i = 3; i > 0; i--)
            {
                string box = "pbLife" + i;
                pnlHUD.Controls[box].Visible = true;
            }
        }

        private void TargetResizer()
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
                    else if (ballList[ball_num].Width == 75 && ballIsGrowing[ball_num] == true)
                    {
                        //ballList[ball_num] = new Rectangle(ballList[ball_num].X, ballList[ball_num].Y, ballShrink, ballShrink);
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
                        RemoveLife();
                        missplayer.Play();
                    }

                }
            }
            else
            {

            }
        }

        private void TargetDrawer(PaintEventArgs e)
        {
            Graphics c = e.Graphics;
            c.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            c.Clear(BackColor);

            for (int i = 0; i < ballList.Count; i++)
            {
                if (cbBallColor.SelectedIndex != -1)
                {
                    c.DrawImage(BallColors[cbBallColor.SelectedIndex], ballList[i].X, ballList[i].Y, ballList[i].Size.Height, ballList[i].Size.Width);
                }
                else
                    c.DrawImage(targetPractice.Properties.Resources.target2, ballList[i].X, ballList[i].Y, ballList[i].Size.Height, ballList[i].Size.Width);
            }
        }

        private void SetFormToDoubleBuffer()
        {
            // Use double buffering to reduce flicker.
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            this.UpdateStyles();
        }
    }

}

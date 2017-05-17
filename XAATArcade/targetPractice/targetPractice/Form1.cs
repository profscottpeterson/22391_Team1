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
        

        class DoubleBufferedPanel : Panel { public DoubleBufferedPanel() : base() { DoubleBuffered = true; } }
        //variables for number of balls hit and missed
        int num_Balls_Hit, num_Balls_Missed = 0;
        // variable to hold game lives
        int gameLives = 3;

        // List of targets
        List<Rectangle> ballList = new List<Rectangle>();

        // List of targets Velocity Parallel to BallList
        List<Point> ballVelocity = new List<Point>();

        // List of Flag for target growth and shrinking PArallel to ballList and ballVelocity
        List<bool> ballIsGrowing = new List<bool>();

        //variable to hold form size
        Size formSize;

        //initilization of random
        Random rand = new Random();

        // lists for ball size and an image list to hold different target colors and their resourse location
        List<Image> BallColors = new List<Image> {targetPractice.Properties.Resources.blue, targetPractice.Properties.Resources.red, targetPractice.Properties.Resources.green, targetPractice.Properties.Resources.yellow, targetPractice.Properties.Resources.orange, targetPractice.Properties.Resources.purple, targetPractice.Properties.Resources.pokeball};
        List<int> BallSize = new List<int> { 80,70,60,50,40 };

        // DLL GDI32 in order to load fonts into memeory
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);
        //font variables
        FontFamily ff;
        Font font;
        // sound players for hit sound miss sound and end of ball life sound
        System.Media.SoundPlayer hitplayer = new System.Media.SoundPlayer();
        System.Media.SoundPlayer missplayer = new System.Media.SoundPlayer();
        System.Media.SoundPlayer endplayer = new System.Media.SoundPlayer();

        // various things set when form is created
        public Form1()
        {
            InitializeComponent();
            this.loadFont();
            //streaming the different sounds
            hitplayer.Stream = Properties.Resources.NFF_glassy_tap_02;
            missplayer.Stream = Properties.Resources.NFF_clog_up;
            endplayer.Stream = Properties.Resources.bloop_x;
            //loading different sounds
            hitplayer.Load();
            missplayer.Load();
            // Playing each sound once to avoid skipping
            hitplayer.Play();
            missplayer.Play();
            endplayer.Play();
            // disable timers at start
            tBallMovement.Stop();
            tBallSizeChanger.Stop();
            tBallGenerator.Stop();
            // enable start button at form load
            this.btnStart.Enabled = true;
            this.btnStart.Visible = true;
            // set btnStart back color
            btnStart.BackColor = Color.White;
        }
        // Timer tBallGenerator tick event method
        private void tBallGenerator_Tick(object sender, EventArgs e)
        {
            //method to make targets 
            MakeBall(cbSpeed.SelectedIndex);
        }
        // form load event (things done when the form loads)
        private void Form1_Load(object sender, EventArgs e)
        {
            // Save the form's size.
            formSize = ClientSize;
            // set form to double buffer to avoid flickering
            SetFormToDoubleBuffer();
            // set mouse event of mouse left and right down to Ball_Click Method
            this.MouseDown += new MouseEventHandler(Ball_Click);
        }
        // timer tBallMovement tick event
        private void tBallMovement_Tick(object sender, EventArgs e)
        {
            // if disable movement is checked avoid using MoveBall() method
            if (cbDisableMovement.Checked == true)
            {
            }
            // if disable movement is not checked use MoveBall()
            else
            {
                MoveBall();
            }

            // refresh form to activate paint event and redraw the form
            this.Refresh();

            // set formSize to ClientSize for various math
            formSize = ClientSize;

            // set lblScoreHit to the num_Balls_Hit counter
            lblScoreHit.Text = num_Balls_Hit.ToString();

            // check for end of game with 0 lives or if ballList has a count = or greater than 10
            if (gameLives == 0 || ballList.Count >= 10)
            {
                // stop timer method stops timers
                StopTimers();
                // show game over screen
                ShowGameOver();
            }
            
        }
        // form1 paint event uses TargetDrawer method
        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            // targetDrawer method to paint targets to be shown when screen refreshes
            TargetDrawer(e);
        }

        // tGameTime tick event that resizes targets when needed
        private void tGameTime_Tick(object sender, EventArgs e)
        {
            // targetResizer method used to change size of targets
            TargetResizer();
        }

        // Options menu button click event
        private void btnOptionsMenu_Click(object sender, EventArgs e)
        {
            // check if options menu is already open
            if (pnlOptoinsMenu.Enabled == true)
            {
                HideOptions();
                ShowStartBtn();
                // reset game
                ResetGame();
                // refresh form1 to show no targets in backgorund
                this.Refresh();
            }
            // else if options menu is not open
            else if (pnlOptoinsMenu.Enabled == false)
            {
                ShowOptions();
                StopTimers();
                ResetGame();
                HideStartBtn();
            }

        }
        // click event for exit button on options menu
        private void btnOptionsExit_Click(object sender, EventArgs e)
        {
            HideOptions();
            ShowStartBtn();
            this.Refresh();
        }

        // comboBox CursorType selected index changed (option selected other than default)
        private void cbCursorType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbCursorType.SelectedIndex == -1)
            {
                this.Cursor = Cursors.Default;
            }
            else if(cbCursorType.SelectedIndex == 0)
            {
                this.Cursor = Cursors.Cross;
            }
            else if(cbCursorType.SelectedIndex == 1)
            {
                this.Cursor = Cursors.Default;
            }
        } 

        // if spawnspeed is changed
        private void cbSpawnSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if statement to find selected index that was chosen and set 
            // tballGenerator interval (ms)
            if (cbSpawnSpeed.SelectedIndex == 0)
            {
                tBallGenerator.Interval = 700;
            }
            else if (cbSpawnSpeed.SelectedIndex == 1)
            {
                tBallGenerator.Interval = 650;
            }
            else if (cbSpawnSpeed.SelectedIndex == 2)
            {
                tBallGenerator.Interval = 600;
            }
            else if (cbSpawnSpeed.SelectedIndex == 3)
            {
                tBallGenerator.Interval = 550;
            }
            else if (cbSpawnSpeed.SelectedIndex == 4)
            {
                tBallGenerator.Interval = 500;
            }
        }

        // click event for btnStart
        private void btnStart_Click(object sender, EventArgs e)
        {
            // various methods to get game started
            RestockLives();
            StartTimers();
            HideStartBtn();
            this.Refresh();
        }

        // form closing event that stops timers and does any events that havnt been done yet
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            StopTimers();
            Application.DoEvents();
        }

        // click method for form1 to check if a target is ever hit
        private void Ball_Click(object sender, MouseEventArgs e)
        {
            CheckForHit(e);
        }

        // method for when disable movement is clicked
        private void DisableMovement_CheckedChanged(object sender, EventArgs e)
        {
            // if disable movement is clicked auto turn off default of targets growing and shrinking
            cbBallSize.SelectedIndex = 0;

        }

        /// <summary>
        /// Game Methods
        /// </summary>
        /// method ResetGame Resets game to get ready for a new one
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
        // check for hit checks mouse location walks through targets and checks if any of the targets
        // or graphics contain the supplied mouse location
        private void CheckForHit(MouseEventArgs e)
        {
            bool ballhit = false;

            for (int ball_num = 0; ball_num < ballList.Count; ball_num++)
            {
                if (ballList[ball_num].Contains(e.Location))
                {
                    ballList.Remove(ballList[ball_num]);
                    ballVelocity.Remove(ballVelocity[ball_num]);
                    if(cbBallSize.SelectedIndex > -1)
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
        // method StopTimers stops all timers
        private void StopTimers()
        {
            tBallMovement.Stop();
            tBallSizeChanger.Stop();
            tBallGenerator.Stop();
        }
        // method StartTimers enables and starts all timers
        private void StartTimers()
        {
            tBallMovement.Start();
            tBallGenerator.Start();
            tBallSizeChanger.Start();
        }
        // method showStartBtn makes the start button visable and enabled
        private void ShowStartBtn()
        {
            btnStart.Visible = true;
            btnStart.Enabled = true;
        }
        // method HideStartBtn makes the start button hidden and disabled
        private void HideStartBtn()
        {
            btnStart.Visible = false;
            btnStart.Enabled = false;
        }
        // method to load custom font into memeory
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
            lblGOScoreMarker.Font = new Font(ff, 20, FontStyle.Regular);
            lblGOScoreDisplay.Font = new Font(ff, 20, FontStyle.Regular);
            cbDisableMovement.Font = new Font(ff, 16, FontStyle.Regular);
        }
        // method showOptions makes the options menu visable and enabled
        private void ShowOptions()
        {
            pnlOptoinsMenu.Enabled = true;
            pnlOptoinsMenu.Visible = true;
        }
        // method HideOptions makes the options menu hidden and disabled
        private void HideOptions()
        {
            pnlOptoinsMenu.Visible = false;
            pnlOptoinsMenu.Enabled = false;
        }
        // ShowGameOver enables the game over panel and makes it visable
        // show game over then populates text on game over screen with
        // any options that were selected (if any) otherwise shows Default
        // show game over also sets balls_hit back to 0
        // doubleBufferedPanel1 is the blue bar at the bottom to help make it look better
        // with from resizing
        private void ShowGameOver()
        {
            pnlGameOver.Enabled = true;
            pnlGameOver.Visible = true;
            if (cbBallColor.SelectedIndex != -1)
            {
                lblCurrentBallColor.Text = cbBallColor.Text;
            }
            else { lblCurrentBallColor.Text = "Default"; }
            if (cbBallSize.SelectedIndex != -1)
            {
                lblCurrentBallSize.Text = cbBallSize.Text;
            }
            else { lblCurrentBallSize.Text = "Default"; }
            if (cbSpeed.SelectedIndex != -1)
            {
                lblCurrentSpeed.Text = cbSpeed.Text;
            }
            else { lblCurrentSpeed.Text = "Default"; }
            if (cbCursorType.SelectedIndex != -1) {

               lblCurrentCursor.Text = cbCursorType.Text;
            }
            else { lblCurrentCursor.Text = "Default"; }
            if (cbDisableMovement.Checked == true) {

                lblCurrentMovement.Text = cbDisableMovement.Text;
            }
            else { lblCurrentMovement.Text = "Default"; }
            if (cbSpawnSpeed.SelectedIndex != -1) {
                lblCurrentSpawnSpeed.Text = cbSpawnSpeed.Text;
            }
            else { lblCurrentSpawnSpeed.Text = "Default"; }
            lblGOScoreDisplay.Text = num_Balls_Hit.ToString();
            num_Balls_Hit = 0;
            lblScoreHit.Text = num_Balls_Hit.ToString();
            pnlHUD.Visible = false;
            doubleBufferedPanel1.Visible = false;
        }
        // method HideGameOver makes the gameOver panel disabled and hidden
        // also makes HUD panel visable as well as doubleBufferedPanel1 blue bar
        private void HideGameOver()
        {
            pnlGameOver.Enabled = false;
            pnlGameOver.Visible = false;
            pnlHUD.Visible = true;
            doubleBufferedPanel1.Visible = true;
        }
        // method to make the target references 
        private void MakeBall(int Speed) {
            //size of target variable
            int width;

            //velocity of target variable
            int vx, vy;

            if (cbBallSize.SelectedIndex != -1)
            {
                if (cbDisableMovement.Checked == true)
                {
                    int x, y;
                    Rectangle target;
                    x = rand.Next(10, (formSize.Width - 100));
                    y = rand.Next(10, (formSize.Height - pnlHUD.Height) - 100);
                     
                    foreach (var rect in ballList)
                    {
                        width = BallSize[cbBallSize.SelectedIndex];

                        target = new Rectangle(x, y, width, width);
                        
                        if (rect.Contains(target)) {
                            x = rand.Next(10, (formSize.Width - 100));
                            y = rand.Next(10, (formSize.Height - pnlHUD.Height) - 100);
                        }

                        foreach (var rectt in ballList)
                        {
                             target = new Rectangle(x, y, width, width);

                            if (rectt.Contains(target))
                            {
                                x = rand.Next(10, (formSize.Width - 100));
                                y = rand.Next(10, (formSize.Height - pnlHUD.Height) - 100);
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
                        rand.Next(10, (formSize.Width - 100)),
                        rand.Next(10, (formSize.Height - pnlHUD.Height) - 100),
                        width, width));
                }
                
            }
            else
            {
                //default size
                width = 18;
                ballList.Add(new Rectangle(
                    rand.Next(10, (formSize.Width - 100)),
                    rand.Next(10, (formSize.Height - pnlHUD.Height) - 100),
                    width, width));
                // add growing flag 
                ballIsGrowing.Add(true);
            }

            //set speed of target
            if (Speed == -1) {
                //default
                vx = rand.Next(0, 5);
                vy = rand.Next(0, 5);
            }
            else
            {
                //if speed is picked
                int ActualSpeed;
                ActualSpeed = Speed + 1;
                vx = rand.Next(0, ActualSpeed);
                vy = rand.Next(0, ActualSpeed);
            }

            //randomize velocity direction
            if (rand.Next(0, 2) == 0) vx = -vx;
            if (rand.Next(0, 2) == 0) vy = -vy;

            ballVelocity.Add(new Point(vx, vy));
        }

        // btnGameOver Reset click event
        private void btnGOReset_Click(object sender, EventArgs e)
        {
            ResetGame();
            this.Refresh();
        }

        // method to move targets/balls
        private void MoveBall()
        {
            for (int ball_num = 0; ball_num < ballList.Count; ball_num++)
            {

                // Move the ball.
                int new_x = ballList[ball_num].X + ballVelocity[ball_num].X;
                int new_y = ballList[ball_num].Y + ballVelocity[ball_num].Y;

                if (new_x <= 3)
                {
                    ballVelocity[ball_num] = new Point(-ballVelocity[ball_num].X, ballVelocity[ball_num].Y);
                }
                else if (new_x + ballList[ball_num].Width >= formSize.Width - 2)
                {
                    ballVelocity[ball_num] = new Point(-ballVelocity[ball_num].X, ballVelocity[ball_num].Y);
                    new_x = new_x + ballVelocity[ball_num].X;
                }
                if (new_y <= 3)
                {
                    ballVelocity[ball_num] = new Point(ballVelocity[ball_num].X, -ballVelocity[ball_num].Y);
                }
                else if (new_y + ballList[ball_num].Height >= formSize.Height - pnlHUD.Size.Height - 2)
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

        //method to remove lives if needed
        private void RemoveLife()
        {
            if (gameLives > 0)
            {
                string box = "pbLife" + gameLives;
                pnlHUD.Controls[box].Visible = false;
                gameLives -= 1;
            }
        }

        // method to restock lives at the end of the game
        private void RestockLives()
        {
            gameLives = 3;
            for (int i = 3; i > 0; i--)
            {
                string box = "pbLife" + i;
                pnlHUD.Controls[box].Visible = true;
            }
        }

        // method to resize targets to give feeling of shrinking and growing
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
                        endplayer.Play();
                    }

                }
            }
            else
            {

            }
        }

        // targetDrawer paint event method walks through ballList and draws each target at their specified location
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

        // method to set form to double buffer
        // used to stop flickering when moving graphics
        private void SetFormToDoubleBuffer()
        {
            // Use double buffering to reduce flicker.
            this.SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();
        }
    }

}

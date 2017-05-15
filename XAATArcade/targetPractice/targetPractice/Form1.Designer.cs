namespace targetPractice
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tBallSizeChanger = new System.Windows.Forms.Timer(this.components);
            this.tBallGenerator = new System.Windows.Forms.Timer(this.components);
            this.tBallMovement = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlGameOver = new targetPractice.Form1.DoubleBufferedPanel();
            this.btnGOReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblGOScoreMarker = new System.Windows.Forms.Label();
            this.lblGOScoreDisplay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentSpawnSpeed = new System.Windows.Forms.Label();
            this.lblCurrentMovement = new System.Windows.Forms.Label();
            this.lblCurrentCursor = new System.Windows.Forms.Label();
            this.lblCurrentSpeed = new System.Windows.Forms.Label();
            this.lblCurrentBallSize = new System.Windows.Forms.Label();
            this.lblCurrentBallColor = new System.Windows.Forms.Label();
            this.pnlOptoinsMenu = new targetPractice.Form1.DoubleBufferedPanel();
            this.cbDisableMovement = new System.Windows.Forms.CheckBox();
            this.cbSpawnSpeed = new System.Windows.Forms.ComboBox();
            this.lblBallSpawnSpeed = new System.Windows.Forms.Label();
            this.btnOptionsExit = new System.Windows.Forms.Button();
            this.cbCursorType = new System.Windows.Forms.ComboBox();
            this.lblBallMovement = new System.Windows.Forms.Label();
            this.cbSpeed = new System.Windows.Forms.ComboBox();
            this.cbBallColor = new System.Windows.Forms.ComboBox();
            this.cbBallSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCursorType = new System.Windows.Forms.Label();
            this.lblBallSpeed = new System.Windows.Forms.Label();
            this.lblBallSize = new System.Windows.Forms.Label();
            this.lblBallColor = new System.Windows.Forms.Label();
            this.pnlHUD = new targetPractice.Form1.DoubleBufferedPanel();
            this.pbLife3 = new System.Windows.Forms.PictureBox();
            this.pbLife2 = new System.Windows.Forms.PictureBox();
            this.btnOptionsMenu = new System.Windows.Forms.Button();
            this.lblScoreHit = new System.Windows.Forms.Label();
            this.pbLife1 = new System.Windows.Forms.PictureBox();
            this.doubleBufferedPanel1 = new targetPractice.Form1.DoubleBufferedPanel();
            this.pnlGameOver.SuspendLayout();
            this.pnlOptoinsMenu.SuspendLayout();
            this.pnlHUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLife3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLife2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLife1)).BeginInit();
            this.SuspendLayout();
            // 
            // tBallSizeChanger
            // 
            this.tBallSizeChanger.Interval = 30;
            this.tBallSizeChanger.Tick += new System.EventHandler(this.tGameTime_Tick);
            // 
            // tBallGenerator
            // 
            this.tBallGenerator.Interval = 750;
            this.tBallGenerator.Tick += new System.EventHandler(this.tBallGenerator_Tick);
            // 
            // tBallMovement
            // 
            this.tBallMovement.Interval = 1;
            this.tBallMovement.Tick += new System.EventHandler(this.tBallMovement_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.BackColor = System.Drawing.Color.Silver;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderSize = 2;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(211, 192);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(258, 189);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlGameOver
            // 
            this.pnlGameOver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGameOver.BackColor = System.Drawing.Color.Transparent;
            this.pnlGameOver.BackgroundImage = global::targetPractice.Properties.Resources.gameoverscreen;
            this.pnlGameOver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlGameOver.Controls.Add(this.btnGOReset);
            this.pnlGameOver.Controls.Add(this.label1);
            this.pnlGameOver.Controls.Add(this.label2);
            this.pnlGameOver.Controls.Add(this.label4);
            this.pnlGameOver.Controls.Add(this.label5);
            this.pnlGameOver.Controls.Add(this.label7);
            this.pnlGameOver.Controls.Add(this.label8);
            this.pnlGameOver.Controls.Add(this.lblGOScoreMarker);
            this.pnlGameOver.Controls.Add(this.lblGOScoreDisplay);
            this.pnlGameOver.Controls.Add(this.label3);
            this.pnlGameOver.Controls.Add(this.lblCurrentSpawnSpeed);
            this.pnlGameOver.Controls.Add(this.lblCurrentMovement);
            this.pnlGameOver.Controls.Add(this.lblCurrentCursor);
            this.pnlGameOver.Controls.Add(this.lblCurrentSpeed);
            this.pnlGameOver.Controls.Add(this.lblCurrentBallSize);
            this.pnlGameOver.Controls.Add(this.lblCurrentBallColor);
            this.pnlGameOver.Enabled = false;
            this.pnlGameOver.Location = new System.Drawing.Point(99, 92);
            this.pnlGameOver.Name = "pnlGameOver";
            this.pnlGameOver.Size = new System.Drawing.Size(484, 293);
            this.pnlGameOver.TabIndex = 3;
            this.pnlGameOver.Visible = false;
            // 
            // btnGOReset
            // 
            this.btnGOReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGOReset.FlatAppearance.BorderSize = 0;
            this.btnGOReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGOReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnGOReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGOReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGOReset.ForeColor = System.Drawing.Color.White;
            this.btnGOReset.Location = new System.Drawing.Point(336, 219);
            this.btnGOReset.Name = "btnGOReset";
            this.btnGOReset.Size = new System.Drawing.Size(71, 40);
            this.btnGOReset.TabIndex = 7;
            this.btnGOReset.Text = "Reset";
            this.btnGOReset.UseVisualStyleBackColor = true;
            this.btnGOReset.Click += new System.EventHandler(this.btnGOReset_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(-99, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Spawn Speed:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(-179, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ball Movement:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(-84, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Cursor Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(-28, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Speed:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(-50, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ball Size:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(-59, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ball Color:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGOScoreMarker
            // 
            this.lblGOScoreMarker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGOScoreMarker.AutoSize = true;
            this.lblGOScoreMarker.ForeColor = System.Drawing.Color.White;
            this.lblGOScoreMarker.Location = new System.Drawing.Point(298, 119);
            this.lblGOScoreMarker.Name = "lblGOScoreMarker";
            this.lblGOScoreMarker.Size = new System.Drawing.Size(35, 13);
            this.lblGOScoreMarker.TabIndex = 9;
            this.lblGOScoreMarker.Text = "Score";
            // 
            // lblGOScoreDisplay
            // 
            this.lblGOScoreDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGOScoreDisplay.AutoSize = true;
            this.lblGOScoreDisplay.ForeColor = System.Drawing.Color.White;
            this.lblGOScoreDisplay.Location = new System.Drawing.Point(351, 167);
            this.lblGOScoreDisplay.Name = "lblGOScoreDisplay";
            this.lblGOScoreDisplay.Size = new System.Drawing.Size(35, 13);
            this.lblGOScoreDisplay.TabIndex = 8;
            this.lblGOScoreDisplay.Text = "Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(234, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 6;
            // 
            // lblCurrentSpawnSpeed
            // 
            this.lblCurrentSpawnSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentSpawnSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentSpawnSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSpawnSpeed.ForeColor = System.Drawing.Color.White;
            this.lblCurrentSpawnSpeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentSpawnSpeed.Location = new System.Drawing.Point(16, 246);
            this.lblCurrentSpawnSpeed.Name = "lblCurrentSpawnSpeed";
            this.lblCurrentSpawnSpeed.Size = new System.Drawing.Size(240, 25);
            this.lblCurrentSpawnSpeed.TabIndex = 30;
            this.lblCurrentSpawnSpeed.Text = "Spawn Speed:";
            this.lblCurrentSpawnSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentMovement
            // 
            this.lblCurrentMovement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentMovement.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentMovement.ForeColor = System.Drawing.Color.White;
            this.lblCurrentMovement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentMovement.Location = new System.Drawing.Point(70, 216);
            this.lblCurrentMovement.Name = "lblCurrentMovement";
            this.lblCurrentMovement.Size = new System.Drawing.Size(186, 25);
            this.lblCurrentMovement.TabIndex = 29;
            this.lblCurrentMovement.Text = "Ball Movement:";
            this.lblCurrentMovement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentCursor
            // 
            this.lblCurrentCursor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentCursor.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentCursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCursor.ForeColor = System.Drawing.Color.White;
            this.lblCurrentCursor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentCursor.Location = new System.Drawing.Point(31, 185);
            this.lblCurrentCursor.Name = "lblCurrentCursor";
            this.lblCurrentCursor.Size = new System.Drawing.Size(225, 25);
            this.lblCurrentCursor.TabIndex = 28;
            this.lblCurrentCursor.Text = "Cursor Type:";
            this.lblCurrentCursor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentSpeed
            // 
            this.lblCurrentSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSpeed.ForeColor = System.Drawing.Color.White;
            this.lblCurrentSpeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentSpeed.Location = new System.Drawing.Point(87, 154);
            this.lblCurrentSpeed.Name = "lblCurrentSpeed";
            this.lblCurrentSpeed.Size = new System.Drawing.Size(169, 25);
            this.lblCurrentSpeed.TabIndex = 27;
            this.lblCurrentSpeed.Text = "Speed:";
            this.lblCurrentSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentBallSize
            // 
            this.lblCurrentBallSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentBallSize.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentBallSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBallSize.ForeColor = System.Drawing.Color.White;
            this.lblCurrentBallSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentBallSize.Location = new System.Drawing.Point(65, 92);
            this.lblCurrentBallSize.Name = "lblCurrentBallSize";
            this.lblCurrentBallSize.Size = new System.Drawing.Size(191, 25);
            this.lblCurrentBallSize.TabIndex = 26;
            this.lblCurrentBallSize.Text = "Ball Size:";
            this.lblCurrentBallSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentBallColor
            // 
            this.lblCurrentBallColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentBallColor.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentBallColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBallColor.ForeColor = System.Drawing.Color.White;
            this.lblCurrentBallColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentBallColor.Location = new System.Drawing.Point(56, 123);
            this.lblCurrentBallColor.Name = "lblCurrentBallColor";
            this.lblCurrentBallColor.Size = new System.Drawing.Size(200, 25);
            this.lblCurrentBallColor.TabIndex = 25;
            this.lblCurrentBallColor.Text = "Ball Color:";
            this.lblCurrentBallColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlOptoinsMenu
            // 
            this.pnlOptoinsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptoinsMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlOptoinsMenu.BackgroundImage = global::targetPractice.Properties.Resources.optionsscreen;
            this.pnlOptoinsMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlOptoinsMenu.Controls.Add(this.cbDisableMovement);
            this.pnlOptoinsMenu.Controls.Add(this.cbSpawnSpeed);
            this.pnlOptoinsMenu.Controls.Add(this.lblBallSpawnSpeed);
            this.pnlOptoinsMenu.Controls.Add(this.btnOptionsExit);
            this.pnlOptoinsMenu.Controls.Add(this.cbCursorType);
            this.pnlOptoinsMenu.Controls.Add(this.lblBallMovement);
            this.pnlOptoinsMenu.Controls.Add(this.cbSpeed);
            this.pnlOptoinsMenu.Controls.Add(this.cbBallColor);
            this.pnlOptoinsMenu.Controls.Add(this.cbBallSize);
            this.pnlOptoinsMenu.Controls.Add(this.label6);
            this.pnlOptoinsMenu.Controls.Add(this.lblCursorType);
            this.pnlOptoinsMenu.Controls.Add(this.lblBallSpeed);
            this.pnlOptoinsMenu.Controls.Add(this.lblBallSize);
            this.pnlOptoinsMenu.Controls.Add(this.lblBallColor);
            this.pnlOptoinsMenu.Enabled = false;
            this.pnlOptoinsMenu.Location = new System.Drawing.Point(99, 91);
            this.pnlOptoinsMenu.Name = "pnlOptoinsMenu";
            this.pnlOptoinsMenu.Size = new System.Drawing.Size(484, 293);
            this.pnlOptoinsMenu.TabIndex = 1;
            this.pnlOptoinsMenu.Visible = false;
            // 
            // cbDisableMovement
            // 
            this.cbDisableMovement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbDisableMovement.AutoSize = true;
            this.cbDisableMovement.ForeColor = System.Drawing.Color.White;
            this.cbDisableMovement.Location = new System.Drawing.Point(317, 219);
            this.cbDisableMovement.Name = "cbDisableMovement";
            this.cbDisableMovement.Size = new System.Drawing.Size(61, 17);
            this.cbDisableMovement.TabIndex = 19;
            this.cbDisableMovement.Text = "Disable";
            this.cbDisableMovement.UseVisualStyleBackColor = true;
            this.cbDisableMovement.CheckedChanged += new System.EventHandler(this.DisableMovement_CheckedChanged);
            // 
            // cbSpawnSpeed
            // 
            this.cbSpawnSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSpawnSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpawnSpeed.FormattingEnabled = true;
            this.cbSpawnSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbSpawnSpeed.Location = new System.Drawing.Point(326, 252);
            this.cbSpawnSpeed.Name = "cbSpawnSpeed";
            this.cbSpawnSpeed.Size = new System.Drawing.Size(131, 21);
            this.cbSpawnSpeed.TabIndex = 17;
            this.cbSpawnSpeed.SelectedIndexChanged += new System.EventHandler(this.cbSpawnSpeed_SelectedIndexChanged);
            // 
            // lblBallSpawnSpeed
            // 
            this.lblBallSpawnSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallSpawnSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblBallSpawnSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallSpawnSpeed.ForeColor = System.Drawing.Color.White;
            this.lblBallSpawnSpeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBallSpawnSpeed.Location = new System.Drawing.Point(53, 247);
            this.lblBallSpawnSpeed.Name = "lblBallSpawnSpeed";
            this.lblBallSpawnSpeed.Size = new System.Drawing.Size(270, 25);
            this.lblBallSpawnSpeed.TabIndex = 18;
            this.lblBallSpawnSpeed.Text = "Spawn Speed:";
            this.lblBallSpawnSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOptionsExit
            // 
            this.btnOptionsExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOptionsExit.BackColor = System.Drawing.Color.DarkRed;
            this.btnOptionsExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOptionsExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnOptionsExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOptionsExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptionsExit.Location = new System.Drawing.Point(15, 73);
            this.btnOptionsExit.Name = "btnOptionsExit";
            this.btnOptionsExit.Size = new System.Drawing.Size(25, 23);
            this.btnOptionsExit.TabIndex = 15;
            this.btnOptionsExit.Text = "X";
            this.btnOptionsExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOptionsExit.UseVisualStyleBackColor = false;
            this.btnOptionsExit.Click += new System.EventHandler(this.btnOptionsExit_Click);
            // 
            // cbCursorType
            // 
            this.cbCursorType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCursorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCursorType.FormattingEnabled = true;
            this.cbCursorType.Items.AddRange(new object[] {
            "Cross",
            "Default"});
            this.cbCursorType.Location = new System.Drawing.Point(326, 190);
            this.cbCursorType.Name = "cbCursorType";
            this.cbCursorType.Size = new System.Drawing.Size(131, 21);
            this.cbCursorType.TabIndex = 12;
            this.cbCursorType.SelectedIndexChanged += new System.EventHandler(this.cbCursorType_SelectedIndexChanged);
            // 
            // lblBallMovement
            // 
            this.lblBallMovement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallMovement.BackColor = System.Drawing.Color.Transparent;
            this.lblBallMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallMovement.ForeColor = System.Drawing.Color.White;
            this.lblBallMovement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBallMovement.Location = new System.Drawing.Point(-27, 216);
            this.lblBallMovement.Name = "lblBallMovement";
            this.lblBallMovement.Size = new System.Drawing.Size(348, 25);
            this.lblBallMovement.TabIndex = 11;
            this.lblBallMovement.Text = "Ball Movement:";
            this.lblBallMovement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSpeed
            // 
            this.cbSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeed.FormattingEnabled = true;
            this.cbSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbSpeed.Location = new System.Drawing.Point(326, 159);
            this.cbSpeed.Name = "cbSpeed";
            this.cbSpeed.Size = new System.Drawing.Size(131, 21);
            this.cbSpeed.TabIndex = 9;
            this.cbSpeed.SelectedIndexChanged += new System.EventHandler(this.cbSpeed_SelectedIndexChanged);
            // 
            // cbBallColor
            // 
            this.cbBallColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbBallColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBallColor.FormattingEnabled = true;
            this.cbBallColor.Items.AddRange(new object[] {
            "Blue",
            "Red",
            "Green",
            "Yellow",
            "Orange",
            "Purple",
            "Pokeball"});
            this.cbBallColor.Location = new System.Drawing.Point(326, 128);
            this.cbBallColor.Name = "cbBallColor";
            this.cbBallColor.Size = new System.Drawing.Size(131, 21);
            this.cbBallColor.TabIndex = 8;
            this.cbBallColor.SelectedIndexChanged += new System.EventHandler(this.cbBallColor_SelectedIndexChanged);
            // 
            // cbBallSize
            // 
            this.cbBallSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbBallSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBallSize.FormattingEnabled = true;
            this.cbBallSize.Items.AddRange(new object[] {
            "80",
            "70",
            "60",
            "50",
            "40"});
            this.cbBallSize.Location = new System.Drawing.Point(326, 97);
            this.cbBallSize.Name = "cbBallSize";
            this.cbBallSize.Size = new System.Drawing.Size(131, 21);
            this.cbBallSize.TabIndex = 7;
            this.cbBallSize.SelectedIndexChanged += new System.EventHandler(this.cbBallSize_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(234, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 6;
            // 
            // lblCursorType
            // 
            this.lblCursorType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCursorType.BackColor = System.Drawing.Color.Transparent;
            this.lblCursorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursorType.ForeColor = System.Drawing.Color.White;
            this.lblCursorType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCursorType.Location = new System.Drawing.Point(68, 185);
            this.lblCursorType.Name = "lblCursorType";
            this.lblCursorType.Size = new System.Drawing.Size(255, 25);
            this.lblCursorType.TabIndex = 5;
            this.lblCursorType.Text = "Cursor Type:";
            this.lblCursorType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBallSpeed
            // 
            this.lblBallSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblBallSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallSpeed.ForeColor = System.Drawing.Color.White;
            this.lblBallSpeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBallSpeed.Location = new System.Drawing.Point(124, 154);
            this.lblBallSpeed.Name = "lblBallSpeed";
            this.lblBallSpeed.Size = new System.Drawing.Size(199, 25);
            this.lblBallSpeed.TabIndex = 2;
            this.lblBallSpeed.Text = "Speed:";
            this.lblBallSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBallSize
            // 
            this.lblBallSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallSize.BackColor = System.Drawing.Color.Transparent;
            this.lblBallSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallSize.ForeColor = System.Drawing.Color.White;
            this.lblBallSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBallSize.Location = new System.Drawing.Point(102, 92);
            this.lblBallSize.Name = "lblBallSize";
            this.lblBallSize.Size = new System.Drawing.Size(221, 25);
            this.lblBallSize.TabIndex = 1;
            this.lblBallSize.Text = "Ball Size:";
            this.lblBallSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBallColor
            // 
            this.lblBallColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallColor.BackColor = System.Drawing.Color.Transparent;
            this.lblBallColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallColor.ForeColor = System.Drawing.Color.White;
            this.lblBallColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBallColor.Location = new System.Drawing.Point(93, 123);
            this.lblBallColor.Name = "lblBallColor";
            this.lblBallColor.Size = new System.Drawing.Size(230, 25);
            this.lblBallColor.TabIndex = 0;
            this.lblBallColor.Text = "Ball Color:";
            this.lblBallColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlHUD
            // 
            this.pnlHUD.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlHUD.AutoSize = true;
            this.pnlHUD.BackColor = System.Drawing.Color.Black;
            this.pnlHUD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHUD.BackgroundImage")));
            this.pnlHUD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHUD.Controls.Add(this.pbLife3);
            this.pnlHUD.Controls.Add(this.pbLife2);
            this.pnlHUD.Controls.Add(this.btnOptionsMenu);
            this.pnlHUD.Controls.Add(this.lblScoreHit);
            this.pnlHUD.Controls.Add(this.pbLife1);
            this.pnlHUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlHUD.Location = new System.Drawing.Point(2, 518);
            this.pnlHUD.Name = "pnlHUD";
            this.pnlHUD.Size = new System.Drawing.Size(680, 183);
            this.pnlHUD.TabIndex = 0;
            // 
            // pbLife3
            // 
            this.pbLife3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbLife3.BackColor = System.Drawing.Color.Transparent;
            this.pbLife3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLife3.Image = global::targetPractice.Properties.Resources.life;
            this.pbLife3.InitialImage = null;
            this.pbLife3.Location = new System.Drawing.Point(213, 98);
            this.pbLife3.Name = "pbLife3";
            this.pbLife3.Size = new System.Drawing.Size(73, 65);
            this.pbLife3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLife3.TabIndex = 10;
            this.pbLife3.TabStop = false;
            // 
            // pbLife2
            // 
            this.pbLife2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbLife2.BackColor = System.Drawing.Color.Transparent;
            this.pbLife2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLife2.Image = global::targetPractice.Properties.Resources.life;
            this.pbLife2.InitialImage = null;
            this.pbLife2.Location = new System.Drawing.Point(123, 98);
            this.pbLife2.Name = "pbLife2";
            this.pbLife2.Size = new System.Drawing.Size(73, 65);
            this.pbLife2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLife2.TabIndex = 9;
            this.pbLife2.TabStop = false;
            // 
            // btnOptionsMenu
            // 
            this.btnOptionsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptionsMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnOptionsMenu.BackgroundImage = global::targetPractice.Properties.Resources.cog;
            this.btnOptionsMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOptionsMenu.FlatAppearance.BorderSize = 0;
            this.btnOptionsMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOptionsMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOptionsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptionsMenu.ForeColor = System.Drawing.Color.Transparent;
            this.btnOptionsMenu.Location = new System.Drawing.Point(636, 150);
            this.btnOptionsMenu.Name = "btnOptionsMenu";
            this.btnOptionsMenu.Size = new System.Drawing.Size(30, 30);
            this.btnOptionsMenu.TabIndex = 8;
            this.btnOptionsMenu.UseVisualStyleBackColor = false;
            this.btnOptionsMenu.Click += new System.EventHandler(this.btnOptionsMenu_Click);
            // 
            // lblScoreHit
            // 
            this.lblScoreHit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblScoreHit.AutoSize = true;
            this.lblScoreHit.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreHit.ForeColor = System.Drawing.Color.White;
            this.lblScoreHit.Location = new System.Drawing.Point(463, 85);
            this.lblScoreHit.Name = "lblScoreHit";
            this.lblScoreHit.Size = new System.Drawing.Size(51, 55);
            this.lblScoreHit.TabIndex = 7;
            this.lblScoreHit.Text = "0\r\n";
            // 
            // pbLife1
            // 
            this.pbLife1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbLife1.BackColor = System.Drawing.Color.Transparent;
            this.pbLife1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLife1.Image = global::targetPractice.Properties.Resources.life;
            this.pbLife1.InitialImage = null;
            this.pbLife1.Location = new System.Drawing.Point(36, 98);
            this.pbLife1.Name = "pbLife1";
            this.pbLife1.Size = new System.Drawing.Size(73, 65);
            this.pbLife1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLife1.TabIndex = 0;
            this.pbLife1.TabStop = false;
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferedPanel1.AutoSize = true;
            this.doubleBufferedPanel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.doubleBufferedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doubleBufferedPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(2, 517);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(680, 183);
            this.doubleBufferedPanel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(684, 702);
            this.Controls.Add(this.pnlHUD);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.doubleBufferedPanel1);
            this.Controls.Add(this.pnlOptoinsMenu);
            this.Controls.Add(this.pnlGameOver);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Target Practice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.pnlGameOver.ResumeLayout(false);
            this.pnlGameOver.PerformLayout();
            this.pnlOptoinsMenu.ResumeLayout(false);
            this.pnlOptoinsMenu.PerformLayout();
            this.pnlHUD.ResumeLayout(false);
            this.pnlHUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLife3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLife2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLife1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer tBallSizeChanger;
        public System.Windows.Forms.Timer tBallGenerator;
        public System.Windows.Forms.Timer tBallMovement;
        private System.Windows.Forms.PictureBox pbLife1;
        private DoubleBufferedPanel pnlHUD;
        private System.Windows.Forms.Label lblScoreHit;
        private System.Windows.Forms.Button btnOptionsMenu;
        private System.Windows.Forms.ComboBox cbCursorType;
        private System.Windows.Forms.Label lblBallMovement;
        private System.Windows.Forms.ComboBox cbSpeed;
        private System.Windows.Forms.ComboBox cbBallColor;
        private System.Windows.Forms.ComboBox cbBallSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCursorType;
        private System.Windows.Forms.Label lblBallSpeed;
        private System.Windows.Forms.Label lblBallSize;
        private System.Windows.Forms.Label lblBallColor;
        private System.Windows.Forms.Button btnOptionsExit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbSpawnSpeed;
        private System.Windows.Forms.PictureBox pbLife3;
        private System.Windows.Forms.PictureBox pbLife2;
        private System.Windows.Forms.Label lblBallSpawnSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGOReset;
        private DoubleBufferedPanel pnlOptoinsMenu;
        private DoubleBufferedPanel pnlGameOver;
        private System.Windows.Forms.Label lblGOScoreMarker;
        private System.Windows.Forms.Label lblGOScoreDisplay;
        private System.Windows.Forms.CheckBox cbDisableMovement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurrentSpawnSpeed;
        private System.Windows.Forms.Label lblCurrentMovement;
        private System.Windows.Forms.Label lblCurrentCursor;
        private System.Windows.Forms.Label lblCurrentSpeed;
        private System.Windows.Forms.Label lblCurrentBallSize;
        private System.Windows.Forms.Label lblCurrentBallColor;
        private DoubleBufferedPanel doubleBufferedPanel1;
    }
}


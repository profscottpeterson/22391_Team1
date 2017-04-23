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
            this.tBallSizeChanger = new System.Windows.Forms.Timer(this.components);
            this.tBallGenerator = new System.Windows.Forms.Timer(this.components);
            this.tBallMovement = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Button();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.lblBallMovement = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.cbBallColor = new System.Windows.Forms.ComboBox();
            this.cbBallSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCursorType = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblBallSpeed = new System.Windows.Forms.Label();
            this.lblBallSize = new System.Windows.Forms.Label();
            this.lblBallColor = new System.Windows.Forms.Label();
            this.panel1 = new targetPractice.Form1.DoubleBufferedPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblScoreHit = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblBallSpawnSpeed = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tBallSizeChanger
            // 
            this.tBallSizeChanger.Enabled = true;
            this.tBallSizeChanger.Interval = 30;
            this.tBallSizeChanger.Tick += new System.EventHandler(this.tGameTime_Tick);
            // 
            // tBallGenerator
            // 
            this.tBallGenerator.Enabled = true;
            this.tBallGenerator.Interval = 750;
            this.tBallGenerator.Tick += new System.EventHandler(this.tBallGenerator_Tick);
            // 
            // tBallMovement
            // 
            this.tBallMovement.Enabled = true;
            this.tBallMovement.Interval = 10;
            this.tBallMovement.Tick += new System.EventHandler(this.tBallMovement_Tick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.lblBallSpawnSpeed);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox7);
            this.panel2.Controls.Add(this.comboBox6);
            this.panel2.Controls.Add(this.comboBox5);
            this.panel2.Controls.Add(this.lblBallMovement);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.cbBallColor);
            this.panel2.Controls.Add(this.cbBallSize);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblCursorType);
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.lblBallSpeed);
            this.panel2.Controls.Add(this.lblBallSize);
            this.panel2.Controls.Add(this.lblBallColor);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(99, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 293);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.label1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.UseVisualStyleBackColor = false;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // comboBox7
            // 
            this.comboBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "Unlimited",
            "00:30",
            "01:00",
            "01:30",
            "02:00",
            "03:00",
            "04:00",
            "05:00"});
            this.comboBox7.Location = new System.Drawing.Point(345, 227);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(131, 21);
            this.comboBox7.TabIndex = 14;
            this.comboBox7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
            // 
            // comboBox6
            // 
            this.comboBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.comboBox6.Location = new System.Drawing.Point(345, 187);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(131, 21);
            this.comboBox6.TabIndex = 13;
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // comboBox5
            // 
            this.comboBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Cross",
            "Default"});
            this.comboBox5.Location = new System.Drawing.Point(345, 144);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(131, 21);
            this.comboBox5.TabIndex = 12;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // lblBallMovement
            // 
            this.lblBallMovement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallMovement.Location = new System.Drawing.Point(-14, 183);
            this.lblBallMovement.Name = "lblBallMovement";
            this.lblBallMovement.Size = new System.Drawing.Size(334, 25);
            this.lblBallMovement.TabIndex = 11;
            this.lblBallMovement.Text = "Ball Movement:";
            this.lblBallMovement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox3.Location = new System.Drawing.Point(345, 106);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(131, 21);
            this.comboBox3.TabIndex = 9;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
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
            "Purple"});
            this.cbBallColor.Location = new System.Drawing.Point(345, 65);
            this.cbBallColor.Name = "cbBallColor";
            this.cbBallColor.Size = new System.Drawing.Size(131, 21);
            this.cbBallColor.TabIndex = 8;
            this.cbBallColor.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
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
            this.cbBallSize.Location = new System.Drawing.Point(345, 23);
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
            this.lblCursorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursorType.Location = new System.Drawing.Point(1, 140);
            this.lblCursorType.Name = "lblCursorType";
            this.lblCursorType.Size = new System.Drawing.Size(304, 25);
            this.lblCursorType.TabIndex = 5;
            this.lblCursorType.Text = "Cursor Type:";
            this.lblCursorType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(34, 222);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(239, 25);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Time:";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBallSpeed
            // 
            this.lblBallSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallSpeed.Location = new System.Drawing.Point(26, 102);
            this.lblBallSpeed.Name = "lblBallSpeed";
            this.lblBallSpeed.Size = new System.Drawing.Size(254, 25);
            this.lblBallSpeed.TabIndex = 2;
            this.lblBallSpeed.Text = "Speed:";
            this.lblBallSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBallSize
            // 
            this.lblBallSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallSize.Location = new System.Drawing.Point(18, 19);
            this.lblBallSize.Name = "lblBallSize";
            this.lblBallSize.Size = new System.Drawing.Size(270, 25);
            this.lblBallSize.TabIndex = 1;
            this.lblBallSize.Text = "Ball Size:";
            this.lblBallSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBallColor
            // 
            this.lblBallColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallColor.Location = new System.Drawing.Point(11, 61);
            this.lblBallColor.Name = "lblBallColor";
            this.lblBallColor.Size = new System.Drawing.Size(285, 25);
            this.lblBallColor.TabIndex = 0;
            this.lblBallColor.Text = "Ball Color:";
            this.lblBallColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImage = global::targetPractice.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblScoreHit);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lblTimer);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(2, 677);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 183);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::targetPractice.Properties.Resources.cog;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(640, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblScoreHit
            // 
            this.lblScoreHit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblScoreHit.AutoSize = true;
            this.lblScoreHit.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreHit.ForeColor = System.Drawing.Color.White;
            this.lblScoreHit.Location = new System.Drawing.Point(530, 100);
            this.lblScoreHit.Name = "lblScoreHit";
            this.lblScoreHit.Size = new System.Drawing.Size(51, 55);
            this.lblScoreHit.TabIndex = 7;
            this.lblScoreHit.Text = "0\r\n";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = global::targetPractice.Properties.Resources.life3;
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(131, 100);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::targetPractice.Properties.Resources.life3;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(72, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Location = new System.Drawing.Point(209, 69);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(132, 55);
            this.lblTimer.TabIndex = 4;
            this.lblTimer.Text = "0000";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::targetPractice.Properties.Resources.life3;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(13, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Silver;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderSize = 2;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(211, 192);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(258, 189);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblBallSpawnSpeed
            // 
            this.lblBallSpawnSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallSpawnSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallSpawnSpeed.Location = new System.Drawing.Point(34, 263);
            this.lblBallSpawnSpeed.Name = "lblBallSpawnSpeed";
            this.lblBallSpawnSpeed.Size = new System.Drawing.Size(239, 25);
            this.lblBallSpawnSpeed.TabIndex = 16;
            this.lblBallSpawnSpeed.Text = "Ball Spawn Speed:";
            this.lblBallSpawnSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(345, 263);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(684, 856);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer tBallSizeChanger;
        public System.Windows.Forms.Timer tBallGenerator;
        public System.Windows.Forms.Timer tBallMovement;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DoubleBufferedPanel panel1;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblScoreHit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label lblBallMovement;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox cbBallColor;
        private System.Windows.Forms.ComboBox cbBallSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCursorType;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblBallSpeed;
        private System.Windows.Forms.Label lblBallSize;
        private System.Windows.Forms.Label lblBallColor;
        private System.Windows.Forms.Button label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblBallSpawnSpeed;
    }
}


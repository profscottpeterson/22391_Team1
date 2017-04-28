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
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblBallSpawnSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Button();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.lblBallMovement = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.cbBallColor = new System.Windows.Forms.ComboBox();
            this.cbBallSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCursorType = new System.Windows.Forms.Label();
            this.lblBallSpeed = new System.Windows.Forms.Label();
            this.lblBallSize = new System.Windows.Forms.Label();
            this.lblBallColor = new System.Windows.Forms.Label();
            this.panel1 = new targetPractice.Form1.DoubleBufferedPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblScoreHit = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            // btnStart
            // 
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = global::targetPractice.Properties.Resources.settings;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.lblBallSpawnSpeed);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox6);
            this.panel2.Controls.Add(this.comboBox5);
            this.panel2.Controls.Add(this.lblBallMovement);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.cbBallColor);
            this.panel2.Controls.Add(this.cbBallSize);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblCursorType);
            this.panel2.Controls.Add(this.lblBallSpeed);
            this.panel2.Controls.Add(this.lblBallSize);
            this.panel2.Controls.Add(this.lblBallColor);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(99, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 293);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
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
            this.comboBox1.Location = new System.Drawing.Point(324, 232);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // lblBallSpawnSpeed
            // 
            this.lblBallSpawnSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallSpawnSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblBallSpawnSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallSpawnSpeed.ForeColor = System.Drawing.Color.White;
            this.lblBallSpawnSpeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBallSpawnSpeed.Location = new System.Drawing.Point(51, 227);
            this.lblBallSpawnSpeed.Name = "lblBallSpawnSpeed";
            this.lblBallSpawnSpeed.Size = new System.Drawing.Size(270, 25);
            this.lblBallSpawnSpeed.TabIndex = 18;
            this.lblBallSpawnSpeed.Text = "Spawn Speed:";
            this.lblBallSpawnSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.label1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.UseVisualStyleBackColor = false;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // comboBox6
            // 
            this.comboBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.comboBox6.Location = new System.Drawing.Point(324, 195);
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
            this.comboBox5.Location = new System.Drawing.Point(324, 158);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(131, 21);
            this.comboBox5.TabIndex = 12;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // lblBallMovement
            // 
            this.lblBallMovement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBallMovement.BackColor = System.Drawing.Color.Transparent;
            this.lblBallMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBallMovement.ForeColor = System.Drawing.Color.White;
            this.lblBallMovement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBallMovement.Location = new System.Drawing.Point(-27, 191);
            this.lblBallMovement.Name = "lblBallMovement";
            this.lblBallMovement.Size = new System.Drawing.Size(348, 25);
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
            this.comboBox3.Location = new System.Drawing.Point(324, 121);
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
            this.cbBallColor.Location = new System.Drawing.Point(324, 84);
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
            this.cbBallSize.Location = new System.Drawing.Point(324, 47);
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
            this.lblCursorType.Location = new System.Drawing.Point(66, 154);
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
            this.lblBallSpeed.Location = new System.Drawing.Point(122, 117);
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
            this.lblBallSize.Location = new System.Drawing.Point(100, 43);
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
            this.lblBallColor.Location = new System.Drawing.Point(91, 80);
            this.lblBallColor.Name = "lblBallColor";
            this.lblBallColor.Size = new System.Drawing.Size(230, 25);
            this.lblBallColor.TabIndex = 0;
            this.lblBallColor.Text = "Ball Color:";
            this.lblBallColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblScoreHit);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(2, 556);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 183);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(213, 90);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(73, 65);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(123, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
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
            this.lblScoreHit.Location = new System.Drawing.Point(465, 85);
            this.lblScoreHit.Name = "lblScoreHit";
            this.lblScoreHit.Size = new System.Drawing.Size(51, 55);
            this.lblScoreHit.TabIndex = 7;
            this.lblScoreHit.Text = "0\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(36, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(684, 741);
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
        private System.Windows.Forms.Label lblScoreHit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label lblBallMovement;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox cbBallColor;
        private System.Windows.Forms.ComboBox cbBallSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCursorType;
        private System.Windows.Forms.Label lblBallSpeed;
        private System.Windows.Forms.Label lblBallSize;
        private System.Windows.Forms.Label lblBallColor;
        private System.Windows.Forms.Button label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblBallSpawnSpeed;
    }
}


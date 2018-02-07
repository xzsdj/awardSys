namespace awardSys
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.gBox_1 = new System.Windows.Forms.GroupBox();
            this.radioButton_1 = new System.Windows.Forms.RadioButton();
            this.radioButton_2 = new System.Windows.Forms.RadioButton();
            this.radioButton_3 = new System.Windows.Forms.RadioButton();
            this.lab_Statue = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.lab_Title = new CCWin.SkinControl.SkinLabel();
            this.timer_01 = new System.Windows.Forms.Timer(this.components);
            this.btn_Exit = new System.Windows.Forms.Button();
            this.lab_name_1 = new System.Windows.Forms.Label();
            this.lab_name_2 = new System.Windows.Forms.Label();
            this.lab_name_3 = new System.Windows.Forms.Label();
            this.listBox_2 = new System.Windows.Forms.ListBox();
            this.listBox_1 = new System.Windows.Forms.ListBox();
            this.listBox_3 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gBox_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox_1
            // 
            this.gBox_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gBox_1.BackColor = System.Drawing.Color.Transparent;
            this.gBox_1.Controls.Add(this.radioButton_1);
            this.gBox_1.Controls.Add(this.radioButton_2);
            this.gBox_1.Controls.Add(this.radioButton_3);
            this.gBox_1.ForeColor = System.Drawing.Color.Yellow;
            this.gBox_1.Location = new System.Drawing.Point(12, 616);
            this.gBox_1.Name = "gBox_1";
            this.gBox_1.Size = new System.Drawing.Size(177, 165);
            this.gBox_1.TabIndex = 0;
            this.gBox_1.TabStop = false;
            this.gBox_1.Text = "奖项选择";
            this.gBox_1.Visible = false;
            // 
            // radioButton_1
            // 
            this.radioButton_1.AutoSize = true;
            this.radioButton_1.Location = new System.Drawing.Point(20, 114);
            this.radioButton_1.Name = "radioButton_1";
            this.radioButton_1.Size = new System.Drawing.Size(137, 16);
            this.radioButton_1.TabIndex = 2;
            this.radioButton_1.Tag = "1";
            this.radioButton_1.Text = "92人中抽取1个一等奖";
            this.radioButton_1.UseVisualStyleBackColor = true;
            this.radioButton_1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_2
            // 
            this.radioButton_2.AutoSize = true;
            this.radioButton_2.Location = new System.Drawing.Point(20, 74);
            this.radioButton_2.Name = "radioButton_2";
            this.radioButton_2.Size = new System.Drawing.Size(137, 16);
            this.radioButton_2.TabIndex = 1;
            this.radioButton_2.Tag = "2";
            this.radioButton_2.Text = "95人中抽取3个二等奖";
            this.radioButton_2.UseVisualStyleBackColor = true;
            this.radioButton_2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_3
            // 
            this.radioButton_3.AutoSize = true;
            this.radioButton_3.Checked = true;
            this.radioButton_3.Location = new System.Drawing.Point(20, 35);
            this.radioButton_3.Name = "radioButton_3";
            this.radioButton_3.Size = new System.Drawing.Size(143, 16);
            this.radioButton_3.TabIndex = 0;
            this.radioButton_3.TabStop = true;
            this.radioButton_3.Tag = "3";
            this.radioButton_3.Text = "100人中抽取5个三等奖";
            this.radioButton_3.UseVisualStyleBackColor = true;
            this.radioButton_3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // lab_Statue
            // 
            this.lab_Statue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_Statue.AutoSize = true;
            this.lab_Statue.BackColor = System.Drawing.Color.Transparent;
            this.lab_Statue.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Statue.ForeColor = System.Drawing.Color.Yellow;
            this.lab_Statue.Location = new System.Drawing.Point(661, 425);
            this.lab_Statue.Name = "lab_Statue";
            this.lab_Statue.Size = new System.Drawing.Size(731, 96);
            this.lab_Statue.TabIndex = 3;
            this.lab_Statue.Text = "三等奖：当前正在抽取第1轮奖项\r\n\r\n";
            this.lab_Statue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_Statue.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "background.jpg");
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImage = global::awardSys.Properties.Resources.btn_bg;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("楷体", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(792, 928);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(361, 102);
            this.btnStart.TabIndex = 0;
            this.btnStart.Tag = "1";
            this.btnStart.Text = "开始抽奖";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lab_Title
            // 
            this.lab_Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_Title.AutoSize = true;
            this.lab_Title.BackColor = System.Drawing.Color.Transparent;
            this.lab_Title.BorderColor = System.Drawing.Color.White;
            this.lab_Title.Font = new System.Drawing.Font("隶书", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Title.Location = new System.Drawing.Point(279, 36);
            this.lab_Title.Name = "lab_Title";
            this.lab_Title.Size = new System.Drawing.Size(1292, 53);
            this.lab_Title.TabIndex = 5;
            this.lab_Title.Text = "中国重型机械研究院股份公司 电气与智能技术事业部";
            // 
            // timer_01
            // 
            this.timer_01.Interval = 50;
            this.timer_01.Tick += new System.EventHandler(this.timer_01_Tick);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Exit.BackgroundImage")));
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Location = new System.Drawing.Point(1851, 992);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(51, 46);
            this.btn_Exit.TabIndex = 12;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Visible = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lab_name_1
            // 
            this.lab_name_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_name_1.AutoSize = true;
            this.lab_name_1.BackColor = System.Drawing.Color.Transparent;
            this.lab_name_1.Font = new System.Drawing.Font("宋体", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_name_1.Location = new System.Drawing.Point(803, 223);
            this.lab_name_1.Name = "lab_name_1";
            this.lab_name_1.Size = new System.Drawing.Size(50, 53);
            this.lab_name_1.TabIndex = 15;
            this.lab_name_1.Text = " ";
            // 
            // lab_name_2
            // 
            this.lab_name_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_name_2.AutoSize = true;
            this.lab_name_2.BackColor = System.Drawing.Color.Transparent;
            this.lab_name_2.Font = new System.Drawing.Font("宋体", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_name_2.Location = new System.Drawing.Point(928, 223);
            this.lab_name_2.Name = "lab_name_2";
            this.lab_name_2.Size = new System.Drawing.Size(50, 53);
            this.lab_name_2.TabIndex = 16;
            this.lab_name_2.Text = " ";
            // 
            // lab_name_3
            // 
            this.lab_name_3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_name_3.AutoSize = true;
            this.lab_name_3.BackColor = System.Drawing.Color.Transparent;
            this.lab_name_3.Font = new System.Drawing.Font("宋体", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_name_3.Location = new System.Drawing.Point(1054, 223);
            this.lab_name_3.Name = "lab_name_3";
            this.lab_name_3.Size = new System.Drawing.Size(50, 53);
            this.lab_name_3.TabIndex = 17;
            this.lab_name_3.Text = " ";
            this.lab_name_3.Click += new System.EventHandler(this.lab_name_3_Click);
            // 
            // listBox_2
            // 
            this.listBox_2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listBox_2.BackColor = System.Drawing.Color.Red;
            this.listBox_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_2.Font = new System.Drawing.Font("华文行楷", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_2.ForeColor = System.Drawing.Color.Black;
            this.listBox_2.FormattingEnabled = true;
            this.listBox_2.ItemHeight = 45;
            this.listBox_2.Items.AddRange(new object[] {
            "",
            ""});
            this.listBox_2.Location = new System.Drawing.Point(709, 565);
            this.listBox_2.Name = "listBox_2";
            this.listBox_2.Size = new System.Drawing.Size(138, 135);
            this.listBox_2.TabIndex = 18;
            // 
            // listBox_1
            // 
            this.listBox_1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listBox_1.BackColor = System.Drawing.Color.Red;
            this.listBox_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_1.Font = new System.Drawing.Font("华文行楷", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_1.ForeColor = System.Drawing.Color.Black;
            this.listBox_1.FormattingEnabled = true;
            this.listBox_1.ItemHeight = 67;
            this.listBox_1.Items.AddRange(new object[] {
            " "});
            this.listBox_1.Location = new System.Drawing.Point(872, 566);
            this.listBox_1.Name = "listBox_1";
            this.listBox_1.Size = new System.Drawing.Size(201, 67);
            this.listBox_1.TabIndex = 19;
            // 
            // listBox_3
            // 
            this.listBox_3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listBox_3.BackColor = System.Drawing.Color.Red;
            this.listBox_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_3.Font = new System.Drawing.Font("华文行楷", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_3.ForeColor = System.Drawing.Color.Black;
            this.listBox_3.FormattingEnabled = true;
            this.listBox_3.ItemHeight = 39;
            this.listBox_3.Items.AddRange(new object[] {
            "",
            "",
            "",
            ""});
            this.listBox_3.Location = new System.Drawing.Point(1100, 523);
            this.listBox_3.Name = "listBox_3";
            this.listBox_3.Size = new System.Drawing.Size(129, 195);
            this.listBox_3.TabIndex = 20;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.listBox_3);
            this.Controls.Add(this.listBox_1);
            this.Controls.Add(this.listBox_2);
            this.Controls.Add(this.lab_name_3);
            this.Controls.Add(this.lab_name_2);
            this.Controls.Add(this.lab_name_1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lab_Title);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lab_Statue);
            this.Controls.Add(this.gBox_1);
            this.DoubleBuffered = true;
            this.Name = "Form_Main";
            this.Opacity = 0D;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form_Main_MouseClick);
            this.gBox_1.ResumeLayout(false);
            this.gBox_1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBox_1;
        private System.Windows.Forms.RadioButton radioButton_3;
        private System.Windows.Forms.RadioButton radioButton_1;
        private System.Windows.Forms.RadioButton radioButton_2;
        private System.Windows.Forms.Label lab_Statue;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnStart;
        private CCWin.SkinControl.SkinLabel lab_Title;
        private System.Windows.Forms.Timer timer_01;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label lab_name_1;
        private System.Windows.Forms.Label lab_name_2;
        private System.Windows.Forms.Label lab_name_3;
        private System.Windows.Forms.ListBox listBox_2;
        private System.Windows.Forms.ListBox listBox_1;
        private System.Windows.Forms.ListBox listBox_3;
        private System.Windows.Forms.Timer timer1;
    }
}


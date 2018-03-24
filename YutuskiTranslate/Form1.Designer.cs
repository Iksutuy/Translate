namespace YutuskiTranslate
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new DMSkin.Metro.Controls.MetroLabel();
            this.metroLabel1 = new DMSkin.Metro.Controls.MetroLabel();
            this.button1 = new DMSkin.Metro.Controls.MetroButton();
            this.button2 = new DMSkin.Metro.Controls.MetroButton();
            this.label2 = new DMSkin.Metro.Controls.MetroLabel();
            this.button3 = new DMSkin.Metro.Controls.MetroButton();
            this.button4 = new DMSkin.Metro.Controls.MetroButton();
            this.metroLabel2 = new DMSkin.Metro.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(227, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(12, 160);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(227, 96);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Auto",
            "中文",
            "日语",
            "英语",
            "德语",
            "法语",
            "俄语",
            "西班牙语",
            "粤语"});
            this.comboBox2.Location = new System.Drawing.Point(93, 6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(105, 20);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.Text = "Auto";
            this.toolTip1.SetToolTip(this.comboBox2, "请选择源语言,默认\"Auto\"自动识别");
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "中文",
            "日语",
            "英语",
            "德语",
            "法语",
            "俄语",
            "西班牙语",
            "粤语"});
            this.comboBox3.Location = new System.Drawing.Point(93, 134);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(105, 20);
            this.comboBox3.TabIndex = 9;
            this.comboBox3.Text = "中文";
            this.toolTip1.SetToolTip(this.comboBox3, "选择目标语言,默认\"zh-CN\"中文");
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Google",
            "Baidu"});
            this.comboBox1.Location = new System.Drawing.Point(247, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Google";
            this.toolTip1.SetToolTip(this.comboBox1, "选择要使用的翻译引擎");
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(247, 64);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "(尽量)实时翻译";
            this.toolTip1.SetToolTip(this.checkBox1, "自动翻译文本框内容,网速不好者慎用...");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(247, 209);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 44);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "版权所有:YStudio.");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Powered By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DM_FontSize = DMSkin.Metro.MetroLabelSize.Small;
            this.label1.DM_UseCustomBackColor = true;
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "被翻译的文本:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.DM_FontSize = DMSkin.Metro.MetroLabelSize.Small;
            this.metroLabel1.DM_UseCustomBackColor = true;
            this.metroLabel1.Location = new System.Drawing.Point(2, 135);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(83, 17);
            this.metroLabel1.TabIndex = 19;
            this.metroLabel1.Text = "目标翻译结果:";
            // 
            // button1
            // 
            this.button1.DM_UseSelectable = true;
            this.button1.Location = new System.Drawing.Point(273, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "翻译文本";
            this.button1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // button2
            // 
            this.button2.DM_UseSelectable = true;
            this.button2.Location = new System.Drawing.Point(273, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "↑   -   ↓";
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DM_FontSize = DMSkin.Metro.MetroLabelSize.Small;
            this.label2.DM_UseCustomBackColor = true;
            this.label2.Location = new System.Drawing.Point(247, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "选择翻译引擎:";
            // 
            // button3
            // 
            this.button3.DM_UseSelectable = true;
            this.button3.Location = new System.Drawing.Point(273, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "同翻";
            this.button3.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // button4
            // 
            this.button4.DM_UseSelectable = true;
            this.button4.Location = new System.Drawing.Point(204, 134);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 20);
            this.button4.TabIndex = 24;
            this.button4.Text = "Copy";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.DM_FontSize = DMSkin.Metro.MetroLabelSize.Small;
            this.metroLabel2.DM_UseCustomBackColor = true;
            this.metroLabel2.Location = new System.Drawing.Point(2, 258);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(35, 17);
            this.metroLabel2.TabIndex = 25;
            this.metroLabel2.Text = "提示:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(376, 276);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.richTextBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(392, 303);
            this.Name = "Form1";
            this.Text = "Yutsuki Translate";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DMSkin.Metro.Controls.MetroLabel label1;
        private DMSkin.Metro.Controls.MetroLabel metroLabel1;
        private DMSkin.Metro.Controls.MetroButton button1;
        private DMSkin.Metro.Controls.MetroButton button2;
        private DMSkin.Metro.Controls.MetroLabel label2;
        private DMSkin.Metro.Controls.MetroButton button3;
        private DMSkin.Metro.Controls.MetroButton button4;
        private DMSkin.Metro.Controls.MetroLabel metroLabel2;
    }
}


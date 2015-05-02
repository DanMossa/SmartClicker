namespace AutoClicker
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
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSeed = new System.Windows.Forms.Button();
            this.labelSeed = new System.Windows.Forms.Label();
            this.timerSeed = new System.Windows.Forms.Timer(this.components);
            this.clicksPerSecond = new System.Windows.Forms.TextBox();
            this.refine = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timerAutoClick = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.webControl1 = new Awesomium.Windows.Forms.WebControl(this.components);
            this.webClient1 = new System.Net.WebClient();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSeed
            // 
            this.buttonSeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSeed.Location = new System.Drawing.Point(-174, 75);
            this.buttonSeed.Name = "buttonSeed";
            this.buttonSeed.Size = new System.Drawing.Size(166, 57);
            this.buttonSeed.TabIndex = 1;
            this.buttonSeed.Text = "Click this button as fast as you can for 30 seconds";
            this.buttonSeed.UseVisualStyleBackColor = true;
            this.buttonSeed.Click += new System.EventHandler(this.buttonClickFast_Click);
            // 
            // labelSeed
            // 
            this.labelSeed.AutoSize = true;
            this.labelSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeed.Location = new System.Drawing.Point(201, 117);
            this.labelSeed.Name = "labelSeed";
            this.labelSeed.Size = new System.Drawing.Size(36, 25);
            this.labelSeed.TabIndex = 2;
            this.labelSeed.Text = "30";
            // 
            // timerSeed
            // 
            this.timerSeed.Interval = 1000;
            this.timerSeed.Tick += new System.EventHandler(this.timerSeed_Tick);
            // 
            // clicksPerSecond
            // 
            this.clicksPerSecond.Location = new System.Drawing.Point(12, 93);
            this.clicksPerSecond.Name = "clicksPerSecond";
            this.clicksPerSecond.ReadOnly = true;
            this.clicksPerSecond.Size = new System.Drawing.Size(100, 20);
            this.clicksPerSecond.TabIndex = 3;
            // 
            // refine
            // 
            this.refine.Location = new System.Drawing.Point(320, 12);
            this.refine.Name = "refine";
            this.refine.Size = new System.Drawing.Size(106, 23);
            this.refine.TabIndex = 4;
            this.refine.Text = "Refine Autoclicker";
            this.refine.UseVisualStyleBackColor = true;
            this.refine.Click += new System.EventHandler(this.refine_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Move your mouse to center of where you want to click and press ` to start/stop";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // webControl1
            // 
            this.webControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.webControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.webControl1.Location = new System.Drawing.Point(0, 0);
            this.webControl1.Size = new System.Drawing.Size(320, 479);
            this.webControl1.TabIndex = 7;
            this.webControl1.TitleChanged += new Awesomium.Core.TitleChangedEventHandler(this.Awesomium_Windows_Forms_WebControl_TitleChanged);
            this.webControl1.ShowCreatedWebView += new Awesomium.Core.ShowCreatedWebViewEventHandler(this.Awesomium_Windows_Forms_WebControl_ShowCreatedWebView);
            // 
            // webClient1
            // 
            this.webClient1.BaseAddress = "";
            this.webClient1.CachePolicy = null;
            this.webClient1.Credentials = null;
            this.webClient1.Encoding = ((System.Text.Encoding)(resources.GetObject("webClient1.Encoding")));
            this.webClient1.Headers = ((System.Net.WebHeaderCollection)(resources.GetObject("webClient1.Headers")));
            this.webClient1.QueryString = ((System.Collections.Specialized.NameValueCollection)(resources.GetObject("webClient1.QueryString")));
            this.webClient1.UseDefaultCredentials = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OrangeRed;
            this.ClientSize = new System.Drawing.Size(320, 479);
            this.Controls.Add(this.webControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refine);
            this.Controls.Add(this.clicksPerSecond);
            this.Controls.Add(this.labelSeed);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSeed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "DG Smart AutoClicker 0.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSeed;
        private System.Windows.Forms.Label labelSeed;
        private System.Windows.Forms.Timer timerSeed;
        private System.Windows.Forms.TextBox clicksPerSecond;
        private System.Windows.Forms.Button refine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerAutoClick;
        private System.Windows.Forms.TextBox textBox1;
        private Awesomium.Windows.Forms.WebControl webControl1;
        private System.Net.WebClient webClient1;
    }
}


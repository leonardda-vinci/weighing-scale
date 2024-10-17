namespace Scale_v2
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
		/// the contents of method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			logTextBox = new System.Windows.Forms.TextBox();
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.ip1 = new System.Windows.Forms.CheckBox();
			this.ip2 = new System.Windows.Forms.CheckBox();
			this.ip3 = new System.Windows.Forms.CheckBox();
			this.startBtn = new System.Windows.Forms.Button();
			this.stopBtn = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timerend = new System.Windows.Forms.Timer(this.components);
			this.download = new System.Windows.Forms.CheckBox();
			this.upload = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.delet = new System.Windows.Forms.CheckBox();
			this.clear = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.copy = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// logTextBox
			// 
			logTextBox.BackColor = System.Drawing.SystemColors.Window;
			logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			logTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			logTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			logTextBox.Location = new System.Drawing.Point(12, 12);
			logTextBox.Multiline = true;
			logTextBox.Name = "logTextBox";
			logTextBox.ReadOnly = true;
			logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			logTextBox.Size = new System.Drawing.Size(545, 195);
			logTextBox.TabIndex = 0;
			// 
			// backgroundWorker1
			// 
			backgroundWorker1.WorkerReportsProgress = true;
			backgroundWorker1.WorkerSupportsCancellation = true;
			backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// ip1
			// 
			this.ip1.AutoSize = true;
			this.ip1.Location = new System.Drawing.Point(6, 19);
			this.ip1.Name = "ip1";
			this.ip1.Size = new System.Drawing.Size(105, 17);
			this.ip1.TabIndex = 1;
			this.ip1.Text = "IP: 192.168.1.21";
			this.ip1.UseVisualStyleBackColor = true;
			this.ip1.CheckedChanged += new System.EventHandler(this.ip1_CheckedChanged);
			// 
			// ip2
			// 
			this.ip2.AutoSize = true;
			this.ip2.Location = new System.Drawing.Point(6, 42);
			this.ip2.Name = "ip2";
			this.ip2.Size = new System.Drawing.Size(105, 17);
			this.ip2.TabIndex = 2;
			this.ip2.Text = "IP: 192.168.1.22";
			this.ip2.UseVisualStyleBackColor = true;
			this.ip2.CheckedChanged += new System.EventHandler(this.ip2_CheckedChanged);
			// 
			// ip3
			// 
			this.ip3.AutoSize = true;
			this.ip3.Location = new System.Drawing.Point(6, 65);
			this.ip3.Name = "ip3";
			this.ip3.Size = new System.Drawing.Size(105, 17);
			this.ip3.TabIndex = 3;
			this.ip3.Text = "IP: 192.168.1.23";
			this.ip3.UseVisualStyleBackColor = true;
			this.ip3.CheckedChanged += new System.EventHandler(this.ip3_CheckedChanged);
			// 
			// startBtn
			// 
			this.startBtn.ForeColor = System.Drawing.Color.LimeGreen;
			this.startBtn.Location = new System.Drawing.Point(11, 215);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(60, 25);
			this.startBtn.TabIndex = 4;
			this.startBtn.Text = "Start";
			this.startBtn.UseVisualStyleBackColor = true;
			this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
			// 
			// stopBtn
			// 
			this.stopBtn.ForeColor = System.Drawing.Color.Orange;
			this.stopBtn.Location = new System.Drawing.Point(77, 215);
			this.stopBtn.Name = "stopBtn";
			this.stopBtn.Size = new System.Drawing.Size(60, 25);
			this.stopBtn.TabIndex = 5;
			this.stopBtn.Text = "Stop";
			this.stopBtn.UseVisualStyleBackColor = true;
			this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timerend
			// 
			this.timerend.Tick += new System.EventHandler(this.timerend_Tick);
			// 
			// download
			// 
			this.download.AutoSize = true;
			this.download.Location = new System.Drawing.Point(6, 19);
			this.download.Name = "download";
			this.download.Size = new System.Drawing.Size(74, 17);
			this.download.TabIndex = 6;
			this.download.Text = "Download";
			this.download.UseVisualStyleBackColor = true;
			this.download.CheckedChanged += new System.EventHandler(this.download_CheckedChanged);
			// 
			// upload
			// 
			this.upload.AutoSize = true;
			this.upload.Location = new System.Drawing.Point(6, 42);
			this.upload.Name = "upload";
			this.upload.Size = new System.Drawing.Size(60, 17);
			this.upload.TabIndex = 7;
			this.upload.Text = "Upload";
			this.upload.UseVisualStyleBackColor = true;
			this.upload.CheckedChanged += new System.EventHandler(this.upload_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ip1);
			this.groupBox1.Controls.Add(this.ip2);
			this.groupBox1.Controls.Add(this.ip3);
			this.groupBox1.Location = new System.Drawing.Point(563, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(141, 89);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Scale Devices";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.delet);
			this.groupBox2.Controls.Add(this.download);
			this.groupBox2.Controls.Add(this.upload);
			this.groupBox2.Location = new System.Drawing.Point(563, 115);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(141, 92);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Actions";
			// 
			// delet
			// 
			this.delet.AutoSize = true;
			this.delet.Location = new System.Drawing.Point(6, 65);
			this.delet.Name = "delet";
			this.delet.Size = new System.Drawing.Size(57, 17);
			this.delet.TabIndex = 8;
			this.delet.Text = "Delete";
			this.delet.UseVisualStyleBackColor = true;
			this.delet.CheckedChanged += new System.EventHandler(this.delet_CheckedChanged_1);
			// 
			// clear
			// 
			this.clear.ForeColor = System.Drawing.Color.Red;
			this.clear.Location = new System.Drawing.Point(143, 215);
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(60, 25);
			this.clear.TabIndex = 10;
			this.clear.Text = "Clear";
			this.clear.UseVisualStyleBackColor = true;
			this.clear.Click += new System.EventHandler(this.clear_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.ErrorImage = global::Scale_v2.Properties.Resources.scale;
			this.pictureBox1.Image = global::Scale_v2.Properties.Resources.scale;
			this.pictureBox1.InitialImage = global::Scale_v2.Properties.Resources.scale;
			this.pictureBox1.Location = new System.Drawing.Point(716, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(150, 150);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(760, 167);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Version 2.0";
			// 
			// copy
			// 
			this.copy.ForeColor = System.Drawing.Color.DodgerBlue;
			this.copy.Location = new System.Drawing.Point(210, 215);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(60, 25);
			this.copy.TabIndex = 12;
			this.copy.Text = "Copy";
			this.copy.UseVisualStyleBackColor = true;
			this.copy.Click += new System.EventHandler(this.copy_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(878, 252);
			this.Controls.Add(this.copy);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.clear);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.stopBtn);
			this.Controls.Add(this.startBtn);
			this.Controls.Add(logTextBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.ShowInTaskbar = false;
			this.Text = "Weighing Scale";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox ip1;
		private System.Windows.Forms.CheckBox ip2;
		private System.Windows.Forms.CheckBox ip3;
		private System.Windows.Forms.Button startBtn;
		private System.Windows.Forms.Button stopBtn;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timerend;
		private System.Windows.Forms.CheckBox download;
		private System.Windows.Forms.CheckBox upload;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox delet;
		private System.Windows.Forms.Button clear;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private static System.Windows.Forms.TextBox logTextBox;
		private static System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}
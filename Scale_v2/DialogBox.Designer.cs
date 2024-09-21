namespace Scale_v2
{
	partial class DialogBox
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogBox));
			this.radioBtnS1 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioBtnS2 = new System.Windows.Forms.RadioButton();
			this.radioBtnS3 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBoxS3 = new System.Windows.Forms.CheckBox();
			this.checkBoxS2 = new System.Windows.Forms.CheckBox();
			this.checkBoxS1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioBtnS1
			// 
			this.radioBtnS1.AutoSize = true;
			this.radioBtnS1.Location = new System.Drawing.Point(6, 19);
			this.radioBtnS1.Name = "radioBtnS1";
			this.radioBtnS1.Size = new System.Drawing.Size(107, 17);
			this.radioBtnS1.TabIndex = 0;
			this.radioBtnS1.TabStop = true;
			this.radioBtnS1.Text = "S1: 192.168.1.21";
			this.radioBtnS1.UseVisualStyleBackColor = true;
			this.radioBtnS1.CheckedChanged += new System.EventHandler(this.radioBtnS1_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioBtnS2);
			this.groupBox1.Controls.Add(this.radioBtnS3);
			this.groupBox1.Controls.Add(this.radioBtnS1);
			this.groupBox1.Location = new System.Drawing.Point(18, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(117, 94);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "From";
			// 
			// radioBtnS2
			// 
			this.radioBtnS2.AutoSize = true;
			this.radioBtnS2.Location = new System.Drawing.Point(6, 42);
			this.radioBtnS2.Name = "radioBtnS2";
			this.radioBtnS2.Size = new System.Drawing.Size(107, 17);
			this.radioBtnS2.TabIndex = 2;
			this.radioBtnS2.TabStop = true;
			this.radioBtnS2.Text = "S2: 192.168.1.22";
			this.radioBtnS2.UseVisualStyleBackColor = true;
			this.radioBtnS2.CheckedChanged += new System.EventHandler(this.radioBtnS2_CheckedChanged);
			// 
			// radioBtnS3
			// 
			this.radioBtnS3.AutoSize = true;
			this.radioBtnS3.Location = new System.Drawing.Point(6, 65);
			this.radioBtnS3.Name = "radioBtnS3";
			this.radioBtnS3.Size = new System.Drawing.Size(107, 17);
			this.radioBtnS3.TabIndex = 3;
			this.radioBtnS3.TabStop = true;
			this.radioBtnS3.Text = "S3: 192.168.1.23";
			this.radioBtnS3.UseVisualStyleBackColor = true;
			this.radioBtnS3.CheckedChanged += new System.EventHandler(this.radioBtnS3_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBoxS3);
			this.groupBox2.Controls.Add(this.checkBoxS2);
			this.groupBox2.Controls.Add(this.checkBoxS1);
			this.groupBox2.Location = new System.Drawing.Point(157, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(118, 94);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "To";
			// 
			// checkBoxS3
			// 
			this.checkBoxS3.AutoSize = true;
			this.checkBoxS3.Location = new System.Drawing.Point(6, 66);
			this.checkBoxS3.Name = "checkBoxS3";
			this.checkBoxS3.Size = new System.Drawing.Size(108, 17);
			this.checkBoxS3.TabIndex = 4;
			this.checkBoxS3.Text = "S3: 192.168.1.23";
			this.checkBoxS3.UseVisualStyleBackColor = true;
			this.checkBoxS3.CheckedChanged += new System.EventHandler(this.checkBoxS3_CheckedChanged);
			// 
			// checkBoxS2
			// 
			this.checkBoxS2.AutoSize = true;
			this.checkBoxS2.Location = new System.Drawing.Point(6, 42);
			this.checkBoxS2.Name = "checkBoxS2";
			this.checkBoxS2.Size = new System.Drawing.Size(108, 17);
			this.checkBoxS2.TabIndex = 3;
			this.checkBoxS2.Text = "S2: 192.168.1.22";
			this.checkBoxS2.UseVisualStyleBackColor = true;
			this.checkBoxS2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// checkBoxS1
			// 
			this.checkBoxS1.AutoSize = true;
			this.checkBoxS1.Location = new System.Drawing.Point(6, 19);
			this.checkBoxS1.Name = "checkBoxS1";
			this.checkBoxS1.Size = new System.Drawing.Size(108, 17);
			this.checkBoxS1.TabIndex = 0;
			this.checkBoxS1.Text = "S1: 192.168.1.21";
			this.checkBoxS1.UseVisualStyleBackColor = true;
			this.checkBoxS1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// button1
			// 
			this.button1.ForeColor = System.Drawing.Color.LimeGreen;
			this.button1.Location = new System.Drawing.Point(149, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(60, 25);
			this.button1.TabIndex = 5;
			this.button1.Text = "Transfer";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.White;
			this.button2.ForeColor = System.Drawing.Color.Red;
			this.button2.Location = new System.Drawing.Point(215, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(60, 25);
			this.button2.TabIndex = 6;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// DialogBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(293, 148);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DialogBox";
			this.Text = "DialogBox";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton radioBtnS1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioBtnS2;
		private System.Windows.Forms.RadioButton radioBtnS3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBoxS1;
		private System.Windows.Forms.CheckBox checkBoxS3;
		private System.Windows.Forms.CheckBox checkBoxS2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}
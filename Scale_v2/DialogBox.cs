using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scale_v2;
using ScaleParser;

namespace Scale_v2
{
	public partial class DialogBox : Form
	{
		IniParser iniFile;

		public string CheckBoxS1Checked { get; private set; }
		public string CheckBoxS2Checked { get; private set; }
		public string CheckBoxS3Checked { get; private set; }
		public string SelectedRadioButton { get; private set; }

		public DialogBox()
		{
			this.iniFile = new IniParser(@"C:\RCS\Scale\config.ini");

			InitializeComponent();


			/*this.checkBoxS1.Checked = Properties.Settings.Default.CB1;
			this.checkBoxS2.Checked = Properties.Settings.Default.CB2;
			this.checkBoxS3.Checked = Properties.Settings.Default.CB3;*/
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to Copy?", "Transfer", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{		
				if (radioBtnS1.Checked)
				{
					SelectedRadioButton = this.iniFile.GetSetting("Address", "SD1");
				}
				else if (radioBtnS2.Checked)
				{
					SelectedRadioButton = this.iniFile.GetSetting("Address", "SD2");
				}
				else if (radioBtnS3.Checked)
				{
					SelectedRadioButton = this.iniFile.GetSetting("Address", "SD3");
				}

				if (checkBoxS1.Checked)
				{
					CheckBoxS1Checked = this.iniFile.GetSetting("Address", "SD1");
				}
				
				if (checkBoxS2.Checked)
				{
					CheckBoxS2Checked = this.iniFile.GetSetting("Address", "SD2");
				}
				
				if (checkBoxS3.Checked)
				{
					CheckBoxS3Checked = this.iniFile.GetSetting("Address", "SD3");
				}
				this.DialogResult = DialogResult.OK;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to Cancel?", "Cancel", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)  
			{
				this.SelectedRadioButton = "";
				this.Close();
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			/*Properties.Settings.Default.CB1 = this.checkBoxS1.Checked;
			Properties.Settings.Default.Save();*/
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			/*Properties.Settings.Default.CB2 = this.checkBoxS2.Checked;
			Properties.Settings.Default.Save();*/
		}

		private void checkBoxS3_CheckedChanged(object sender, EventArgs e)
		{
			/*Properties.Settings.Default.CB3 = this.checkBoxS3.Checked;
			Properties.Settings.Default.Save();*/
		}


		private void radioBtnS1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioBtnS1.Checked)
			{
				checkBoxS1.Enabled = false;
				checkBoxS1.Checked = false;
				checkBoxS2.Enabled = true;
				checkBoxS3.Enabled = true;
			}
		}

		private void radioBtnS2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioBtnS2.Checked)
			{
				checkBoxS1.Enabled = true;
				checkBoxS2.Enabled = false;
				checkBoxS2.Checked = false;
				checkBoxS3.Enabled = true;
			}
		}

		private void radioBtnS3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioBtnS3.Checked)
			{
				checkBoxS1.Enabled = true;
				checkBoxS2.Enabled = true;
				checkBoxS3.Enabled = false;
				checkBoxS3.Checked = false;
			}
		}
	}
}

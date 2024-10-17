using Scale_v2;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScaleParser;
using System;
using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Net;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;
using System.Security.Policy;

namespace Scale_v2
{
	public partial class Form1 : Form
	{
		string[] devices;
		string sourceDir;
		string downloadDir;
		string extractDir;
		string aclasApp;
		string inDir;

		int loop = 1;
		int fiveM;
		private FileSystemWatcher fileWatcher;
		IniParser iniFile;
		public Form1()
		{
			this.devices = new string[3];

			this.iniFile = new IniParser(@"C:\RCS\Scale\config.ini");
			this.sourceDir = this.iniFile.GetSetting("Settings", "Source");
			this.downloadDir = this.iniFile.GetSetting("Target", "DLPath");
			this.aclasApp = this.iniFile.GetSetting("APP", "EXE");
			this.extractDir = this.iniFile.GetSetting("Target", "ExtractPath");
			this.inDir = this.iniFile.GetSetting("Settings", "In");

			Console.WriteLine($"Source = " + this.iniFile.GetSetting("Settings", "Source"));

			InitializeComponent();

			if (InitClass.CheckApp() == true)
			{
				MessageBox.Show("Application is already running.", "Weighing Scale Integration", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
				Application.Exit();
			}

			StartTime();
			
			if (!Directory.Exists(this.downloadDir))
			{
				Directory.CreateDirectory(this.downloadDir);
			}
			
			if (!Directory.Exists(this.extractDir))
			{
				Directory.CreateDirectory(this.extractDir);
			}

			this.devices = this.getScaleDevices();

			try
			{
				fileWatcher = new FileSystemWatcher(this.sourceDir);
				fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
				fileWatcher.Changed += OnChanged;

				fileWatcher.Filter = "*bingo";
				// fileWatcher.IncludeSubdirectories = true;
				fileWatcher.EnableRaisingEvents = true;
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}

			logTextBox.AppendText("Scale Running...\r\n");
			FindingBingo(this.sourceDir);

			this.ip1.Checked = Properties.Settings.Default.SD1;
			this.ip2.Checked = Properties.Settings.Default.SD2;
			this.ip3.Checked = Properties.Settings.Default.SD3;
			this.download.Checked = Properties.Settings.Default.Download;
			this.upload.Checked = Properties.Settings.Default.Upload;
			this.delet.Checked = Properties.Settings.Default.Delete;
		}

		private static void OnChanged(object sender, FileSystemEventArgs e)
		{
			if (e.ChangeType != WatcherChangeTypes.Changed)
			{
				return;
			}

			Debug.WriteLine($"Changed: {e.FullPath} - {e.ChangeType}");
			if (e.FullPath.Contains("bingo"))
			{
				if (File.Exists(e.FullPath))
				{
					logTextBox.Invoke((Action)delegate
					{
						logTextBox.Text = "bingo file found!" + "\r\n" + logTextBox.Text;
					});

					if (!backgroundWorker1.IsBusy)
					{
						backgroundWorker1.RunWorkerAsync();
					}
				}
			}
		}

		private void FindingBingo(string source)
		{
			string[] bingoFiles = Directory.GetFiles(source, "*bingo");
			if (bingoFiles.Length > 0)
			{
				backgroundWorker1.RunWorkerAsync();
			}
		}


		private string[] getScaleDevices()
		{
			startBtn.Enabled = false;
			string[] devices = new string[3];
			for (int i = 1; i <= 3; i++)
			{
				string ip = this.iniFile.GetSetting("Address", "SD" + i.ToString());
				if ((i == 1) && (Properties.Settings.Default.SD1))
				{
					if (CheckPing(ip))
					{
						logs($"Device {ip} is available!");
						devices[i - 1] = ip;
					}
					else
					{
						logs($"Device {ip} is not available!");
					}
				}

				if ((i == 2) && (Properties.Settings.Default.SD2))
				{
					if (CheckPing(ip))
					{
						logs($"Device {ip} is available!");
						devices[i - 1] = ip;
					}
					else
					{
						logs($"Device {ip} is not available!");
					}
				}

				if ((i == 3) && (Properties.Settings.Default.SD3))
				{
					if (CheckPing(ip))
					{
						logs($"Device {ip} is available!");
						devices[i - 1] = ip;
					}
					else
					{
						logs($"Device {ip} is not available!");
					}
				}
			}

			return devices;
		}

		private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			logs($"Do Work.");

			if (Properties.Settings.Default.Upload)
			{
				Upload(this.devices);
			}

			if (Properties.Settings.Default.Download)
			{
				for (int i = 0; i < this.devices.Length; i++)
				{
					Download(this.devices[i], this.inDir, "txt");
				}

				using (StreamWriter sw = new StreamWriter(this.inDir + "bingo"))
				{
					sw.WriteLine();
				}

				await this.HTTP(this.iniFile.GetSetting("Address", "Get"));
			}
			if (Properties.Settings.Default.Delete)
			{
				for (int i = 0; i < this.devices.Length; i++)
				{
					Delete(this.devices[i]);
				}
			}
		}
		
		private bool CheckPing(string ip)
		{
			Ping sender = new Ping();
			PingOptions options = new PingOptions();
			PingReply reply = sender.Send(ip);
			logs($"Pinging " + ip);
			if (reply.Status == IPStatus.Success)
			{
				logs($"The {ip} IP Address is available.");
				return true;
			}
			else
			{
				logs($"{ip} is not available.");
				return false;
			}
		}

		public string Download(string ip, string target, string ext)
		{
			DateTime date = DateTime.Today;
			string current = String.Format("{0:yyyyMMdd}", date);
			string filename = ip + "_PLU-UP_" + current + "." + ext;
			if (ext == "iu")
			{
				filename = "PLU." + current + "." + ext;
			}
			
			try
			{
				logs("Downloading Weighing Scale Data in IP of " + ip);
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.CreateNoWindow = false;
				startInfo.UseShellExecute = false;
				startInfo.FileName = this.iniFile.GetSetting("APP", "EXE");
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				startInfo.Arguments = @"-h " + ip + @":5002 -t UP -b PLU -n " + target + filename + " -f Ascii";
				logs(ip + ": download AclasSDK");
				using (Process process = Process.Start(startInfo))
				{
					process.WaitForExit();
				}

				logs($"{filename} successfully created!");

				string from = Path.Combine(target, filename);
				string to = Path.Combine(this.extractDir, filename);
				if (File.Exists(to))
				{
					File.Delete(to);
				}
				File.Copy(from, to);
				logs($"{filename} successfully copied.");
			}
			catch (Exception err)
			{
				logs($"Extraction Failed: {err.Message}");
				// return string.Empty;
			}

			return Path.Combine(this.extractDir + filename);
		}

		public void Upload(string[] ip)
		{
			DirectoryInfo dirinfo = new DirectoryInfo(this.sourceDir);
			FileInfo[] files = dirinfo.GetFiles("*.iu");
			FileInfo[] sortedFiles = files.OrderBy(f => f.CreationTime).ToArray();
			string[] importFile = sortedFiles.Select(f => f.FullName).ToArray();

			if (File.Exists(this.sourceDir + "\\bingo"))
			{
				logs("Deleting bingo...");
				File.Delete(this.sourceDir + "\\bingo");
				logs("Bingo has been deleted successfully.");
			}

			if (importFile.Length > 0)
			{
				foreach (string ldlFile in importFile)
				{
					string name = Path.GetFileName(ldlFile);
					string[] token = name.Split('.');

					for (int i = 0; i < ip.Length; i++)
					{
						try
						{
							logs(ip[i] + ": Uploading" + name);
							// logs("Uploading all Data on " + ip);
							ProcessStartInfo startInfo = new ProcessStartInfo();
							startInfo.CreateNoWindow = false;
							startInfo.UseShellExecute = false;
							startInfo.FileName = this.aclasApp;
							startInfo.WindowStyle = ProcessWindowStyle.Hidden;
							//startInfo.Arguments = @"-h " + ip[i] + @":5002 -t DOWN -b PLU -n " + this.sourceDir + name + " -f Ascii";
							if (token[0] == "PLU")
							{
								logs(ip[i] + ": Processing file " + name);
								startInfo.Arguments = @"-h " + ip[i] + @":5002 -t DOWN -b PLU -n " + this.sourceDir + name + " -f Ascii";
							}
							else
							{
								startInfo.Arguments = @"-h " + token[0] + @":5002 -t DOWN -b PLU -n " + this.sourceDir + name + " -f Ascii";
							}

							logs(ip[i] + ": upload AclasSDK");
							using (Process process = Process.Start(startInfo))
							{
								if (process != null)
								{
									process.WaitForExit();
								}
							}
						}
						catch (Exception err)
						{
							logs(ip[i] + ": Failed to upload: " + err.Message);
						}
					}
					string dldest = Path.Combine(this.downloadDir, name);
					if (File.Exists(dldest))
					{
						File.Delete(dldest);
					}
					File.Move(ldlFile, dldest);
					logs("Successfully moved " + name + " !");
				}
			}
		}

		//private void UploadToSMS(string ip)
		//{
		//	string FileType = "*.txt";
		//	DateTime date = DateTime.Today;
		//	string current = String.Format("{0:yyyyMMdd}", date);
		//	string[] GetFile = Directory.GetFiles(this.extractDir, FileType);

		//	foreach (string localFile in GetFile)
		//	{
		//		string filename = Path.GetFileName(localFile);
		//		string FileIdentifier = ip + "_PLU-UP_" + current + ".txt";
		//		if (FileIdentifier == filename)
		//		{
		//			using (var reader = new StreamReader(localFile))
		//			{
		//				reader.ReadLine();
		//				while (!reader.EndOfStream)
		//				{
		//					string value = reader.ReadLine();
		//					string[] spliter = value.Split('\t');
		//					string Barcode = spliter[0].ToString();
		//					string UnitID = spliter[11].ToString();
		//					string Description = spliter[4].ToString();
		//					double Price = Convert.ToDouble(spliter[12].ToString()) * 100;
		//					// await HTTP(ip, Barcode, Description, Price, UnitID);
		//				}
		//			}
		//			logs("Upload of " + ip + " complete");
		//		}
		//	}
		//	string FileName = ip + "_PLU-UP_" + current + ".txt";
		//	string destpath = Path.Combine(this.extractDir, FileName);
		//	if (!File.Exists(destpath))
		//	{
		//		logs("Upload of " + ip + " failed due to missing file.");
		//	}
		//}
		
		private async Task HTTP(string url)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					/* var data = new Dictionary<string, string>
					{
						{
							"device_id", ip
						},
						{
							"barcode", Barcode
						},
						{
							"description", Description
						},
						{
							"price", Price.ToString()
						},
						{
							"unit_id", UnitID
						}
					};

					var content = new FormUrlEncodedContent(data);
					var response = await client.PostAsync(post, content); */
					var response = await client.GetAsync(url);
					if (response.IsSuccessStatusCode)
					{
						/*
						string res = await response.Content.ReadAsStringAsync();
						logs($"Inserting {Barcode}, {UnitID}, {Description}, and {Price} is successful."); 
						*/
					}
					else
					{
						/* 
						 logs($"HTTP request failed with status code: {response.StatusCode}");
						logs($"Inserting {Barcode}, {UnitID}, {Description}, and {Price} Failed");
						*/
					}
				}
			}
			catch (Exception err)
			{
				logs("Uploading data to the SMS failed: " + err.Message);
			}
		}

		private void Delete(string ip)
		{
			try
			{
				string[] getdeletefile = Directory.GetFiles(this.sourceDir, "*.d");

				if (File.Exists(this.sourceDir + "bingo"))
				{
					File.Delete(this.sourceDir + "bingo");
				}

				foreach (string lDelFile in getdeletefile)
				{
					string name = Path.GetFileName(lDelFile);
					ProcessStartInfo startInfo = new ProcessStartInfo();
					startInfo.CreateNoWindow = false;
					startInfo.UseShellExecute = false;
					startInfo.FileName = this.aclasApp;
					startInfo.WindowStyle = ProcessWindowStyle.Hidden;

					startInfo.Arguments = @"-h " + ip + @":5002 -t DEL -b PLU -n " + this.sourceDir + name + " -f Ascii";
					logs(ip + ": delete AclasSDK");
					using (Process process = Process.Start(startInfo))
					{

						if (process != null)
						{
							process.WaitForExit();
							logs($"Data of {ip} deleted.");
						}
						else
						{
							throw new InvalidOperationException("Failed to start AclasSDKConsole.exe process");
						}
					}

					string dldest = Path.Combine(this.downloadDir, name);
					if (File.Exists(dldest))
					{
						File.Delete(dldest);
					}
					File.Move(lDelFile, dldest);
				}
			}
			catch (InvalidOperationException err)
			{
				logs($"Failed to delete date: " + err.Message);
			}
		}

		private void clear_Click(object sender, EventArgs e)
		{
			//string[] ipAddress = new string[3];
			DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Warning!", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				for (int i = 1; i <= 3; i++)
				{
					string ip = this.iniFile.GetSetting("Address", "SD" + i.ToString());
					if ((i == 1) && (ip1.Checked == true))
					{
						ClearProcess(ip);
					}

					if ((i == 2) && (ip2.Checked == true))
					{
						ClearProcess(ip);
					}

					if ((i == 3) && (ip3.Checked == true))
					{
						ClearProcess(ip);
					}
				}
			}
			//ClearProcess(ipAddress);
		}
		private void ClearProcess(string ip)
		{
			string ext = ".d";
			DateTime date = DateTime.Today;
			string current = String.Format("{0:yyyyMMdd}", date);
			string filename = ip + "_PLU-UP_" + current + ".txt";
			string to = this.iniFile.GetSetting("Settings", "Source");
			string from = this.iniFile.GetSetting("Target", "ExtractPath");

			
			logs("Downloading...");
			Download(ip, this.inDir, "txt");

			string[] files = Directory.GetFiles(from, filename);

			foreach (string file in files)
			{
				string getfile = Path.GetFileNameWithoutExtension(file);
				string newFile = getfile + ext;
				string destpath = Path.Combine(to, newFile);

				if (File.Exists(destpath))
				{
					File.Delete(destpath);
				}
				File.Copy(file, destpath);
				logs("Files successfully copied!");

				string checkpath = Path.Combine(to, newFile);
				string bingoPath = to + "bingo";

				if (File.Exists(checkpath))
				{
					using (StreamWriter sw = new StreamWriter(bingoPath))
					{
						sw.WriteLine();
					}
				}
				else
				{
					logs($"The {newFile} file cannot be found on the directory!");
				}

				if (File.Exists(bingoPath))
				{
					logs("Deleting...");
					Delete(ip);
				}
				else
				{
					logs($"Bingo file cannot be found!");
				}
			}
		}

		private void copy_Click(object sender, EventArgs e)
		{
			string scalePath = this.iniFile.GetSetting("Settings", "Source");
			// string[] ipAddress = new string[3];
			DialogBox dialog = new DialogBox();
			dialog.ShowDialog();
			List<string> scale = new List<string>();
			if (!string.IsNullOrEmpty(dialog.CheckBoxS1Checked) && dialog.CheckBoxS1Checked.Length > 0)
			{
				scale.Add(dialog.CheckBoxS1Checked);
			}
			if (!string.IsNullOrEmpty(dialog.CheckBoxS2Checked) && dialog.CheckBoxS2Checked.Length > 0)
			{
				scale.Add(dialog.CheckBoxS2Checked);
			}
			if (!string.IsNullOrEmpty(dialog.CheckBoxS3Checked) && dialog.CheckBoxS3Checked.Length > 0)
			{
				scale.Add(dialog.CheckBoxS3Checked);
			}

			string radioBtn = dialog.SelectedRadioButton;

			if (radioBtn != "")
			{
				//string file = "";

				for (int i = 1; i <= 3; i++)
				{
					if (radioBtn == this.iniFile.GetSetting("Address", "SD" + i.ToString()))
					{
						Download(radioBtn, this.sourceDir, "iu");
						using (StreamWriter sw = new StreamWriter(this.sourceDir + "bingo"))
						{
							sw.WriteLine();
						}
						break;
					}
				}

				/* if (file.Length > 0)
				{
					foreach (string sd in scale)
					{
						//MessageBox.Show(file);
						Upload(sd, file);
						if (File.Exists(file))
						{
							File.Delete(file);
						}
						Download(sd, this.inDir, "txt");
						using (StreamWriter sw = new StreamWriter(this.sourceDir + "bingo"))
						{
							sw.WriteLine();
						}

						this.HTTP(this.iniFile.GetSetting("Address", "Get")).Wait();

						//UploadToSMS(sd, file);
						logs($"The data from {radioBtn} are successfully transfered on {sd}.");
					}
				} */
			}
		}

		public void Upload(string ip, string file)
		{
			string exe = this.iniFile.GetSetting("APP", "EXE");
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.CreateNoWindow = false;
				startInfo.UseShellExecute = false;
				startInfo.FileName = exe;
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				startInfo.Arguments = @"-h " + ip + @":5002 -t DOWN -b PLU -n " + file + " -f Ascii";
				logs($"Uploading data to {ip}...");
				using (Process process = Process.Start(startInfo))
				{
					if (process != null)
					{
						process.WaitForExit();
					}
				}
			}
			catch (Exception err)
			{
				logs(ip + ": Failed to upload: " + err.Message);
			}
		}

		private void StatusLog(string message)
		{
			DateTime now = DateTime.Now;
			DateTime date = DateTime.Today;
			string current = String.Format("{0:yyyyMMdd}", date);
			string logPath = this.iniFile.GetSetting("Target", "StatusPath");
			string branch = this.iniFile.GetSetting("Settings", "Branch");
			string dat = (branch + "." + current + ".SCALE.LOGS.dat");
			string file = Path.Combine(logPath, dat);
			
			if (!Directory.Exists(logPath))
			{
				Directory.CreateDirectory(logPath);
			}

			using (StreamWriter sw = new StreamWriter(file, true))
			{
				sw.WriteLine($"{now:yyyy-MM-dd HH:mm:ss}" + "             " + message + "\r\n");
			}
		}

		private void startBtn_Click(object sender, EventArgs e)
		{
			logs("Weighing Scale Started!");

			loop = 1;
			startBtn.Enabled = false;
			stopBtn.Enabled = true;
			backgroundWorker1.RunWorkerAsync();
		}

		private void stopBtn_Click(object sender, EventArgs e)
		{
			timer1.Stop();
			timer1.Dispose();
			logs("Weighing Scale Stopped!");

			loop = 0;
			stopBtn.Enabled = false;
			startBtn.Enabled = true;
			Process.Start("cmd.exe", "/c taskkill /F /IM AclassSDKConsole.exe /t");
			backgroundWorker1.CancelAsync();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (fiveM > 0)
			{
				string countDown = TimeSpan.FromSeconds(fiveM--).ToString(@"mm\:ss");
				this.Text = "Scale       " + countDown;
			}
			else
			{
				timer1.Dispose();
				backgroundWorker1.RunWorkerAsync();
			}
		}
		private void timerend_Tick(object sender, EventArgs e)
		{
			this.Close();
		}

		public void logs(string message)
		{
			try
			{
				logTextBox.Invoke((Action)delegate
				{
					logTextBox.Text = message + "\r\n" + logTextBox.Text;
				});
				StatusLog(message);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error updating logs: {ex.Message}");
			}
		}


		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{

		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled == true)
			{
				logs("Cancelled!");
			}
			else if (e.Error != null)
			{
				logs($"Error: {e.Error.Message}");
			}
			else
			{
				Process.Start("cmd.exe", "/c taskkill /F /IM AclassSDKConsole.exe /t");
				backgroundWorker1.CancelAsync();
				logs("Weighing Scale Process Done!");
			}
		}

		private void delet_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void delet_CheckedChanged_1(object sender, EventArgs e)
		{
			Properties.Settings.Default.Delete = this.delet.Checked;
			Properties.Settings.Default.Save();
		}

		private void ip1_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.SD1 = this.ip1.Checked;
			Properties.Settings.Default.Save();
		}

		private void ip2_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.SD2 = this.ip2.Checked;
			Properties.Settings.Default.Save();
		}

		private void ip3_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.SD3 = this.ip3.Checked;
			Properties.Settings.Default.Save();
		}

		private void download_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.Download = this.download.Checked;
			Properties.Settings.Default.Save();
		}

		private void upload_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.Upload = this.upload.Checked;
			Properties.Settings.Default.Save();
		}	

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == this.WindowState)
			{
				Hide();
				notifyIcon1.Visible = true;
				this.ShowInTaskbar = false;
				notifyIcon1.Text = "Weighing Scale - Running";
			}
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			this.WindowState = FormWindowState.Normal;
			this.ShowInTaskbar = true;
			notifyIcon1.Visible = false;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
			notifyIcon1.Visible = true;
			this.ShowInTaskbar = false;
			notifyIcon1.Text = "Weighing Scale - Running";
		}

		private void StartTime()
		{
			DateTime now = DateTime.Now; 
			string current = String.Format("{0:yyyyMMdd}", now);
			string branch = this.iniFile.GetSetting("Settings", "Branch");
			string trackPath = this.iniFile.GetSetting("Target", "TrackPath");
			string dat = $"{branch}.{current}.SCALE.START.TIME.dat";
			string file = Path.Combine(trackPath, dat);

			if (!Directory.Exists(trackPath))
			{
				Directory.CreateDirectory(trackPath);
			}

			DirectoryInfo directoryInfo = Directory.CreateDirectory(trackPath);
			directoryInfo.Attributes |= FileAttributes.Hidden;

			logTextBox.AppendText($"The weighing scale started running at {now}.\r\n");

			using (StreamWriter start = new StreamWriter(file, true))
			{
				start.WriteLine($"The weighing scale started running at {now}.");
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{

			DateTime now = DateTime.Now;
			string current = String.Format("{0:yyyyMMdd}", now);
			string branch = this.iniFile.GetSetting("Settings", "Branch");
			string trackPath = this.iniFile.GetSetting("Target", "TrackPath");
			string dat = $"{branch}.{current}.SCALE.CLOSED.TIME.dat";
			string file = Path.Combine(trackPath, dat);

			if (!Directory.Exists(trackPath))
			{
				Directory.CreateDirectory(trackPath);
			}

			logTextBox.AppendText($"The weighing scale closed at {now}.\r\n");

			using (StreamWriter end = new StreamWriter(file, true))
			{
				end.WriteLine($"The weighing scale closed at {now}.");
			}
		}
	}
}
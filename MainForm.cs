/*
 * Created by SharpDevelop.
 * User: Narudon
 * Date: 26/10/2556
 * Time: 13:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace MCback
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		const string CONFIGFILES = ".config";
		const string LASTBACKUP = "backup.config";
		const string LASTLBL = "Last backup folder : ";
			
		string sourcePath;		//store source directory
		string destinationPath;	//store destination directory
		string backupFolder; //backup brach folder 
		MCConfig config = new MCConfig();
		bool   configChange = false;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			OpenConfigFile();
			OpenLastBackup();
			UpdateSourceLabel();
			UpdateDestinationLabel();
			UpdateFolderText();
		}
		
		private void OnApplicationExit(object sender, EventArgs e) {
			SaveConfigFile();
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		//backup button
		void Button1Click(object sender, EventArgs e)
		{
			backupFolder = txtFolder.Text;
			Backup();
			SaveConfigFile();
			SaveLastBackup(backupFolder);
			
		}
		
		void FolderBrowserDialog1HelpRequest(object sender, EventArgs e)
		{
			
		}
		
		void BtnSourceClick(object sender, EventArgs e)
		{
			 FolderBrowserDialog fbd = folderBrowserDialog1;
			 
			 fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
			 fbd.SelectedPath = @sourcePath ;
			 
			 DialogResult result = fbd.ShowDialog();
			
			 string[] files = Directory.GetFiles(fbd.SelectedPath);
			 sourcePath = fbd.SelectedPath;
			 UpdateSourceLabel();
			 configChange = true;
			
		}
		
		void BtnSetDestinationClick(object sender, EventArgs e)
		{
			 FolderBrowserDialog fbd = folderBrowserDialog2;
			 
			 fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
			 fbd.SelectedPath = @destinationPath ;
			 fbd.ShowNewFolderButton = true;
			 
			 DialogResult result = fbd.ShowDialog();
			 
			 destinationPath = fbd.SelectedPath;
			 UpdateDestinationLabel();
			 configChange = true;
		}

		void Backup () {
			string newFolder = destinationPath+"/"+backupFolder;
				if(!Directory.Exists(newFolder)){
				Directory.CreateDirectory(newFolder);
				Copy(sourcePath,newFolder);
				MessageBox.Show("backup created.","Message");
			}else{
				DialogResult dialogResult = MessageBox.Show("Directory exist. Replace backup?", "Backup directory exist", MessageBoxButtons.YesNo);
				if(dialogResult == DialogResult.Yes)
				{
					Directory.Delete(newFolder,true);
					Directory.CreateDirectory(newFolder);
					Copy(sourcePath,newFolder);
					MessageBox.Show("backup created.","Message");
				}else if (dialogResult == DialogResult.No)
				{
					MessageBox.Show("backup abort.","Message");
				}
			}
		}
		void Copy(string sourceDir, string targetDir)
		{
			
			foreach (string dirPath in Directory.GetDirectories(sourceDir, "*", 
		    SearchOption.AllDirectories))
		    Directory.CreateDirectory(dirPath.Replace(sourceDir, targetDir));
		
			//Copy all the files
			foreach (string newPath in Directory.GetFiles(sourceDir, "*.*", 
		    SearchOption.AllDirectories))
		    File.Copy(newPath, newPath.Replace(sourceDir, targetDir));
		}
		
		void UpdateDestinationLabel () {
			lblDestinationPath.Text = destinationPath;
		}
		
		void UpdateSourceLabel () {
			lblSourcePath.Text = sourcePath;//MCConfigManager.instance.currentConfig.sourcePath;
		}
		
		void UpdateFolderText () {
			txtFolder.Text = backupFolder;
			
		}
		
		#region config files
		void SaveConfigFile () {
			StreamWriter st = File.CreateText(CONFIGFILES);
			st.WriteLine(sourcePath);
			st.WriteLine(destinationPath);
			st.WriteLine(backupFolder);
			st.Close();
		}
		
		void OpenConfigFile () {
			//try open files in current path
			string filePath = Directory.GetCurrentDirectory()+ "/"+ CONFIGFILES;
			if(File.Exists(filePath)){
				StreamReader stReader = new StreamReader(filePath);
				sourcePath = stReader.ReadLine();
				destinationPath = stReader.ReadLine();
				backupFolder = stReader.ReadLine();
				stReader.Close();
				//System.Windows.Forms.MessageBox.Show( destinationPath+backupFolder , "Message");
			}else{
				//set deafualt path if don't have any
				System.Windows.Forms.MessageBox.Show( "Config files not founded." + filePath , "Message");
				sourcePath = "C:/";
				destinationPath = "C:/";
				backupFolder = "backup";
			}
			
		}
		
		void SaveLastBackup (string name) {
		
			StreamWriter st = File.CreateText(LASTBACKUP);
			st.WriteLine(backupFolder);
			st.Close();
			lblBackup.Text = LASTLBL + name;
		}
		
		void OpenLastBackup () {
			
			string filePath = Directory.GetCurrentDirectory()+ "/"+ LASTBACKUP;
			if(File.Exists(filePath)){
				StreamReader stReader = new StreamReader(filePath);
				string read = stReader.ReadLine();
				stReader.Close();
				lblBackup.Text = LASTLBL + read;
			}else{
				lblBackup.Text = LASTLBL + "NONE";
			}
		}
		#endregion
		
		
		
		void TxtFolderTextChanged(object sender, EventArgs e)
		{
			backupFolder = txtFolder.Text;
		}
		
		void BtnToSourceClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(@sourcePath);
		}
		
		void BtnToDestinationClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(@destinationPath);
		}
		
		#region form
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		void MainFormClosing (object sender, EventArgs e) {
		
			if(configChange){
				DialogResult dialogResult = MessageBox.Show("Save config file before exit?", "exit", MessageBoxButtons.YesNo);
				if(dialogResult == DialogResult.Yes)
				{
					SaveConfigFile();
				}else if (dialogResult == DialogResult.No)
				{
					
				}
			}
		}
		#endregion
		
		void BtnAddTimeClick(object sender, System.EventArgs e)
		{
			txtFolder.Text += DateTime.Today.ToShortDateString();
		}
	}
}

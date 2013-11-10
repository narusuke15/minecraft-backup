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
using System.Diagnostics;

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
			
		MCConfig config = new MCConfig();
		bool   configChange = false;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//load config
			OpenConfigFile();
			//update program from config data
			UpdateLastBackup();
			UpdateSourceLabel();
			UpdateDestinationLabel();
			UpdateFolderText();
			
		}
		
		private void OnApplicationExit(object sender, EventArgs e) {
			SaveConfigFile();
		}
	

		void Backup () {
			string newFolder = config.destinationPath+"/"+config.saveFolderName;
			if(!Directory.Exists(newFolder)){
				Directory.CreateDirectory(newFolder);
				Copy(MCConfigManager.instance.currentConfig.sourcePath,newFolder);
				MessageBox.Show("backup created.","Message");
			}else{
				DialogResult dialogResult = MessageBox.Show("Directory exist. Replace backup?", "Backup directory exist", MessageBoxButtons.YesNo);
				if(dialogResult == DialogResult.Yes)
				{
					Directory.Delete(newFolder,true);
					Directory.CreateDirectory(newFolder);
					Copy(MCConfigManager.instance.currentConfig.sourcePath,newFolder);
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
			lblDestinationPath.Text = config.destinationPath;
		}
		
		void UpdateSourceLabel () {
			lblSourcePath.Text = config.sourcePath;
		}
		
		void UpdateFolderText () {
			txtFolder.Text = config.saveFolderName;
			
		}
		
		#region config files
		void SaveConfigFile () {
			MCConfigManager.instance.SaveConfig(config);
		}
		
		void OpenConfigFile () {
			
			try{
				config = MCConfigManager.instance.LoadConfig();
			}catch{
				Debug.WriteLine("tryload failed");
			}
		}
		
		void SetLastBackup (string name) {
		
			config.lastBackupFolder = name;
			lblBackup.Text = LASTLBL + name;
		}
		
		void UpdateLastBackup () {
	
			lblBackup.Text = LASTLBL + config.lastBackupFolder;
		}
		#endregion
		
		
		
		void TxtFolderTextChanged(object sender, EventArgs e)
		{
			config.lastBackupFolder = txtFolder.Text;
		}
		
		
		
		#region Button
		
		void BtnToSourceClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(@config.sourcePath);
		}
		
		void BtnToDestinationClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(@config.destinationPath);
		}
		
		void BtnAddTimeClick(object sender, System.EventArgs e)
		{
			txtFolder.Text += DateTime.Today.ToShortDateString();
		}
		
		void BtnSourceClick(object sender, EventArgs e)
		{
			
			FolderBrowserDialog fbd = folderBrowserDialog1;
		 
			//fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
			fbd.SelectedPath = @MCConfigManager.instance.currentConfig.sourcePath ;
			fbd.ShowNewFolderButton = false;
			DialogResult result = fbd.ShowDialog();
			
			string[] files = Directory.GetFiles(fbd.SelectedPath);
			MCConfigManager.instance.currentConfig.sourcePath = fbd.SelectedPath;
			UpdateSourceLabel();
			configChange = true;
		}
		
		void BtnSetDestinationClick(object sender, EventArgs e)
		{
			 FolderBrowserDialog fbd = folderBrowserDialog2;
			 
			 //fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
			 fbd.SelectedPath = @config.destinationPath ;
			 fbd.ShowNewFolderButton = true;
			 
			 DialogResult result = fbd.ShowDialog();
			 
			 config.destinationPath = fbd.SelectedPath;
			 UpdateDestinationLabel();
			 configChange = true;
		}
		
		//backup button
		void Button1Click(object sender, EventArgs e)
		{
			
			DialogResult dialogResult = MessageBox.Show("Do you want to backup files form " + config.sourcePath + "  to  " + config.destinationPath + "?"
			                                            , "confirm backup", MessageBoxButtons.OKCancel);
			if(dialogResult == DialogResult.Yes)
			{
				SaveConfigFile();
			}else if (dialogResult == DialogResult.No)
			{
				
			}
				
			config.saveFolderName = txtFolder.Text; //update folder name before backup
			Backup();
			
			SetLastBackup(txtFolder.Text);
			SaveConfigFile();
			
		}
		#endregion
		
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
		
		
		
		void TrySave () {
			
			config.sourcePath = "test";
			config.destinationPath = "test";
			config.lastBackupFolder = "last";
			config.saveFolderName = "name";
			MCConfigManager.instance.SaveConfig(config);
		}
		
		void TryLoad () {
			try{
				config = MCConfigManager.instance.LoadConfig();
			}catch{
				Debug.WriteLine("tryload failed");
			}
			
		}
	}
}

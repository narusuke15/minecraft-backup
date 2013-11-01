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
		string sourcePath;		//store source directory
		string destinationPath;	//store destination directory
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			OpenConfigFile();
			UpdateSourceLabel();
			UpdateDestinationLabel();
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		//backup button
		void Button1Click(object sender, EventArgs e)
		{
			Copy(sourcePath, destinationPath);
			System.Windows.Forms.MessageBox.Show("backup from :" + sourcePath +" to :" + destinationPath, "Message");
			
		}
		
		void FolderBrowserDialog1HelpRequest(object sender, EventArgs e)
		{
			
		}
		
		void BtnSourceClick(object sender, EventArgs e)
		{
			 FolderBrowserDialog fbd = folderBrowserDialog1;
			 fbd.SelectedPath = sourcePath ;
			 DialogResult result = fbd.ShowDialog();
			
			 string[] files = Directory.GetFiles(fbd.SelectedPath);
			 sourcePath = fbd.SelectedPath;
			 System.Windows.Forms.MessageBox.Show("Selected " + sourcePath, "Message");
			 UpdateSourceLabel();
			 //test			
			 SaveConfigFile();
		}
		
		void BtnSetDestinationClick(object sender, EventArgs e)
		{
			 FolderBrowserDialog fbd = folderBrowserDialog2;
			 fbd.SelectedPath = destinationPath ;
			 DialogResult result = fbd.ShowDialog();
			 
			 destinationPath = fbd.SelectedPath;
			 System.Windows.Forms.MessageBox.Show("Selected " + destinationPath, "Message");
			 UpdateDestinationLabel();
			 SaveConfigFile();
		}
		
		void Copy(string sourceDir, string targetDir)
		{
		    Directory.CreateDirectory(targetDir);
		
		    foreach(var file in Directory.GetFiles(sourceDir))
		        File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
		
		    foreach(var directory in Directory.GetDirectories(sourceDir))
		        Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
		}
		
		void UpdateDestinationLabel () {
			lblDestinationPath.Text = destinationPath;
		}
		
		void UpdateSourceLabel () {
			lblSourcePath.Text = sourcePath;
		}
		
		#region config files
		void SaveConfigFile () {
			StreamWriter st = File.CreateText(CONFIGFILES);
			st.WriteLine(sourcePath);
			st.WriteLine(destinationPath);
			st.Close();
		}
		
		void OpenConfigFile () {
			//try open files in current path
			string filePath = Directory.GetCurrentDirectory()+ "/"+ CONFIGFILES;
			if(File.Exists(filePath)){
				StreamReader stReader = new StreamReader(filePath);
				sourcePath = stReader.ReadLine();
				destinationPath = stReader.ReadLine();
				stReader.Close();
				System.Windows.Forms.MessageBox.Show( "sr :"+sourcePath + "  ds :"+destinationPath , "Message");
			}else{
				//set deafualt path if don't have any
				System.Windows.Forms.MessageBox.Show( "Config files not founded." + filePath , "Message");
				sourcePath = "C:/";
				destinationPath = "C:/";
			}
			
		}
		#endregion
		
		
	}
}

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
		string sourcePath;
		string destinationPath;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		//backup button
		void Button1Click(object sender, EventArgs e)
		{
			CopyAll();
		}
		
		void FolderBrowserDialog1HelpRequest(object sender, EventArgs e)
		{
			
		}
		
		void BtnSourceClick(object sender, EventArgs e)
		{
			 FolderBrowserDialog fbd = folderBrowserDialog1;
			 DialogResult result = fbd.ShowDialog();
			
			 string[] files = Directory.GetFiles(fbd.SelectedPath);
			 sourcePath = fbd.SelectedPath;
			 System.Windows.Forms.MessageBox.Show("Selected " + sourcePath, "Message");
		}
		
		void BtnSetDestinationClick(object sender, EventArgs e)
		{
			 FolderBrowserDialog fbd = folderBrowserDialog1;
			 DialogResult result = fbd.ShowDialog();
			 
			 destinationPath = fbd.SelectedPath;
			 System.Windows.Forms.MessageBox.Show("Selected " + destinationPath, "Message");
		}
		
		void CopyAll () 
		{
			//Now Create all of the directories
			foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", 
			    SearchOption.AllDirectories))
			    Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));
			
			//Copy all the files
			foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", 
			    SearchOption.AllDirectories))
			    File.Copy(newPath, newPath.Replace(sourcePath, destinationPath));
			
			System.Windows.Forms.MessageBox.Show("backup from :" + sourcePath +" to :" + destinationPath, "Message");
		}
	}
}

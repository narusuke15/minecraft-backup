/*
 * Created by SharpDevelop.
 * User: Narudon
 * Date: 26/10/2556
 * Time: 13:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MCback
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.btnSource = new System.Windows.Forms.Button();
			this.btnSetDestination = new System.Windows.Forms.Button();
			this.lblSourcePath = new System.Windows.Forms.Label();
			this.lblDestinationPath = new System.Windows.Forms.Label();
			this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnToSource = new System.Windows.Forms.Button();
			this.btnToDestination = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Source World";
			this.label1.Click += new System.EventHandler(this.Label1Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Backup destination";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(404, 99);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Backup";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.FolderBrowserDialog1HelpRequest);
			// 
			// btnSource
			// 
			this.btnSource.Location = new System.Drawing.Point(146, 17);
			this.btnSource.Name = "btnSource";
			this.btnSource.Size = new System.Drawing.Size(75, 23);
			this.btnSource.TabIndex = 3;
			this.btnSource.Text = "set";
			this.btnSource.UseVisualStyleBackColor = true;
			this.btnSource.Click += new System.EventHandler(this.BtnSourceClick);
			// 
			// btnSetDestination
			// 
			this.btnSetDestination.Location = new System.Drawing.Point(146, 60);
			this.btnSetDestination.Name = "btnSetDestination";
			this.btnSetDestination.Size = new System.Drawing.Size(75, 23);
			this.btnSetDestination.TabIndex = 4;
			this.btnSetDestination.Text = "set";
			this.btnSetDestination.UseVisualStyleBackColor = true;
			this.btnSetDestination.Click += new System.EventHandler(this.BtnSetDestinationClick);
			// 
			// lblSourcePath
			// 
			this.lblSourcePath.Location = new System.Drawing.Point(227, 22);
			this.lblSourcePath.Name = "lblSourcePath";
			this.lblSourcePath.Size = new System.Drawing.Size(252, 23);
			this.lblSourcePath.TabIndex = 5;
			this.lblSourcePath.Text = "path";
			// 
			// lblDestinationPath
			// 
			this.lblDestinationPath.Location = new System.Drawing.Point(227, 65);
			this.lblDestinationPath.Name = "lblDestinationPath";
			this.lblDestinationPath.Size = new System.Drawing.Size(252, 23);
			this.lblDestinationPath.TabIndex = 6;
			this.lblDestinationPath.Text = "path";
			// 
			// txtFolder
			// 
			this.txtFolder.Location = new System.Drawing.Point(81, 102);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(303, 20);
			this.txtFolder.TabIndex = 7;
			this.txtFolder.Text = "World_10_10_14";
			this.txtFolder.TextChanged += new System.EventHandler(this.TxtFolderTextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "folder name";
			// 
			// btnToSource
			// 
			this.btnToSource.Location = new System.Drawing.Point(113, 17);
			this.btnToSource.Name = "btnToSource";
			this.btnToSource.Size = new System.Drawing.Size(27, 23);
			this.btnToSource.TabIndex = 9;
			this.btnToSource.Text = "to";
			this.btnToSource.UseVisualStyleBackColor = true;
			this.btnToSource.Click += new System.EventHandler(this.BtnToSourceClick);
			// 
			// btnToDestination
			// 
			this.btnToDestination.Location = new System.Drawing.Point(113, 60);
			this.btnToDestination.Name = "btnToDestination";
			this.btnToDestination.Size = new System.Drawing.Size(27, 23);
			this.btnToDestination.TabIndex = 10;
			this.btnToDestination.Text = "to";
			this.btnToDestination.UseVisualStyleBackColor = true;
			this.btnToDestination.Click += new System.EventHandler(this.BtnToDestinationClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(490, 135);
			this.Controls.Add(this.btnToDestination);
			this.Controls.Add(this.btnToSource);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtFolder);
			this.Controls.Add(this.lblDestinationPath);
			this.Controls.Add(this.lblSourcePath);
			this.Controls.Add(this.btnSetDestination);
			this.Controls.Add(this.btnSource);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "MCback";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnToDestination;
		private System.Windows.Forms.Button btnToSource;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFolder;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
		private System.Windows.Forms.Label lblDestinationPath;
		private System.Windows.Forms.Label lblSourcePath;
		private System.Windows.Forms.Button btnSetDestination;
		private System.Windows.Forms.Button btnSource;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

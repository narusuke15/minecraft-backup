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
			this.button1.Location = new System.Drawing.Point(218, 142);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 277);
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
		}
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

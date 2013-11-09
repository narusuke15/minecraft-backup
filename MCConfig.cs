/*
 * Created by SharpDevelop.
 * User: Narudon
 * Date: 8/11/2556
 * Time: 22:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MCback
{
	/// <summary>
	/// Description of MCConfig.
	/// </summary>
	public class MCConfig
	{
		#region Data
		string sourcePath;		//store source directory
		string destinationPath;	//store destination directory
		string lastBackupFolder;    //last backup folder 
		string currentFolder;   //text field foldernam
		#endregion
		
		public MCConfig()
		{
		}
	}
}

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
		
		private string _sourcePath;		//store source directory
	    public string sourcePath {
	    	get{
				if(_sourcePath != null)
					return _sourcePath;
				else return "C:/";				
			}
	        set{ _sourcePath = value; }
	    }
		
		private string _destinationPath;	//store destination directory
		public string destinationPath {
	        get{ 
				if(_destinationPath != null)
					return _destinationPath; 
				else return "C:/";
			}
	          set{ _destinationPath = value; }
	    }
		
		private string _lastBackupFolder;    //last backup folder
		public string lastBackupFolder {
	        get{
				if(_lastBackupFolder != null)
					return _lastBackupFolder;  
				else
					return "NONE";
			}
	        set{ _lastBackupFolder = value; }
	    }
		
		private string _saveFolderName;   //text field foldername
		public string saveFolderName {
	        get{ 
				if(_saveFolderName != null)
					return _saveFolderName;
				else
					return "backup";					
			}
	        set{ _saveFolderName = value; }
	    }
		#endregion
		
		public MCConfig()
		{
		}
	}
}

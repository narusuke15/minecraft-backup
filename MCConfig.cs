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
	          get{ return _sourcePath;  }
	          set{ _sourcePath = value; }
	    }
		
		private string _destinationPath;	//store destination directory
		public string destinationPath {
	          get{ return _destinationPath;  }
	          set{ _destinationPath = value; }
	    }
		
		private string _lastBackupFolder;    //last backup folder
		public string lastBackupFolder {
	          get{ return _lastBackupFolder;  }
	          set{ _lastBackupFolder = value; }
	    }
		
		private string _saveFolderName;   //text field foldername
		public string saveFolderName {
	          get{ return _saveFolderName;  }
	          set{ _saveFolderName = value; }
	    }
		#endregion
		
		public MCConfig()
		{
		}
	}
}
